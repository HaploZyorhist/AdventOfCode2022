namespace Day11.Models.Requests
{
    /// <summary>
    /// object containing data needed to perform rounds
    /// </summary>
    public class PerformRoundsRequest
    {
        /// <summary>
        /// the number of rounds that are to be performed
        /// </summary>
        public int Rounds { get; set; } = 0;

        /// <summary>
        /// the monkeys that are active during the round
        /// </summary>
        public List<Monkey> Monkeys { get; set; } = new List<Monkey>();
    }
}
