using Day05.Models.Enums;

namespace Day05.Models.Responses
{
    /// <summary>
    /// object containing the instructions and status of the request
    /// </summary>
    public class GetInstructionsResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// the list of instructions to be performed
        /// </summary>
        public Queue<Instruction> Instructions { get; set;} = new Queue<Instruction>();
    }
}
