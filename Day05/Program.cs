using Day05.Factories;
using Day05.Models.Enums;
using Day05.Models.Requests;
using Day05.Services;

StreamReader sr = File.OpenText(@"..\..\..\Data\Data.txt");
string data = sr.ReadToEnd();

//not the right way to impliment a factory, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _dataProcessingFactory = new DataProcessingFactory();

//not the right way to impliment a service, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _shipProcessingService = new ShipProcessingRequest();

try
{
    var cleanDataRequest = new CleanDataRequest
    {
        RawData = data
    };

    var cleanDataResponse = await _dataProcessingFactory.ProcessRawData(cleanDataRequest);

    if (cleanDataResponse is not { Status: StatusEnum.Success})
    {
        throw new Exception("Could not get clean data");
    }

    var shipProcessingRequest = new ProcessInstructionsRequest
    {
        CargoStacks = cleanDataResponse.CargoStacks,
        CargoStacksRevised = cleanDataResponse.CargoStacksRevised,
        Instructions = cleanDataResponse.Instructions
    };

    var shipProcessingResponse = await _shipProcessingService.ProcessInstructions(shipProcessingRequest);

    if (shipProcessingResponse is not { Status: StatusEnum.Success})
    {
        throw new Exception("Could not perform instructions on the ship cargo");
    }

    var topStacksRequest = new TopStackRequest
    {
        CargoStacks = shipProcessingResponse.CargoStacks,
        CargoStacksRevised = shipProcessingResponse.CargoStacksRevised
    };

    var topStacksResponse = await _shipProcessingService.GetTopStack(topStacksRequest);

    if (topStacksResponse is not { Status: StatusEnum.Success})
    {
        throw new Exception("Could not get the top crate from each stack");
    }

    Console.WriteLine("The top crate at each stack after instructions are processed is:");
    Console.WriteLine($"{topStacksResponse.StackResponse}");
    Console.WriteLine("The revised crates after recalcuation is:");
    Console.WriteLine($"{topStacksResponse.StackResponseRevised}");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();