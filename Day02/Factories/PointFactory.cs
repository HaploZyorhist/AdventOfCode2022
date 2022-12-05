using Day02.Models;
using Day02.Models.Enums;
using Day02.Models.Requests;
using Day02.Models.Responses;
using System.Xml.Schema;

namespace Day02.Factories
{
    /// <summary>
    /// factory for calculating points made for individual games
    /// </summary>
    public class PointFactory
    {
        /// <summary>
        /// method for processing the points the players get for what they chose
        /// </summary>
        /// <param name="request">object containing the details of the game</param>
        /// <returns>total points earned for the player and opponent</returns>
        public async Task<PlayerPointResponse> ProcessPointsForChoice(PlayerPointRequest request)
        {
            var response = new PlayerPointResponse();
            try
            {
                // get player's points for what they chose
                response.PlayerPoints += await GetPointForChoice(request.GameChoices.PlayerChoice);

                // get the opponents points for what they chose
                response.OpponentPoints += await GetPointForChoice(request.GameChoices.OpponentChoice);

                var winPoints = await GetWinPoints(request.GameChoices);

                response.PlayerPoints += winPoints;
                response.OpponentPoints += 6 - winPoints;

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
        /// private method for getting points based on what the person chose
        /// </summary>
        /// <param name="request">the choice the player made</param>
        /// <returns>the number for their choice</returns>
        private async Task<int> GetPointForChoice(ChoiceEnum request)
        {
            try
            {
                switch (request)
                {
                    case ChoiceEnum.Rock:
                        return 1;

                    case ChoiceEnum.Paper:
                        return 2;

                    case ChoiceEnum.Scissors:
                        return 3;

                    default:
                        throw new Exception("Points could not be calculated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// method for getting points based on win/loss/draw
        /// </summary>
        /// <param name="request">object containing the details of the game</param>
        /// <returns>the number of points earned by the player</returns>
        private async Task<int> GetWinPoints(GameObject request)
        {
            try
            {
                switch (request.OpponentChoice)
                {
                    case ChoiceEnum.Rock:
                        switch (request.PlayerChoice)
                        {
                            case ChoiceEnum.Rock:
                                return 3;

                            case ChoiceEnum.Paper:
                                return 6;

                            case ChoiceEnum.Scissors:
                                return 0;

                            default:
                                throw new Exception("Cannot calculate win");
                        }

                    case ChoiceEnum.Paper:
                        switch (request.PlayerChoice)
                        {
                            case ChoiceEnum.Rock:
                                return 0;

                            case ChoiceEnum.Paper:
                                return 3;

                            case ChoiceEnum.Scissors:
                                return 6;

                            default:
                                throw new Exception("Cannot calculate win");
                        }

                    case ChoiceEnum.Scissors:
                        switch (request.PlayerChoice)
                        {
                            case ChoiceEnum.Rock:
                                return 6;

                            case ChoiceEnum.Paper:
                                return 0;

                            case ChoiceEnum.Scissors:
                                return 3;

                            default:
                                throw new Exception("Cannot calculate win");
                        }

                    default:
                        throw new Exception("Cannot process a win or loss");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
