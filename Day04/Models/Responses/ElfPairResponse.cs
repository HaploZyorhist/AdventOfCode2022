using Day04.Models.Enums;

namespace Day04.Models.Responses
{
    /// <summary>
    /// object for handling the response of creating elf pairs
    /// </summary>
    public class ElfPairResponse
    {
        /// <summary>
        /// object stating the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// a list of the pairs of elves
        /// </summary>
        public List<ElfPairs> Pairs { get; set; } = new List<ElfPairs>();
    }
}
