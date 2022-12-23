using Day10.Models.Enums;

namespace Day10.Models.Responses
{
    /// <summary>
    /// object containing the results of checking the cycle
    /// </summary>
    public class CheckCycleResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the strength of the signal
        /// </summary>
        public int SignalStrength { get; set; } = 0;
    }
}
