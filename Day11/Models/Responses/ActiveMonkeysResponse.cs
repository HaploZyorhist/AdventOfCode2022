using Day11.Models.Enums;

namespace Day11.Models.Responses
{
    /// <summary>
    /// object containing data on the active monkeys for the round
    /// </summary>
    public class ActiveMonkeysResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// the monkeys that were the most active for the rounds
        /// </summary>
        public List<Monkey> Monkeys { get; set; } = new List<Monkey>();
    }
}
