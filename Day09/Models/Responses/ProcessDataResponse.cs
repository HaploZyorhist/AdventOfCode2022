using Day09.Models.Enums;

namespace Day09.Models.Responses
{
    /// <summary>
    /// object containing processed data and status of reqeust
    /// </summary>
    public class ProcessDataResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the instructions the knot is supposed to take
        /// </summary>
        public List<Instruction> Instructions { get; set; } = new List<Instruction>();
    }
}
