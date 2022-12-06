namespace Day05.Models
{
    /// <summary>
    /// object containing an instruction to be performed
    /// </summary>
    public class Instruction
    {
        /// <summary>
        /// the number of crates to be moved
        /// </summary>
        public int Move { get; set; } = 0;

        /// <summary>
        /// where to pull the crates from
        /// </summary>
        public int Start { get; set; } = 0;

        /// <summary>
        /// where to put the crates
        /// </summary>
        public int End { get; set; } = 0;
    }
}
