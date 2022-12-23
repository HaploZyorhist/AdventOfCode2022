namespace Day10.Models.Requests
{
    /// <summary>
    /// object containing items for processing instructions
    /// </summary>
    public class InstructionProcessingRequest
    {
        /// <summary>
        /// instructions to be processed
        /// </summary>
        public List<Instruction> Instructions { get; set; } = new List<Instruction>();
    }
}
