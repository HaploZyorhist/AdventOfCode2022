using Day06.Models.Enums;
using Day06.Models.Requests;
using Day06.Services;

StreamReader sr = File.OpenText(@"..\..\..\Data\Data.txt");
string data = sr.ReadToEnd();

//not the right way to impliment a service, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _dataProcessingService = new DataProcessingService();

try
{
    //this part only matters for the testing data
    var dataInputs = data.Split("\r\n");

    var markers = new List<int>();
    var messages = new List<int>();

    foreach (var input in dataInputs)
    {
        var markerRequest = new MarkerRequest
        {
            DataInput = input
        };

        var markerResponse = await _dataProcessingService.GetMarker(markerRequest);

        if (markerResponse is not { Status: StatusEnum.Success})
        {
            throw new Exception("Could not process the marker properly");
        }

        markers.Add(markerResponse.MarkerPosition);

        var messageRequest = new MessageRequest
        {
            DataInput = input
        };

        var messageResponse = await _dataProcessingService.GetMessage(messageRequest);

        if (messageResponse is not { Status: StatusEnum.Success })
        {
            throw new Exception("Could not process the message properly");
        }

        messages.Add(messageResponse.MessagePosition);
    }

    foreach (var marker in markers)
    {
        Console.WriteLine($"The position of the marker is at {marker}");
    }

    Console.WriteLine("\r\n");

    foreach (var message in messages)
    {
        Console.WriteLine($"The position of the message is at {message}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();