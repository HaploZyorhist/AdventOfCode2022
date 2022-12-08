using System.Numerics;

namespace Day08.Models
{
    /// <summary>
    /// object containing data about a tree
    /// </summary>
    public class Tree
    {
        /// <summary>
        /// the coordinates of the tree
        /// </summary>
        public Vector2 Coords { get; set; } = new Vector2();

        /// <summary>
        /// the height of the tree
        /// </summary>
        public int Height { get; set; } = 0;

        /// <summary>
        /// indicator of whether the tree is visible
        /// </summary>
        public bool Visible { get; set; } = false;
    }
}
