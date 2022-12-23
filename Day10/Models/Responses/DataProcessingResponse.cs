using Day10.Models.Enums;

namespace Day10.Models.Responses
{
    /// <summary>
    /// the response for the data that was processed
    /// </summary>
    public class DataProcessingResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the instructions that are to be passed
        /// </summary>
        public List<Instruction> Instructions { get; set; } = new List<Instruction>();
    }
}
