using Day08.Models.Enums;

namespace Day08.Models.Responses
{
    /// <summary>
    /// object containing the details of the view factor for a tree
    /// </summary>
    public class GetViewFactorResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// the view factor of the tree
        /// </summary>
        public int Factor { get; set; } = 0;
    }
}
