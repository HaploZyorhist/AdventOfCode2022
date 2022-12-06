using Day06.Models.Enums;

namespace Day06.Models.Responses
{
    /// <summary>
    /// object containing the results of the finding marker request
    /// </summary>
    public class MarkerResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failed;

        /// <summary>
        /// the position of the marker
        /// </summary>
        public int MarkerPosition { get; set; } = 0;
    }
}
