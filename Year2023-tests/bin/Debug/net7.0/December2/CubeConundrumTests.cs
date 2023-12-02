using Xunit.Abstractions;
using Year2023.December2;

namespace Year2023_tests.December2; 

public class CubeConundrumTests {
    
    private readonly ITestOutputHelper _testOutputHelper;

    public CubeConundrumTests(ITestOutputHelper testOutputHelper) {
        _testOutputHelper = testOutputHelper;
    }

    private const string DataFilePath = "December2/GameData1.txt";
    private const string TestCase1Path = "December2/TestCase1.txt";

    [Fact]
    public void TestCaseOne() {
        var setConfig = new SetConfiguration(12, 13, 14);
        var data = GameDataParser.ParseContent(TestCase1Path);

        var result = data.CalculateSumOfPossiblesIdentifiers(setConfig);
        
        Assert.Equal(8, result);
    }

    [Fact]
    public void CalculateMinimumSet() {
        var data = GameDataParser.ParseContent(TestCase1Path);

        var result = data.CalculateMinimumSetPower();
        
        Assert.Equal(2286, result);
    }
    
    [Fact]
    public void Calculate() {

        var setConfig = new SetConfiguration(12, 13, 14);
        var data = GameDataParser.ParseContent(DataFilePath);

        var result = data.CalculateSumOfPossiblesIdentifiers(setConfig);
        var minimumSetResult = data.CalculateMinimumSetPower();

        _testOutputHelper.WriteLine($"result: {result}");
        _testOutputHelper.WriteLine($"Minimum set result: {minimumSetResult}");
    }
    
}