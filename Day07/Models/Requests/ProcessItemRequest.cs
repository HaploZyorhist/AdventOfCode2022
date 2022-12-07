namespace Day07.Models.Requests
{
    /// <summary>
    /// object containing the details of the item
    /// </summary>
    public class ProcessItemRequest
    {
        /// <summary>
        /// the raw data for the item details
        /// </summary>
        public string ItemData { get; set; } = string.Empty;

        /// <summary>
        /// the parent that the items are assigned to
        /// </summary>
        public SystemDirectory ParentDirectory { get; set; } = new SystemDirectory();
    }
}
