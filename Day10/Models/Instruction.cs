using Day10.Models.Enums;

namespace Day10.Models
{
    /// <summary>
    /// the instruction that is passed to the screen
    /// </summary>
    public class Instruction
    {
        /// <summary>
        /// the instruction type that is passed to the screen
        /// </summary>
        public InstructionEnum Type { get; set; } = InstructionEnum.None;

        /// <summary>
        /// the strength of the signal
        /// </summary>
        public int Strength { get; set; } = 0;
    }
}
