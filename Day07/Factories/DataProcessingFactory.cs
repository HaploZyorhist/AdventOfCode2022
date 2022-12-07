using Day07.Models;
using Day07.Models.Enums;
using Day07.Models.Requests;
using Day07.Models.Responses;

namespace Day07.Factories
{
    /// <summary>
    /// factory for processing input data
    /// </summary>
    public class DataProcessingFactory
    {
        /// <summary>
        /// method for processing the raw data
        /// </summary>
        /// <param name="request">object containing data to be processed</param>
        /// <returns>object returning the processed data and status</returns>
        public async Task<DataProcessResponse> ProcessRawData(DataProcessRequest request)
        {
            var response = new DataProcessResponse();

            try
            {
                var data = request.RawData.Split("\r\n");

                // create root directory
                var rootDirectory = new SystemDirectory
                {
                    Name = @"/",
                };

                var currentDirectory = rootDirectory;

                foreach (var item in data)
                {
                    if (item.StartsWith(@"$"))
                    {
                        var processCommandRequest = new ProcessCommandRequest
                        {
                            Command = item,
                            Directory= currentDirectory,
                        };

                        var processCommandResponse = ProcessCommand(processCommandRequest);

                        if(processCommandResponse is not { Status: StatusEnum.Success})
                        {
                            throw new Exception($"Could not process {item} properly");
                        }

                        currentDirectory = processCommandResponse.Directory;
                    }
                    else
                    {
                        var processItemRequest = new ProcessItemRequest
                        {
                            ItemData = item,
                            ParentDirectory = currentDirectory,
                        };

                        var processItemResponse = ProcessItem(processItemRequest);

                        if(processItemResponse is not { Status: StatusEnum.Success})
                        {
                            throw new Exception($"Could not process {item} correctly");
                        }

                        if(processItemResponse.DirectoryCreated is not null)
                        {
                            currentDirectory.ChildDirectories.Add(processItemResponse.DirectoryCreated);
                        }
                        else if (processItemResponse.FileCreated is not null)
                        {
                            currentDirectory.ChildFiles.Add(processItemResponse.FileCreated);
                        }
                    }
                }

                response.RootDirectory = rootDirectory;

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
        /// method for processing the command that was executed
        /// </summary>
        /// <param name="request">object containing the command and the active directory</param>
        /// <returns>object containing the current active directory</returns>
        private ProcessCommandResponse ProcessCommand(ProcessCommandRequest request)
        {
            var response = new ProcessCommandResponse();

            try
            {
                response.Directory = request.Directory;

                var command = request.Command.ToLower();

                if (string.Equals(command, @"$ cd .."))
                {
                    response.Directory = request.Directory.ParentDirectory!;
                }
                else if (command.StartsWith(@"$ cd ") && !command.Contains(@"/"))
                {
                    var newDirectoryName = command.Remove(0, 5);
                    response.Directory = request.Directory.ChildDirectories.Where(x => x.Name == newDirectoryName).First();
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
        /// method for processing an item from the list of items
        /// </summary>
        /// <param name="request">object containing the item details of the item</param>
        /// <returns>object containing the object item as a type</returns>
        private ProcessItemResponse ProcessItem(ProcessItemRequest request)
        {
            var response = new ProcessItemResponse();

            try
            {
                var item = request.ItemData.ToLower();

                if (item.StartsWith("dir"))
                {
                    var directoryName = item.Remove(0, 4);

                    var newChildDirectory = new SystemDirectory
                    {
                        Name = directoryName,
                        ParentDirectory = request.ParentDirectory
                    };

                    response.DirectoryCreated = newChildDirectory;
                }
                else
                {
                    var fileArray = item.Split(" ");

                    var fileCreated = new DirectoryFile
                    {
                        Name = fileArray[1],
                        Size = int.Parse(fileArray[0])
                    };

                    response.FileCreated = fileCreated;
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
