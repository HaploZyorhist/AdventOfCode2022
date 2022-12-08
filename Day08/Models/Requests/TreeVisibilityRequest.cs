namespace Day08.Models.Requests
{
    /// <summary>
    /// request for handling tree visibility
    /// </summary>
    public class TreeVisibilityRequest
    {
        /// <summary>
        /// number of rows of trees
        /// </summary>
        public int TreeRows { get; set; } = 0;

        /// <summary>
        /// number of columns of trees
        /// </summary>
        public int TreeColumns { get; set; } = 0;

        /// <summary>
        /// the trees 
        /// </summary>
        public List<Tree> Trees { get; set; } = new List<Tree>();
    }
}
