namespace Day06.Models.Requests
{
    /// <summary>
    /// object for requesting the marker of the message
    /// </summary>
    public class MessageRequest
    {
        /// <summary>
        /// string of raw data to be processed
        /// </summary>
        public string DataInput { get; set; } = string.Empty;
    }
}
