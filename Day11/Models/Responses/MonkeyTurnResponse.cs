using Day11.Models.Enums;

namespace Day11.Models.Responses
{
    /// <summary>
    /// object containing the response of the monkey's turn
    /// </summary>
    public class MonkeyTurnResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// the monkeys at the end of the turn
        /// </summary>
        public List<Monkey> Monkeys { get; set; } = new List<Monkey>();
    }
}
