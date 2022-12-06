namespace Day05.Models.Requests
{
    /// <summary>
    /// request for processing instructions on the ship configuration
    /// </summary>
    public class ProcessInstructionsRequest
    {
        /// <summary>
        /// the instructions to be performed
        /// </summary>
        public Queue<Instruction> Instructions { get; set; } = new Queue<Instruction>();

        /// <summary>
        /// the ship configuration to be processed
        /// part 1
        /// </summary>
        public List<Stack<string>> CargoStacks { get; set; } = new List<Stack<string>>();

        /// <summary>
        /// the cargo stacks and their contents
        /// part 2
        /// </summary>
        public List<Stack<string>> CargoStacksRevised { get; set; } = new List<Stack<string>>();
    }
}
