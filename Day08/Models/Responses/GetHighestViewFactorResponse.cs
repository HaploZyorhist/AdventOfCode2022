using Day08.Models.Enums;

namespace Day08.Models.Responses
{
    /// <summary>
    /// object containing the results of the request
    /// </summary>
    public class GetHighestViewFactorResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// indicator of the view factor
        /// </summary>
        public int ViewFactor { get; set; } = 0;
    }
}
