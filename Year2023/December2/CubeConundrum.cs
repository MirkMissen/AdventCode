using Optional.Collections;

namespace Year2023.December2; 

public static class CubeConundrum {

    public static int CalculateMinimumSetPower(this IEnumerable<GameData> gameData) {
        return gameData
            .Select(x => x.CalculateMinimumSet())
            .Select(x => x.BlueCubes * x.GreenCubes * x.RedCubes)
            .Sum();
    }

    private static Draw CalculateMinimumSet(this GameData gameData) {
        var allDraws = gameData.Draws.ToArray();
        
        var minRed = allDraws.Select(x => x.RedCubes).Max();
        var minBlue = allDraws.Select(x => x.BlueCubes).Max();
        var minGreen = allDraws.Select(x => x.GreenCubes).Max();
        return new Draw(minRed, minGreen, minBlue);
    }
    
    public static int CalculateSumOfPossiblesIdentifiers(this IEnumerable<GameData> gameData, SetConfiguration setConfiguration) {
        return gameData
            .Where(x => x.IsGamePossible(setConfiguration))
            .Sum(x => x.Id);
    }

    private static bool IsGamePossible(this GameData gameData, SetConfiguration setConfiguration) {
        return gameData.Draws.All(x => x.IsDrawPossible(setConfiguration));
    }

    private static bool IsDrawPossible(this Draw draw, SetConfiguration setConfiguration) {
        return draw.BlueCubes <= setConfiguration.BlueCubes &&
               draw.RedCubes <= setConfiguration.RedCubes &&
               draw.GreenCubes <= setConfiguration.GreenCubes;
    }
    
}

public class GameDataParser {
    
    public static IEnumerable<GameData> ParseContent(string path) {
        var data = File.ReadAllLines(path);

        return data.Select(x => {
            var split = x.Split(": ");

            var gameId = ExtractGameId(split[0]);

            var draws = split[1].Split("; ")
                .Select(ExtractDraw);

            return new GameData(gameId, draws);
        });
    }

    private static Draw ExtractDraw(string text) {
        // Count color, Count color, Count color
        var splits = text.Split(", ");

        var dictionary = splits.Select(x => x.Split(" "))
            .ToDictionary(strings => strings[1], strings => int.Parse(strings[0]));

        dictionary.TryGetValue("red", out var red);
        dictionary.TryGetValue("green", out var green);
        dictionary.TryGetValue("blue", out var blue);
        
        return new Draw(red, green, blue);
    }
    
    private static int ExtractGameId(string game) {
        var number = game.Replace("Game", "").Trim();
        return int.Parse(number);
    }
    
}

public record GameData(
    int Id,
    IEnumerable<Draw> Draws
    );

public record Draw(
    int RedCubes,
    int GreenCubes,
    int BlueCubes);

public record SetConfiguration(
    int RedCubes,
    int GreenCubes,
    int BlueCubes
);