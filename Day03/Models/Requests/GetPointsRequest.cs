using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03.Models.Requests
{
    /// <summary>
    /// request object for requesting total points for duplicate items
    /// </summary>
    public class GetPointsRequest
    {
        /// <summary>
        /// a list of the items that were duplicated
        /// </summary>
        public List<char> Items { get; set; } = new List<char>();
    }
}
