namespace Day08.Models.Requests
{
    /// <summary>
    /// object containing details of the request
    /// </summary>
    public class GetHighestViewFactorRequest
    {
        /// <summary>
        /// trees being examined
        /// </summary>
        public List<Tree> Trees { get; set; } = new List<Tree>();
    }
}
