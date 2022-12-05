using Day03.Models.Enums;

namespace Day03.Models.Responses
{
    /// <summary>
    /// response of duplicate items
    /// </summary>
    public class GetDuplicateResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// a list of the items that were duplicated
        /// </summary>
        public List<char> Duplicates { get; set; } = new List<char>();
    }
}
