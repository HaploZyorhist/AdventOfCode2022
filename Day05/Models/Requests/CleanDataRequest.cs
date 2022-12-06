namespace Day05.Models.Requests
{
    /// <summary>
    /// object for requesting cleaned up data
    /// </summary>
    public class CleanDataRequest
    {
        /// <summary>
        /// the raw data to be processed
        /// </summary>
        public string RawData { get; set; } = string.Empty;
    }
}
