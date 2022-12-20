using Day09.Models.Enums;
using System.Numerics;

namespace Day09.Models.Responses
{
    /// <summary>
    /// response of how the tail moved
    /// </summary>
    public class MoveTailResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the location of the tail after the move
        /// </summary>
        public Vector2 TailLocation { get; set; } = Vector2.Zero;
    }
}
