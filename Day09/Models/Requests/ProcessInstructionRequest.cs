namespace Day09.Models.Requests
{
    /// <summary>
    /// request for tracking tail movement for instructions
    /// </summary>
    public class ProcessInstructionRequest
    {
        /// <summary>
        /// the list of instructions to be processed
        /// </summary>
        public List<Instruction> Instructions { get; set; } = new List<Instruction>();
    }
}
