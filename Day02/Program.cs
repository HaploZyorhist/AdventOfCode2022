using Day02.Factories;
using Day02.Models.Enums;
using Day02.Models.Requests;
using Day02.Models.Responses;

StreamReader sr = File.OpenText(@"..\..\..\Data\Data.txt");
string data = sr.ReadToEnd();

//not the right way to impliment a factory, but due to being a console app 
//you cannot do dependencey injection properly so this will have to do.
var _pointFactory = new PointFactory();
var _gameObjectFactory = new GameObjectFactory();

var gamesPlayed = data.Split("\r\n").ToList();

try
{
    #region Get Game objects

    var goRequest = new GOFactoryRequest
    {
        Games = gamesPlayed
    };

    var cleanGames = await _gameObjectFactory.PrepGames(goRequest);

    if (cleanGames is not { Status: StatusEnum.Success })
    {
        throw new Exception("Could not prepare game objects");
    }

    #endregion

    #region Get Points

    int totalPlayerPoints = 0;
    int totalOpponentPoints = 0;

    foreach (var game in cleanGames.Games)
    {
        var pointRequest = new PlayerPointRequest
        {
            GameChoices = game,
        };

        var pointsResponse = await _pointFactory.ProcessPointsForChoice(pointRequest);

        if (pointsResponse is not { Status: StatusEnum.Success })
        {
            throw new Exception("Could not properly calculate points");
        }

        totalOpponentPoints += pointsResponse.OpponentPoints;
        totalPlayerPoints += pointsResponse.PlayerPoints;
    }

    #endregion

    #region Finalize

    Console.WriteLine($"The player has earned {totalPlayerPoints}");
    Console.WriteLine($"The opponent has earned {totalOpponentPoints}");
    Console.ReadKey();

    #endregion
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadKey();
}