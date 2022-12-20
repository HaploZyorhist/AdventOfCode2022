namespace Day09.Models.Requests
{
    /// <summary>
    /// object containing raw data for processing
    /// </summary>
    public class ProcessDataRequest
    {
        /// <summary>
        /// the raw data to be processed
        /// </summary>
        public string RawData { get; set; } = string.Empty;
    }
}
