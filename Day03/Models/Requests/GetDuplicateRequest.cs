namespace Day03.Models.Requests
{
    /// <summary>
    /// request object for getting duplicate items
    /// </summary>
    public class GetDuplicateRequest
    {
        /// <summary>
        /// the list of rucks that are being searched for duplicate items
        /// </summary>
        public List<RuckSack> RuckSacks { get; set; } = new List<RuckSack>();
    }
}
