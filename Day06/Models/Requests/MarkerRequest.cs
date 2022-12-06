namespace Day06.Models.Requests
{
    /// <summary>
    /// object for requesting the marker position
    /// </summary>
    public class MarkerRequest
    {
        /// <summary>
        /// string of raw data to be processed
        /// </summary>
        public string DataInput { get; set; } = string.Empty;
    }
}
