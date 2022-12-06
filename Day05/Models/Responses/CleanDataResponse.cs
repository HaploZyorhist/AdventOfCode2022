using Day05.Models.Enums;

namespace Day05.Models.Responses
{
    /// <summary>
    /// response with cleaned data
    /// to include instructions and the model of the ship
    /// </summary>
    public class CleanDataResponse
    {
        /// <summary>
        /// status of the request
        /// default to failure
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// the instruction queue
        /// </summary>
        public Queue<Instruction> Instructions { get; set; } = new Queue<Instruction>();
        
        /// <summary>
        /// the configuration of the ship
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
