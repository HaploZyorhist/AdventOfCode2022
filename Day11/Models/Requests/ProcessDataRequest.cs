namespace Day11.Models.Requests
{
    /// <summary>
    /// object containing data to be processed
    /// </summary>
    public class ProcessDataRequest
    {
        /// <summary>
        /// the raw data to be processed
        /// </summary>
        public string RawData { get; set; } = string.Empty;
    }
}
