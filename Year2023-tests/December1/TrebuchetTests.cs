using Year2023.December1;

namespace Year2023_tests.December1; 

public class TrebuchetTests {

    private const string TestSample1Path = "December1/TestSample1.txt";
    private const string TestSample2Path = "December1/TestSample2.txt";
    private const string Task1DataPath = "December1/Task1Data.txt";
    
    [Fact]
    public void ShouldEvaluateExample1Correct() {
        var data = DataSampleParser.ParseData(TestSample1Path);
        var result = data.CalculateCalibrationValues();
        Assert.Equal(142, result);
    }

    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]    
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]    
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]    
    [InlineData("7pqrstsixteen", 76)]
    
    [InlineData("sq5fivetwothree1", 51)]
    [InlineData("six5gc", 65)]
    [InlineData("txb3qfzsbzbxlzslfourone1vqxgfive", 35)]
    [InlineData("3onethreebrth", 33)]
    [InlineData("cseven7nqqxnkzngndtddfiverkxkxqjjsr", 75)]
    
    [InlineData("2lvpmzh4", 24)]
    [InlineData("threeqxqndvjrz15", 35)]
    [InlineData("threetwo1drtzsixtwofourppvg", 34)]
    [InlineData("zxhsndseven2vbnhdtfpr3bt86", 76)]
    [InlineData("onethreelqqqqvj7eightnine5", 15)]
    [InlineData("7sevenfour5gnine", 79)]
    [InlineData("1seven5", 15)]
    [InlineData("vgxhqfrvr7vfsxqms3", 73)]
    [InlineData("twokdkcbhtqxfc87rkgctwo", 22)]
    [InlineData("twosix9threernltgbffour", 24)]
    
    [InlineData("npvzzqfb5tbbn4cnt", 54)]
    [InlineData("jjxlckssjmdkm5szklnq1two", 52)]
    [InlineData("lblcscglvseven53251zzcj", 71)]
    [InlineData("threesevenzplpzlqb1", 31)]
    [InlineData("threeeightxhrkflkbzp2", 32)]
    [InlineData("honemkmbfbnlhtbq19twonekbp", 11)]
    [InlineData("vdttwoeight7eightoneone6vq", 26)]
    [InlineData("eightvszlvntpfourjqcgmjr3", 83)]
    [InlineData("dslqnmd7k1twogbvhhnfmtsix", 76)]
    [InlineData("twocsnn7jslpsppxmjr36eightss", 28)]
    [InlineData("7eightrdcz74twolvd2cctg", 72)]
    [InlineData("4threerrqxpmmzhrqht4two2", 42)]
    [InlineData("2seven9two", 22)]
    [InlineData("479", 49)]
    [InlineData("threefour86", 36)]
    [InlineData("5klxgb1", 51)]
    [InlineData("dchrpzkfpgqzgjmpdcthreeeightsix82five", 35)]
    [InlineData("seven5tcls", 75)]
    [InlineData("six5three2six888zd", 68)]
    [InlineData("75nine274sbzd", 74)]

    
    [InlineData("oneone", 11)]
    [InlineData("twotwo", 22)]
    [InlineData("threethree", 33)]
    [InlineData("fourfour", 44)]
    [InlineData("fivefive", 55)]
    [InlineData("sixsix", 66)]
    [InlineData("sevenseven", 77)]
    [InlineData("eighteight", 88)]
    [InlineData("ninenine", 99)]
    
    
    public void ShouldProcessDataCorrectly(string value, int expectedResult) {

        var data = new TrebuchetData(new Line[] {new (DataSampleParser.ConvertToLineSections(value))});
        var result = data.CalculateCalibrationValues();

        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void ShouldEvaluateExample2Correct() {
        var data = DataSampleParser.ParseData(TestSample2Path);
        var result = data.CalculateCalibrationValues();
        Assert.Equal(281, result);
    }
    

    [Fact]
    public void ShouldAcceptTaskOne() {
        var data = DataSampleParser.ParseData(Task1DataPath);

        var result = data.CalculateCalibrationValues();
        
        Assert.True(54521 > result);
    }
    
}