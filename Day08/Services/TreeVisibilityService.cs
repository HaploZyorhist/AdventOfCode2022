using Day08.Models;
using Day08.Models.Enums;
using Day08.Models.Requests;
using Day08.Models.Responses;
using System.Numerics;

namespace Day08.Services
{
    /// <summary>
    /// service for handling tree visibility
    /// </summary>
    public class TreeVisibilityService
    {
        /// <summary>
        /// method for making the visibility of trees
        /// </summary>
        /// <param name="request">object containing data about the trees to be processed</param>
        /// <returns>trees that have been processed for their visibility</returns>
        public async Task<TreeVisibilityResponse> MarkVisibleTrees(TreeVisibilityRequest request)
        {
            var response = new TreeVisibilityResponse();

            try
            {
                var trees = request.Trees;

                foreach (var tree in request.Trees)
                {
                    var checkVisibiltyRequest = new CheckVisibilityRequest
                    {
                        Tree = tree,
                        Trees = trees
                    };

                    var checkVisibilityResponse = await CheckVisibility(checkVisibiltyRequest);

                    if (checkVisibilityResponse is not { Status: StatusEnum.Success })
                    {
                        throw new Exception("Could not properly check visibility");
                    }

                    var treeMarker = trees.Where(x => x.Coords == tree.Coords).First();

                    treeMarker.Visible = checkVisibilityResponse.Visible;
                }

                response.Trees = trees;

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return response;
            }
        }

        /// <summary>
        /// method for getting the highest view factor of trees
        /// </summary>
        /// <param name="request">object containing data on the trees to be examined</param>
        /// <returns>object indicating the highest view factor</returns>
        public async Task<GetHighestViewFactorResponse> GetHighestViewFactor(GetHighestViewFactorRequest request)
        {
            var response = new GetHighestViewFactorResponse();

            try
            {
                var highestFactor = 0;

                foreach (var tree in request.Trees)
                {
                    var getViewFactorRequest = new GetViewFactorRequest
                    {
                        Tree = tree,
                        Trees = request.Trees
                    };

                    var getViewFactorResponse = await GetViewFactor(getViewFactorRequest);

                    if (getViewFactorResponse is not { Status: StatusEnum.Success })
                    {
                        throw new Exception($"Could not get view factor for {tree.Coords}");
                    }

                    if (getViewFactorResponse.Factor > highestFactor)
                    {
                        highestFactor = getViewFactorResponse.Factor;
                    }
                }

                response.ViewFactor = highestFactor;

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return response;
            }
        }

        /// <summary>
        /// checks the tree's visibility
        /// </summary>
        /// <param name="request">object stating what is being checked</param>
        /// <returns>object showing the results of the check</returns>
        private async Task<CheckVisibilityResponse> CheckVisibility(CheckVisibilityRequest request)
        {
            var response = new CheckVisibilityResponse();

            try
            {
                var treeHeight = request.Tree.Height;
                var coords = request.Tree.Coords;

                var horizontalTrees = request.Trees.Where(x => x.Coords.Y == coords.Y).ToList();
                var verticalTrees = request.Trees.Where(x => x.Coords.X == coords.X).ToList();

                var getTallerTreesFromTop = verticalTrees.Where(x => x.Coords.Y < coords.Y)
                    .OrderByDescending(x => x.Height).FirstOrDefault()?.Height;

                if (getTallerTreesFromTop is null ||
                    getTallerTreesFromTop < treeHeight)
                {
                    response.Status = StatusEnum.Success;
                    response.Visible = true;
                    return response;
                }

                var getTallerTreesFromBottom = verticalTrees.Where(x => x.Coords.Y > coords.Y)
                    .OrderByDescending(x => x.Height).FirstOrDefault()?.Height;

                if (getTallerTreesFromBottom is null ||
                    getTallerTreesFromBottom < treeHeight)
                {
                    response.Status = StatusEnum.Success;
                    response.Visible = true;
                    return response;
                }

                var getTallerTreesFromLeft = horizontalTrees.Where(x => x.Coords.X < coords.X)
                    .OrderByDescending(x => x.Height).FirstOrDefault()?.Height;

                if (getTallerTreesFromLeft is null ||
                    getTallerTreesFromLeft < treeHeight)
                {
                    response.Status = StatusEnum.Success;
                    response.Visible = true;
                    return response;
                }

                var getTallerTreesFromRight = horizontalTrees.Where(x => x.Coords.X > coords.X)
                    .OrderByDescending(x => x.Height).FirstOrDefault()?.Height;

                if (getTallerTreesFromRight is null ||
                    getTallerTreesFromRight < treeHeight)
                {
                    response.Status = StatusEnum.Success;
                    response.Visible = true;
                    return response;
                }

                response.Status = StatusEnum.Success;
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return response;
            }
        }

        /// <summary>
        /// method for getting the view factor for the tree
        /// </summary>
        /// <param name="request">object containing data on trees to be considered</param>
        /// <returns>object containing the view factor of the tree</returns>
        private async Task<GetViewFactorResponse> GetViewFactor(GetViewFactorRequest request)
        {
            var response = new GetViewFactorResponse();

            try
            {
                var measuredTree = request.Tree;
                var coords = request.Tree.Coords;
                var treeHeight = request.Tree.Height;

                int upFactor = 0;
                int downFactor = 0;
                int leftFactor = 0;
                int rightFactor = 0;

                int upHeight = 0;
                int downHeight = 0;
                int leftHeight = 0;
                int rightHeight = 0;

                var horizontalTrees = request.Trees.Where(x => x.Coords.Y == coords.Y).ToList();
                var verticalTrees = request.Trees.Where(x => x.Coords.X == coords.X).ToList();

                var upTrees = verticalTrees.Where(x => x.Coords.Y < coords.Y).OrderByDescending(x => x.Coords.Y).ToList();
                var downTrees = verticalTrees.Where(x => x.Coords.Y > coords.Y).OrderBy(x => x.Coords.Y).ToList();
                var leftTrees = horizontalTrees.Where(x => x.Coords.X < coords.X).OrderByDescending(x => x.Coords.X).ToList();
                var rightTrees = horizontalTrees.Where(x => x.Coords.X > coords.X).OrderBy(x => x.Coords.X).ToList();

                foreach (var tree in upTrees)
                {
                    upFactor++;
                    upHeight = tree.Height;

                    if (upHeight >= measuredTree.Height)
                    {
                        break;
                    }
                }

                foreach (var tree in downTrees)
                {
                    downFactor++;
                    downHeight = tree.Height;

                    if (downHeight >= measuredTree.Height)
                    {
                        break;
                    }
                }

                foreach (var tree in leftTrees)
                {
                    leftFactor++;
                    leftHeight = tree.Height;

                    if (leftHeight >= measuredTree.Height)
                    {
                        break;
                    }
                }

                foreach (var tree in rightTrees)
                {
                    rightFactor++;
                    rightHeight = tree.Height;

                    if (rightHeight >= measuredTree.Height)
                    {
                        break;
                    }
                }

                var factor = upFactor * downFactor * leftFactor * rightFactor;
                response.Factor = factor;

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return response;
            }
        }
    }
}
