using Day08.Models.Enums;

namespace Day08.Models.Responses
{
    /// <summary>
    /// return object containing the data and status of the request
    /// </summary>
    public class ProcessDataResponse
    {
        /// <summary>
        /// the status of the request
        /// </summary>
        public StatusEnum Status { get; set; } = StatusEnum.Failure;

        /// <summary>
        /// the tree objects that are represented by the data
        /// </summary>
        public List<Tree> Trees { get; set; } = new List<Tree>();

        /// <summary>
        /// the number of rows of trees
        /// </summary>
        public int TreeRows { get; set; } = 0;

        /// <summary>
        /// the number of columns of trees
        /// </summary>
        public int TreeColumns { get; set; } = 0;
    }
}
