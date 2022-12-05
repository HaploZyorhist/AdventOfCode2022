namespace Day02.Models.Requests
{
    /// <summary>
    /// object containing data to be processed by the game object factory
    /// </summary>
    public class GOFactoryRequest
    {
        /// <summary>
        /// a list of games with raw data
        /// </summary>
        public List<string> Games { get; set; } = new List<string>();
    }
}
