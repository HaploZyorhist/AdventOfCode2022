using Day08.Models.Enums;

namespace Day08.Models.Responses
{
    /// <summary>
    /// object showing the results of checking the trees
    /// </summary>
    public class CheckVisibilityResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// indicator of whether the tree is visible
        /// </summary>
        public bool Visible { get; set; } = false;
    }
}
