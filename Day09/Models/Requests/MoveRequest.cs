using System.Numerics;

namespace Day09.Models.Requests
{
    /// <summary>
    /// object for requesting the rope to move
    /// </summary>
    public class MoveRequest
    {
        /// <summary>
        /// locations of the knots in the rope
        /// </summary>
        public List<Vector2> KnotLocations { get; set; } = new List<Vector2>();

        /// <summary>
        /// the instruction that is to be followed
        /// </summary>
        public Instruction Instruction { get; set; } = new Instruction();

        /// <summary>
        /// the locations that the tail has visited
        /// </summary>
        public Dictionary<Vector2, int> TailLocationsVisited { get; set; } = new Dictionary<Vector2, int>();
    }
}
