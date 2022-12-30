namespace Day11.Models.Requests
{
    /// <summary>
    /// object containing data on what monkey is performing their turn
    /// </summary>
    public class MonkeyTurnRequest
    {
        /// <summary>
        /// the monkeys that are being adjusted
        /// </summary>
        public List<Monkey> Monkeys { get; set; } = new List<Monkey>();

        /// <summary>
        /// the id of the monkey that is taking their turn
        /// </summary>
        public int MonkeyID { get; set; } = 0;
    }
}
