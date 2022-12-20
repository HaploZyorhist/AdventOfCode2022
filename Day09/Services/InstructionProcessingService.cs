using Day09.Models.Enums;
using Day09.Models.Requests;
using Day09.Models.Responses;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace Day09.Services
{
    /// <summary>
    /// service for handling instructions passed in
    /// </summary>
    public class InstructionProcessingService
    {
        public async Task<ProcessInstructionResponse> ProcessInstructions(ProcessInstructionRequest request)
        {
            var response = new ProcessInstructionResponse();

            try
            {
                var totalKnots = 10;

                var knotLocations = new List<Vector2>();

                for (var i = 0; i < totalKnots; i++)
                {
                    var knot = Vector2.Zero;
                    knotLocations.Add(knot);
                }

                var tailLocationsVisited = new Dictionary<Vector2, int>();

                foreach (var instruction in request.Instructions)
                {
                    var moveRequest = new MoveRequest
                    {
                        KnotLocations = knotLocations,
                        Instruction = instruction,
                        TailLocationsVisited = tailLocationsVisited
                    };

                    var moveResponse = await MoveRope(moveRequest);

                    if (moveResponse is not { Status: StatusEnum.Success })
                    {
                        throw new Exception("Failed to move rope properly");
                    }

                    knotLocations = moveResponse.KnotLocations;

                    tailLocationsVisited = moveResponse.LocationsTailVisited;
                }

                response.LocationsVisited = tailLocationsVisited;

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
        /// private method for moving the rope and tracking the location the rope has visited
        /// </summary>
        /// <param name="request">object containing the data for how to move</param>
        /// <returns>the locations the rope occupies and the locations the tail has visited</returns>
        private async Task<MoveResponse> MoveRope(MoveRequest request)
        {
            var response = new MoveResponse();

            try
            {
                var headLocation = request.KnotLocations[0];
                var locationsTailVisited = request.TailLocationsVisited;
                var knotLocations = request.KnotLocations;

                for (var space = 0; space < request.Instruction.Spaces; space++)
                {
                    switch (request.Instruction.Direction)
                    {
                        case DirectionEnum.Up:
                            headLocation.Y++;
                            break;

                        case DirectionEnum.Down:
                            headLocation.Y--;
                            break;

                        case DirectionEnum.Right:
                            headLocation.X++;
                            break;

                        case DirectionEnum.Left:
                            headLocation.X--;
                            break;

                        default:
                            throw new Exception("Could not find a direction to move head of rope");
                    }

                    knotLocations[0] = headLocation;

                    for (int i = 1; i < request.KnotLocations.Count; i++)
                    {
                        var leaderLocation = request.KnotLocations[i - 1];
                        var tailLocation = request.KnotLocations[i];

                        var moveTailRequest = new MoveTailRequest
                        {
                            LeaderLocation = leaderLocation,
                            TailLocation = tailLocation,
                            Direction = request.Instruction.Direction,
                        };

                        var moveTailResponse = await MoveTail(moveTailRequest);

                        if (moveTailResponse is not { Status: StatusEnum.Success })
                        {
                            throw new Exception("Could not move tail");
                        }

                        tailLocation = moveTailResponse.TailLocation;

                        if (i == request.KnotLocations.Count - 1)
                        {
                            if (!locationsTailVisited.TryAdd(tailLocation, 1) &&
                                moveTailResponse.TailLocation != tailLocation)
                            {
                                locationsTailVisited[tailLocation]++;
                            }
                        }

                        knotLocations[i] = tailLocation;
                    }

                }

                response.KnotLocations = knotLocations;

                response.LocationsTailVisited = locationsTailVisited;

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return response;
            }
        }

        private async Task<MoveTailResponse> MoveTail(MoveTailRequest request)
        {
            var response = new MoveTailResponse();

            var tailLocation = request.TailLocation;

            try
            {
                if ((Math.Abs(request.LeaderLocation.Y - request.TailLocation.Y) > 1 &&
                    Math.Abs(request.LeaderLocation.X - request.TailLocation.X) > 1) ||
                    (Math.Abs(request.TailLocation.Y - request.LeaderLocation.Y) > 1 &&
                    Math.Abs(request.TailLocation.X - request.LeaderLocation.X) > 1))
                {
                    tailLocation.X = (request.LeaderLocation.X + request.TailLocation.X) / 2;
                    tailLocation.Y = (request.LeaderLocation.Y + request.TailLocation.Y) / 2;
                }
                else if (Math.Abs(request.LeaderLocation.Y - request.TailLocation.Y) > 1 ||
                         Math.Abs(request.TailLocation.Y - request.LeaderLocation.Y) > 1)
                {
                    tailLocation.Y = (request.LeaderLocation.Y + request.TailLocation.Y) / 2;
                    tailLocation.X = request.LeaderLocation.X;
                }
                else if (Math.Abs(request.LeaderLocation.X - request.TailLocation.X) > 1 ||
                         Math.Abs(request.TailLocation.X - request.LeaderLocation.X) > 1)
                {
                    tailLocation.X = (request.LeaderLocation.X + request.TailLocation.X) / 2;
                    tailLocation.Y = request.LeaderLocation.Y;
                }

                response.TailLocation = tailLocation;

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
