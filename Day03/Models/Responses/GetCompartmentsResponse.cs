using Day03.Models.Enums;

namespace Day03.Models.Responses
{
    /// <summary>
    /// response object for the contents of rucksacks
    /// </summary>
    public class GetCompartmentsResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the rucksacks with their contents
        /// </summary>
        public List<RuckSack> RuckSacks { get; set; } = new List<RuckSack>();
    }
}
