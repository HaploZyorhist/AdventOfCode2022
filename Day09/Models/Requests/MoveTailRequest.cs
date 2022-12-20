using Day09.Models.Enums;
using System.Numerics;

namespace Day09.Models.Requests
{
    /// <summary>
    /// information showing how the tail needs to move
    /// </summary>
    public class MoveTailRequest
    {
        /// <summary>
        /// the location of the head of the rope
        /// </summary>
        public Vector2 LeaderLocation { get; set; } = Vector2.Zero;

        /// <summary>
        /// the location of the tail of the rope
        /// </summary>
        public Vector2 TailLocation { get; set; } = Vector2.Zero;

        /// <summary>
        /// the direction the head is moving
        /// </summary>
        public DirectionEnum Direction { get; set; } = DirectionEnum.None;
    }
}
