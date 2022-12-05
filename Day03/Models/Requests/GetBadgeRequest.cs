namespace Day03.Models.Requests
{
    /// <summary>
    /// request object containing the data for getting badges
    /// </summary>
    public class GetBadgeRequest
    {
        /// <summary>
        /// the ruck sacks that are to be compared
        /// </summary>
        public List<RuckSack> Rucks { get; set; } = new List<RuckSack>();
    }
}
