using Day10.Models.Enums;
using Day10.Models.Requests;
using Day10.Models.Responses;
using System.Text;

namespace Day10.Services
{
    /// <summary>
    /// service for handling instructions
    /// </summary>
    public class InstructionProcessingService
    {
        /// <summary>
        /// method for processing instruction objects
        /// </summary>
        /// <param name="request">object containing data to be processed</param>
        /// <returns>object with results of processing instructions</returns>
        public async Task<InstructionProcessingResponse> ProcessInstructions(InstructionProcessingRequest request)
        {
            var response = new InstructionProcessingResponse();

            try
            {
                var checkCycleRequest = new CheckCycleRequest();

                int cycle = 0;
                int signalStrength = 1;
                int signalResponse = 0;

                foreach (var instruction in request.Instructions)
                {
                    cycle++;

                    checkCycleRequest.Cycle = cycle;
                    checkCycleRequest.SignalStrength = signalResponse;
                    checkCycleRequest.InstructionStrength = signalStrength;

                    var checkCycleResponse = await CheckCycle(checkCycleRequest);

                    if (checkCycleResponse is not { Status: StatusEnum.Success })
                    {
                        throw new Exception("Could not process check cycle");
                    }

                    signalResponse = checkCycleResponse.SignalStrength;

                    switch (instruction.Type)
                    {
                        case InstructionEnum.Noop:
                            break;

                        case InstructionEnum.Add:
                            cycle++;
                            signalStrength += instruction.Strength;
                            checkCycleRequest.Cycle = cycle;
                            checkCycleRequest.SignalStrength = signalResponse;
                            checkCycleResponse = await CheckCycle(checkCycleRequest);

                            if (checkCycleResponse is not { Status: StatusEnum.Success })
                            {
                                throw new Exception("Could not process check cycle");
                            }

                            signalResponse = checkCycleResponse.SignalStrength;
                            break;

                        default:
                            throw new Exception("Could not process instruction");
                    }
                }

                response.SignalStrength = signalResponse;

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

                return response;
            }
        }

        /// <summary>
        /// method for checking what cycle the system is on
        /// </summary>
        /// <param name="request">object containing the data regarding the cycle</param>
        /// <returns>object containing the result of the cycle check</returns>
        private async Task<CheckCycleResponse> CheckCycle(CheckCycleRequest request)
        {
            var response = new CheckCycleResponse();

            try
            {
                response.SignalStrength = request.SignalStrength;

                if (request.Cycle == 20)
                {
                    response.SignalStrength = request.InstructionStrength * request.Cycle;
                }
                else if ((request.Cycle - 20) % 40 == 0)
                {
                    response.SignalStrength += request.InstructionStrength * request.Cycle;
                }

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

                return response;
            }
        }

        /// <summary>
        /// method for checking the screen output
        /// </summary>
        /// <param name="request">the object containing instructions to get screen output</param>
        /// <returns>object with screen output</returns>
        public async Task<GetScreenResponse> GetScreenOutput(GetScreenRequest request)
        {
            var response = new GetScreenResponse();

            try
            {
                int cycle = 0;
                int signalStrength = 1;
                var screenDisplay = "";

                var screenCycleRequest = new CheckScreenCycleRequest();

                foreach (var instruction in request.Instructions)
                {
                    screenCycleRequest.Cycle = cycle;
                    screenCycleRequest.SignalStrength = signalStrength;
                    screenCycleRequest.ScreenDisplay = screenDisplay;

                    var checkScreenCycleResponse = await CheckScreenCycle(screenCycleRequest);

                    if (checkScreenCycleResponse is not { Status: StatusEnum.Success })
                    {
                        throw new Exception("Could not process screen check cycle");
                    }

                    screenDisplay = checkScreenCycleResponse.ScreenDisplay;
                    cycle = checkScreenCycleResponse.Cycle;

                    cycle++;

                    switch (instruction.Type)
                    {
                        case InstructionEnum.Noop:
                            break;

                        case InstructionEnum.Add:
                            screenCycleRequest.Cycle = cycle;
                            signalStrength += instruction.Strength;
                            screenCycleRequest.ScreenDisplay = screenDisplay;
                            checkScreenCycleResponse = await CheckScreenCycle(screenCycleRequest);

                            if (checkScreenCycleResponse is not { Status: StatusEnum.Success })
                            {
                                throw new Exception("Could not process screen check cycle");
                            }

                            screenDisplay = checkScreenCycleResponse.ScreenDisplay;
                            cycle = checkScreenCycleResponse.Cycle;

                            cycle++;

                            break;

                        default:
                            throw new Exception("Could not process instruction");
                    }
                }

                response.Output = screenDisplay;

                response.Status = StatusEnum.Success;

                return response;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

                return response;
            }
        }

        /// <summary>
        /// method for checking what cycle the system is on
        /// </summary>
        /// <param name="request">object containing the data regarding the cycle</param>
        /// <returns>object containing the result of the cycle check</returns>
        private async Task<CheckScreenCycleResponse> CheckScreenCycle(CheckScreenCycleRequest request)
        {
            var response = new CheckScreenCycleResponse();

            try
            {
                if (request.Cycle % 40 == 0)
                {
                    request.ScreenDisplay += "\r\n";
                    request.Cycle= 0;
                }

                if (request.Cycle - 2 < request.SignalStrength &&
                   request.Cycle + 2 > request.SignalStrength)
                {
                    request.ScreenDisplay += "#";
                }
                else
                {
                    request.ScreenDisplay += ".";
                }

                response.ScreenDisplay = request.ScreenDisplay;

                response.Status = StatusEnum.Success;
                response.Cycle = request.Cycle;

                return response;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

                return response;
            }
        }
    }
}
