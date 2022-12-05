namespace Day04.Models.Requests
{
    /// <summary>
    /// object containing details on the request for creating elf pairs
    /// </summary>
    public class ElfPairRequest
    {
        /// <summary>
        /// object containing raw data on the elf pairs
        /// </summary>
        public List<string> ElfPairData { get; set; } = new List<string>();
    }
}
