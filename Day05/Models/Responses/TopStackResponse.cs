using Day05.Models.Enums;

namespace Day05.Models.Responses
{
    /// <summary>
    /// object containing the data from the request for getting the top crate from each stack
    /// </summary>
    public class TopStackResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// the top crate from each stack
        /// part 1
        /// </summary>
        public string StackResponse { get; set; } = string.Empty;

        /// <summary>
        /// the top crate from each stack
        /// part 2
        /// </summary>
        public string StackResponseRevised { get; set; } = string.Empty;
    }
}
