namespace Day10.Models.Requests
{
    /// <summary>
    /// reqeust for getting data processed
    /// </summary>
    public class DataProcessingRequest
    {
        /// <summary>
        /// the raw data to be processed
        /// </summary>
        public string RawData { get; set; } = string.Empty;
    }
}
