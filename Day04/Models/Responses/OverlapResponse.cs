using Day04.Models.Enums;

namespace Day04.Models.Responses
{
    /// <summary>
    /// response object for the overlap areas
    /// </summary>
    public class OverlapResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the count of elves overlapped
        /// </summary>
        public int OverlapCount { get; set; } = 0;
    }
}
