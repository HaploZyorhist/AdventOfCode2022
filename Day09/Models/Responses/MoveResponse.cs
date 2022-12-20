using Day09.Models.Enums;
using System.Numerics;

namespace Day09.Models.Responses
{
    /// <summary>
    /// response for move rope request
    /// </summary>
    public class MoveResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the locations of the knots in the rope
        /// </summary>
        public List<Vector2> KnotLocations { get; set; } = new List<Vector2>();

        /// <summary>
        /// the locations the tail has visited
        /// </summary>
        public Dictionary<Vector2, int> LocationsTailVisited { get; set; } = new Dictionary<Vector2, int>();
    }
}
