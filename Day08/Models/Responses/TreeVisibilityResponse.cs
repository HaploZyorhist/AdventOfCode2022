using Day08.Models.Enums;

namespace Day08.Models.Responses
{
    /// <summary>
    /// response from getting visibility of trees
    /// </summary>
    public class TreeVisibilityResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// the trees that were processed
        /// </summary>
        public List<Tree> Trees { get; set; } = new List<Tree>();
    }
}
