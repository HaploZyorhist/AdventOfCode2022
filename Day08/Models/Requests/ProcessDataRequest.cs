namespace Day08.Models.Requests
{
    /// <summary>
    /// object for requesting data be processed
    /// </summary>
    public class ProcessDataRequest
    {
        /// <summary>
        /// the raw data to be processed
        /// </summary>
        public string RawData { get; set; } = string.Empty;
    }
}
