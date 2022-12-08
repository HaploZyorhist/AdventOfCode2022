namespace Day08.Models.Requests
{
    /// <summary>
    /// object containing details on request to get view factor
    /// </summary>
    public class GetViewFactorRequest
    {
        /// <summary>
        /// tree being considered
        /// </summary>
        public Tree Tree { get; set; } = new Tree();

        /// <summary>
        /// the trees that are being conidered
        /// </summary>
        public List<Tree> Trees { get; set; } = new List<Tree>();
    }
}
