using Day03.Models.Enums;
using Day03.Models.Requests;
using Day03.Models.Responses;

namespace Day03.Factories
{
    /// <summary>
    /// factory for calculating points for duplicate items
    /// </summary>
    public class PointFactory
    {
        /// <summary>
        /// method for getting points for duplicate items
        /// </summary>
        /// <param name="request">object containing data for the duplicate items</param>
        /// <returns>total points for duplicate items</returns>
        public async Task<GetPointsResponse> GetPoints(GetPointsRequest request)
        {
            var response = new GetPointsResponse();

            try
            {
                foreach (var item in request.Items)
                {
                    int value = 0;

                    switch (char.IsLower(item))
                    {
                        case true:
                        value = item - 96;
                            break;

                        case false:
                            value = item - 38;
                            break;

                        default:
                            throw new Exception("Could not get points for item");
                    }

                    response.TotalPoints += value;
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
