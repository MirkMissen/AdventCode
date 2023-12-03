using System.Diagnostics;
using Extensions;
using Optional.Collections;

namespace Year2023.December1; 

public static class Trebuchet {

    public static int CalculateCalibrationValues(this TrebuchetData data) {
        return data.Lines
            .Select(x => $"{x.LineSections.First().Value}{x.LineSections.Last().Value}")
            .Select(int.Parse)
            .Sum();
    }
    
}

public static class DataSampleParser {

    private static readonly Dictionary<string, char> _numbers = new Dictionary<string, char>() {
        { "one", '1' }, {"two", '2'}, {"three", '3'}, {"four", '4'}, {"five", '5'}, {"six", '6'}, {"seven", '7'}, {"eight", '8'}, {"nine", '9'}
    };

    public static TrebuchetData ParseData(string path) {
        var data = File.ReadAllLines(path)
            .Select(ConvertToLineSections)
            .Select(x => new Line(x));

        return new TrebuchetData(data);
    }

    public static IEnumerable<NumberLineSection> ConvertToLineSections(string text) {
        var currentText = text;
        while (true) {
            var text1 = currentText;
            var firstOrNone = _numbers
                .Select(x => Tuple.Create(text1.IndexOf(x.Key, StringComparison.Ordinal), x))
                .Where(x => x.Item1 >= 0)
                .OrderBy(tuple => tuple.Item1)
                .FirstOrNone();

            if (firstOrNone.HasValue) {
                var value = firstOrNone.ValueOr(() => throw new Exception());
                currentText = currentText.Replace(value.Item2.Key, value.Item2.Value.ToString());
            }
            else {
                break;
            }
        }
        
        return currentText.Where(x => _numbers.ContainsValue(x))
            .Select(x => new NumberLineSection(int.Parse(x.ToString())));
    }

}

public record TrebuchetData(IEnumerable<Line> Lines);
public record Line(IEnumerable<NumberLineSection> LineSections);
public record NumberLineSection(int Value);

