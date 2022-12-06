using Day06.Models.Enums;
using Day06.Models.Requests;
using Day06.Models.Responses;

namespace Day06.Services
{
    /// <summary>
    /// service for processing the data 
    /// </summary>
    public class DataProcessingService
    {
        /// <summary>
        /// method for finding the location of the marker
        /// </summary>
        /// <param name="request">object containing raw data for finding the marker</param>
        /// <returns>object containing the status of the request and marker location</returns>
        public async Task<MarkerResponse> GetMarker(MarkerRequest request)
        {
            var response = new MarkerResponse();

            try
            {
                int marker = 0;

                for (int i = 0; i < request.DataInput.Length - 4; i++)
                {
                    var tempMarker = request.DataInput.Substring(i, 4);

                    var groups = tempMarker.GroupBy(c => c).Where(g => g.Count() > 1).ToList();

                    if (groups.Count > 0)
                    {
                        continue;
                    }

                    marker = i + 4;
                    break;
                }

                response.MarkerPosition = marker;

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
        /// method for finding the location of the message
        /// </summary>
        /// <param name="request">object containing the data to be searched for the message location</param>
        /// <returns>status and location of the message</returns>
        public async Task<MessageResponse> GetMessage(MessageRequest request)
        {
            var response = new MessageResponse();

            try
            {
                int marker = 0;

                for (int i = 0; i < request.DataInput.Length - 14; i++)
                {
                    var tempMarker = request.DataInput.Substring(i, 14);

                    var groups = tempMarker.GroupBy(c => c).Where(g => g.Count() > 1).ToList();

                    if (groups.Count > 0)
                    {
                        continue;
                    }

                    marker = i + 14;
                    break;
                }

                response.MessagePosition = marker;

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
