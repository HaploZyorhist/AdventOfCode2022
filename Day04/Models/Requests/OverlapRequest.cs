namespace Day04.Models.Requests
{
    /// <summary>
    /// object for requesting overlapped elves
    /// </summary>
    public class OverlapRequest
    {
        /// <summary>
        /// the list of elf pairs
        /// </summary>
        public List<ElfPairs> ElfPairs { get; set;} = new List<ElfPairs>();
    }
}
