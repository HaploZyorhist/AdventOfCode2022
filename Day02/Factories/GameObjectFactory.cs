using Day02.Models;
using Day02.Models.Enums;
using Day02.Models.Requests;
using Day02.Models.Responses;

namespace Day02.Factories
{
    /// <summary>
    /// factory for processing game object
    /// </summary>
    public class GameObjectFactory
    {
        /// <summary>
        /// method for preparing game objects
        /// </summary>
        /// <param name="request">object containing raw data on games</param>
        /// <returns>object containing cleaned data on games played</returns>
        public async Task<GOFactoryResponse> PrepGames(GOFactoryRequest request)
        {
            var response = new GOFactoryResponse();

            try
            {
                foreach (var game in request.Games)
                {
                    var gameObject = new GameObject();
                    var choices = game.Split(' ');

                    // get opponent choice
                    switch (choices[0].ToLower())
                    {
                        case "a":
                            gameObject.OpponentChoice = ChoiceEnum.Rock;
                            break;

                        case "b":
                            gameObject.OpponentChoice = ChoiceEnum.Paper;
                            break;

                        case "c":
                            gameObject.OpponentChoice = ChoiceEnum.Scissors;
                            break;

                        default:
                            throw new Exception("Choice not within range");
                    }

                    //part 1
                    // get player choice
                    //switch (choices[1].ToLower())
                    //{
                    //    case "x":
                    //        gameObject.PlayerChoice = ChoiceEnum.Rock;
                    //        break;

                    //    case "y":
                    //        gameObject.PlayerChoice = ChoiceEnum.Paper;
                    //        break;

                    //    case "z":
                    //        gameObject.PlayerChoice = ChoiceEnum.Scissors;
                    //        break;

                    //    default:
                    //        throw new Exception("Choice not within range");
                    //}

                    //part 2
                    // get player choice
                    var playerChoiceRequest = new GetPlayerChoiceRequest
                    {
                        OpponentChoice = gameObject.OpponentChoice,
                        VictoryCommand = choices[1].ToLower()
                    };

                    var playerChoiceResponse = await GetPlayerChoice(playerChoiceRequest);

                    if (playerChoiceResponse is not { Status: StatusEnum.Success})
                    {
                        throw new Exception("could not get player choice");
                    }

                    gameObject.PlayerChoice = playerChoiceResponse.Choice;

                    response.Games.Add(gameObject);
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
        /// private method for generating player choice
        /// </summary>
        /// <param name="request">object containing data from instructions</param>
        /// <returns>the player's choice</returns>
        private async Task<GetPlayerChoiceResponse> GetPlayerChoice(GetPlayerChoiceRequest request)
        {
            var response = new GetPlayerChoiceResponse();
            try
            {
                switch (request.VictoryCommand)
                {
                    case "x":
                        switch (request.OpponentChoice)
                        {
                            case ChoiceEnum.Rock:
                                response.Choice = ChoiceEnum.Scissors;
                                break;

                            case ChoiceEnum.Paper:
                                response.Choice = ChoiceEnum.Rock;
                                break;

                            case ChoiceEnum.Scissors:
                                response.Choice = ChoiceEnum.Paper;
                                break;

                            default:
                                throw new Exception("Could not find a win or lose");
                        }
                        break;

                    case "y":
                        switch (request.OpponentChoice)
                        {
                            case ChoiceEnum.Rock:
                                response.Choice = ChoiceEnum.Rock;
                                break;

                            case ChoiceEnum.Paper:
                                response.Choice = ChoiceEnum.Paper;
                                break;

                            case ChoiceEnum.Scissors:
                                response.Choice = ChoiceEnum.Scissors;
                                break;

                            default:
                                throw new Exception("Could not find a win or lose");
                        }
                        break;

                    case "z":
                        switch (request.OpponentChoice)
                        {
                            case ChoiceEnum.Rock:
                                response.Choice = ChoiceEnum.Paper;
                                break;

                            case ChoiceEnum.Paper:
                                response.Choice = ChoiceEnum.Scissors;
                                break;

                            case ChoiceEnum.Scissors:
                                response.Choice = ChoiceEnum.Rock;
                                break;

                            default:
                                throw new Exception("Could not find a win or lose");
                        }
                        break;

                    default:
                        throw new Exception("Code is broken, should not reach here");
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
    }
}
