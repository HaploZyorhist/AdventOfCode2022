using Day03.Models.Enums;

namespace Day03.Models.Responses
{
    /// <summary>
    /// response object for getting points
    /// </summary>
    public class GetPointsResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the total points for the duplicate items
        /// </summary>
        public int TotalPoints { get; set; } = 0;
    }
}
