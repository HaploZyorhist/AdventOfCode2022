using Day11.Factories;
using Day11.Models.Enums;
using Day11.Models.Requests;
using Day11.Services;

StreamReader sr = File.OpenText(@"..\..\..\Data\Data.txt");
string data = sr.ReadToEnd();

//not the right way to impliment a factory, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _dataProcessingFactory = new DataProcessingFactory();

//not the right way to impliment a service, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _turnService = new TurnService();

try
{
    var rounds = 10000;

    var dataRequest = new ProcessDataRequest
    {
        RawData = data
    };

    var dataResponse = await _dataProcessingFactory.ProcessRawData(dataRequest);

    if (dataResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not process raw data");
    }

    var performRoundsRequest = new PerformRoundsRequest
    {
        Rounds = rounds,
        Monkeys = dataResponse.MonkeyList
    };

    var performRoundsResponse = await _turnService.PerformRounds(performRoundsRequest);

    if (performRoundsResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not perform rounds as expected");
    }

    var top2Monkeys = performRoundsResponse.Monkeys.OrderByDescending(x => x.Inspections).Take(2).ToList();

    ulong monkeyBusiness = (ulong)top2Monkeys[0].Inspections * (ulong)top2Monkeys[1].Inspections;

    Console.WriteLine($"The total Monkey Business for the game is {monkeyBusiness}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();