using Day10.Factories;
using Day10.Models.Enums;
using Day10.Models.Requests;
using Day10.Services;

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
    var dataProcessRequest = new DataProcessingRequest
    {
        RawData = data,
    };

    var dataProcessResponse = await _dataProcessingFactory.ProcessData(dataProcessRequest);

    if (dataProcessResponse is not { Status: StatusEnum.Success})
    {
        throw new Exception("Could not process data");
    }

    var instructionRequest = new InstructionProcessingRequest
    {
        Instructions = dataProcessResponse.Instructions,
    };

    var instructionResponseTask = Task.Run(() => _instructionProcessingService.ProcessInstructions(instructionRequest));

    var screenRequest = new GetScreenRequest
    {
        Instructions = dataProcessResponse.Instructions
    };

    var screenResponseTask = Task.Run(() => _instructionProcessingService.GetScreenOutput(screenRequest));

    await instructionResponseTask;
    var instructionResponse = instructionResponseTask.Result;

    if (instructionResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not process instructions");
    }

    await screenResponseTask;
    var screenResponse = screenResponseTask.Result;

    if (screenResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not get screen data");
    }

    Console.WriteLine($"The signal strength at the end was {instructionResponse.SignalStrength}");
    Console.WriteLine($"The screen output:");
    Console.WriteLine($"{screenResponse.Output}");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.ReadKey();