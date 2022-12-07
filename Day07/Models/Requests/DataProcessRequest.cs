namespace Day07.Models.Requests
{
    /// <summary>
    /// object containing raw data to be processed
    /// </summary>
    public class DataProcessRequest
    {
        /// <summary>
        /// the raw data to be processed
        /// </summary>
        public string RawData { get; set; } = string.Empty;
    }
}
