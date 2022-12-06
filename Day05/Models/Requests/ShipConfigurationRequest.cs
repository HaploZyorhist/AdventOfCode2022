namespace Day05.Models.Requests
{
    /// <summary>
    /// object containing the raw ship configuration data
    /// </summary>
    public class ShipConfigurationRequest
    {
        /// <summary>
        /// the raw data about the ship's configuration
        /// </summary>
        public string RawConfiguration { get; set; } = string.Empty;
    }
}
