using System.Numerics;

namespace Day08.Models.Requests
{
    /// <summary>
    /// object for requesting the check of visibility
    /// </summary>
    public class CheckVisibilityRequest
    {
        /// <summary>
        /// the tree being checked
        /// </summary>
        public Tree Tree { get; set; } = new Tree();

        /// <summary>
        /// the trees that are being examined
        /// </summary>
        public List<Tree> Trees { get; set; } = new List<Tree>();
    }
}
