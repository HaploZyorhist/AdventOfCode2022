using Day11.Models.Enums;

namespace Day11.Models.Responses
{
    /// <summary>
    /// object contianing the response for data processing
    /// </summary>
    public class ProcessDataResponse
    {
        /// <summary>
        /// status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// the monkeys that were processed
        /// </summary>
        public List<Monkey> MonkeyList { get; set; } = new List<Monkey>();
    }
}
