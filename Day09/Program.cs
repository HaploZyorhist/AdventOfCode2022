using Day09.Factories;
using Day09.Models.Enums;
using Day09.Models.Requests;
using Day09.Services;

StreamReader sr = File.OpenText(@"..\..\..\Data\Data.txt");
string data = sr.ReadToEnd();

//not the right way to impliment a factory, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _dataProcessingFactory = new DataProcessingFactory();

//not the right way to impliment a service, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _instructionProcessingService = new InstructionProcessingService();

try
{
    var dataProcessRequest = new ProcessDataRequest
    {
        RawData = data,
    };

    var dataProcessResponse = await _dataProcessingFactory.ProcessData(dataProcessRequest);

    if (dataProcessResponse is not { Status: StatusEnum.Success})
    {
        throw new Exception("Could not process data");
    }

    var processInstructionRequest = new ProcessInstructionRequest
    {
        Instructions = dataProcessResponse.Instructions,
    };

    var processInstructionsResponse = await _instructionProcessingService.ProcessInstructions(processInstructionRequest);

    if (processInstructionsResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not process instructions");
    }

    Console.WriteLine($"The tail has visited {processInstructionsResponse.LocationsVisited.Count} locations");
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

Console.ReadKey();