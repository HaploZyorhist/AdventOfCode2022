namespace Day03.Models.Requests
{
    /// <summary>
    /// object for requesting the contents of the rucksack
    /// </summary>
    public class GetCompartmentsRequest
    {
        /// <summary>
        /// raw data for the contents of the ruck sack
        /// </summary>
        public List<string> SackData { get; set; }
    }
}
