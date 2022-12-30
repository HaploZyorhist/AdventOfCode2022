using Day11.Models;
using Day11.Models.Enums;
using Day11.Models.Requests;
using Day11.Models.Responses;
using static System.Net.Mime.MediaTypeNames;

namespace Day11.Services
{
    /// <summary>
    /// service for 
    /// </summary>
    public class TurnService
    {
        /// <summary>
        /// mehtod for performing the rounds of tossing
        /// </summary>
        /// <param name="request">object containing the data of the monkeys being tracked</param>
        /// <returns>object containing the results of the rounds performed</returns>
        public async Task<ActiveMonkeysResponse> PerformRounds(PerformRoundsRequest request)
        {
            var response = new ActiveMonkeysResponse();

            try
            {
                List<Monkey> monkeys = new List<Monkey>();
                monkeys.AddRange(request.Monkeys);

                for (var i = 0; i < request.Rounds; i++)
                {
                    for (var x = 0; x < monkeys.Count; x++)
                    {
                        var performTurnRequest = new MonkeyTurnRequest
                        {
                            Monkeys = monkeys,
                            MonkeyID = x
                        };

                        var performTurnResponse = await PerformMonkeyTurn(performTurnRequest);

                        if (performTurnResponse is not { Status: StatusEnum.Success })
                        {
                            throw new Exception("Could not perform turns properly");
                        }

                        monkeys = performTurnResponse.Monkeys;
                    }
                }

                response.Monkeys = monkeys;

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
        /// method for performing a monkeys turn
        /// </summary>
        /// <param name="request">object containing data for the monkey who's turn is to be performed</param>
        /// <returns>object containing the state of the monkeys after the turn was performed</returns>
        public async Task<MonkeyTurnResponse> PerformMonkeyTurn(MonkeyTurnRequest request)
        {
            var response = new MonkeyTurnResponse();

            try
            {
                var thisMonkey = request.Monkeys.Where(x => x.MonkeyName == request.MonkeyID).FirstOrDefault();

                if (thisMonkey == null)
                {
                    throw new Exception("Could not find the proper monkey");
                }

                List<ulong> items = new();
                items.AddRange(thisMonkey.Items);

                foreach (var item in items)
                {
                    var updateWorryRequest = new ChangeWorryRequest
                    {
                        Operator = thisMonkey.WorryOperator,
                        Worry = item,
                        WorryAdjustment = thisMonkey.WorryFactor
                    };

                    var updateWorryResponse = await thisMonkey.ChangeWorry(updateWorryRequest);

                    if (updateWorryResponse is not { Status: StatusEnum.Success })
                    {
                        throw new Exception("Could not properly update worry of item");
                    }

                    var thisItem = thisMonkey.Items.Where(x => x == item).First();

                    // part 1
                    // var updatedItem = updateWorryResponse.Worry / 3;

                    // part 2
                    var updatedItem = updateWorryResponse.Worry;

                    var testWorryRequest = new TestWorryRequest
                    {
                        TestValue = thisMonkey.Test,
                        WorryValue = updatedItem,
                    };

                    var testWorryResponse = await thisMonkey.TestWorry(testWorryRequest);

                    if (testWorryResponse is not { Status: StatusEnum.Success })
                    {
                        throw new Exception("Could not properly test worry");
                    }

                    thisMonkey.Items.Remove(thisItem);

                    // part 2
                    //updatedItem %= 96577; // test 
                    updatedItem %= 9699690; // actual
                    //these values are found by multiplying all of the numbers that the monkeys use
                    //to test together

                    if (testWorryResponse.Result == true)
                    {
                        var trueMonkey = request.Monkeys.Where(x => x.MonkeyName == thisMonkey.TestTrue).First();

                        trueMonkey.Items.Add(updatedItem);
                        continue;
                    }

                    var falseMonkey = request.Monkeys.Where(x => x.MonkeyName == thisMonkey.TestFalse).First();

                    falseMonkey.Items.Add(updatedItem);
                    continue;
                }

                response.Monkeys = request.Monkeys;

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
