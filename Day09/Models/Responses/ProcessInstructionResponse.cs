using Day09.Models.Enums;
using System.Numerics;

namespace Day09.Models.Responses
{
    /// <summary>
    /// object containing the results of the request
    /// </summary>
    public class ProcessInstructionResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// set of locations visited with the number of times visited
        /// </summary>
        public Dictionary<Vector2, int> LocationsVisited { get; set; } = new Dictionary<Vector2, int>();
    }
}
