using Day02.Models.Enums;

namespace Day02.Models.Responses
{
    /// <summary>
    /// object containing the data about the games that is being returned
    /// </summary>
    public class GOFactoryResponse
    {
        /// <summary>
        /// object containing status of the request
        /// default status to failure
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// list of game objects from raw data
        /// </summary>
        public List<GameObject> Games { get; set; } = new List<GameObject>();
    }
}
