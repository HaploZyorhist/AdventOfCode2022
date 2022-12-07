namespace Day07.Models.Requests
{
    /// <summary>
    /// object for requesting data be read
    /// </summary>
    public class ReadDataRequest
    {
        /// <summary>
        /// the data to be read
        /// </summary>
        public string Item { get; set; } = string.Empty;

        /// <summary>
        /// the directory object that the items are being processed for
        /// </summary>
        public SystemDirectory CurrentDirectory { get; set; } = new SystemDirectory();
    }
}
