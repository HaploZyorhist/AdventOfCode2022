using Day07.Models.Enums;
using Day07.Models.Requests;
using Day07.Models.Responses;

namespace Day07.Services
{
    /// <summary>
    /// service for handling directory functions
    /// </summary>
    public class DirectoryService
    {
        public int threshold = 100000;
        public int requirement = 70000000;

        /// <summary>
        /// method for getting small directories under a specific size
        /// </summary>
        /// <param name="request">item containing data for processing small directories</param>
        /// <returns>object containing the directories under the specified threshold</returns>
        public async Task<GetSmallDirectoryResponse> GetSmallDirectories(GetSmallDirectoryRequest request)
        {
            var response = new GetSmallDirectoryResponse();

            try
            {
                var checkDirectoriesReqeust = new CheckDirectoryRequest
                {
                    Directory = request.RootDirectory
                };

                var childrenResponse = await CheckDirectories(checkDirectoriesReqeust);

                if (childrenResponse is not { Status: StatusEnum.Success })
                {
                    throw new Exception("Could not process child directories for size");
                }

                response.SmallDirectories.AddRange(childrenResponse.SmallDirectories);

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return response;
            }
        }


        /// <summary>
        /// method for getting large directories over a specific size
        /// </summary>
        /// <param name="request">item containing data for processing large directories</param>
        /// <returns>object containing the directories over the specified threshold</returns>
        public async Task<GetLargeDirectoryResponse> GetLargeDirectories(GetLargeDirectoryRequest request)
        {
            var response = new GetLargeDirectoryResponse();

            try
            {
                requirement = 30000000 - (70000000 - await request.RootDirectory.GetDirectorySize());
                var checkDirectoriesReqeust = new CheckAndFilterDirectoryRequest
                {
                    Directory = request.RootDirectory
                };

                var childrenResponse = await CheckAndFilterDirectories(checkDirectoriesReqeust);

                if (childrenResponse is not { Status: StatusEnum.Success })
                {
                    throw new Exception("Could not process child directories for size");
                }

                response.LargeDirectories.AddRange(childrenResponse.LargeDirectories);

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return response;
            }
        }

        /// <summary>
        /// method for checking child directories
        /// </summary>
        /// <param name="request">object containing directories to be checked</param>
        /// <returns>list of directories that have been checked</returns>
        private async Task<CheckDirectoryResponsee> CheckDirectories(CheckDirectoryRequest request)
        {
            var response = new CheckDirectoryResponsee();

            try
            {
                var directorySize = await request.Directory.GetDirectorySize();

                if (directorySize < threshold)
                {
                    response.SmallDirectories.Add(request.Directory);
                }

                foreach (var child in request.Directory.ChildDirectories)
                {
                    var checkChild = new CheckDirectoryRequest
                    {
                        Directory = child,
                    };

                    var checkChildResponse = await CheckDirectories(checkChild);

                    if (checkChildResponse is not { Status: StatusEnum.Success })
                    {
                        throw new Exception("Could not process the child directories");
                    }

                    response.SmallDirectories.AddRange(checkChildResponse.SmallDirectories);
                }

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return response;
            }
        }

        /// <summary>
        /// method for checking and filtering out child directories
        /// </summary>
        /// <param name="request">object containing directories to be checked</param>
        /// <returns>list of directories that meet filter criteria</returns>
        private async Task<CheckAndFilterDirectoryResponse> CheckAndFilterDirectories(CheckAndFilterDirectoryRequest request)
        {
            var response = new CheckAndFilterDirectoryResponse();

            try
            {
                var directorySize = await request.Directory.GetDirectorySize();

                if (directorySize < requirement)
                {
                    // no point checking children if the directory itself doesn't meet size
                    response.Status = StatusEnum.Success;

                    return response;
                }

                response.LargeDirectories.Add(request.Directory);

                foreach (var child in request.Directory.ChildDirectories)
                {
                    var checkChild = new CheckAndFilterDirectoryRequest
                    {
                        Directory = child,
                    };

                    var checkChildResponse = await CheckAndFilterDirectories(checkChild);

                    if (checkChildResponse is not { Status: StatusEnum.Success })
                    {
                        throw new Exception("Could not process the child directories");
                    }

                    response.LargeDirectories.AddRange(checkChildResponse.LargeDirectories);
                }

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return response;
            }
        }
    }
}
