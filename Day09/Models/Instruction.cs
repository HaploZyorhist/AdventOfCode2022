using Day09.Models.Enums;

namespace Day09.Models
{
    /// <summary>
    /// the instruction the knot is supposed to take
    /// </summary>
    public class Instruction
    {
        /// <summary>
        /// the direction the knot is supposed to move
        /// </summary>
        public DirectionEnum Direction { get; set; } = DirectionEnum.None;

        /// <summary>
        /// the number of spaces the knot is supposed to move
        /// </summary>
        public int Spaces { get; set; } = 0;
    }
}
