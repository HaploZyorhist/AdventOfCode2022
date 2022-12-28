using Day11.Factories;
using Day11.Models.Enums;
using Day11.Models.Requests;

StreamReader sr = File.OpenText(@"..\..\..\Data\TestData.txt");
string data = sr.ReadToEnd();

//not the right way to impliment a factory, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _dataProcessingFactory = new DataProcessingFactory();

//not the right way to impliment a service, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
//var _instructionProcessingService = new InstructionProcessingService();

try
{
    var rounds = 20;

    var dataRequest = new ProcessDataRequest
    {
        RawData = data
    };

    var dataResponse = await _dataProcessingFactory.ProcessRawData(dataRequest);

    if (dataResponse is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not process raw data");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();