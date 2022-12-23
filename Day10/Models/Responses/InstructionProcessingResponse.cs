using Day10.Models.Enums;

namespace Day10.Models.Responses
{
    /// <summary>
    /// object containing the results of instructions that were processed
    /// </summary>
    public class InstructionProcessingResponse
    {
        /// <summary>
        /// indicator of the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the signal strength that was the result of the instructions
        /// </summary>
        public int SignalStrength { get; set; } = 0;
    }
}
