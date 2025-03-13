using ConsoleApp1;

namespace TestProject2
{
    public class UnitTest1
    {
        //[Theory] allows you to run many tests using different data
        [Fact]
        public void TestShuffle()
        {
            string[] data = ["abcde", "fghij", "klmno", "pqrst", "uhidw"];

            var shuffled = data.Shuffle();

            var dataset = new HashSet<string>(data);
            var resultset = new HashSet<string>(shuffled);

            // check counts even though the next check will fail if they are different
            Assert.Equal(resultset.Count, dataset.Count);

            // If this fails it might be more complicated bug
            Assert.Equal(dataset, resultset);
        }

        [Fact]
        public void TestApplyClue()
        {
            string[] data = ["abcde", "fghij", "klmno", "pqrst", "uhidw"];
            var result = data.ApplyClue("abcde", "ggggg");
            Assert.Single(result);
            Assert.Equal("abcde", result.First());
        }

        [Fact]
        public void TestApplyClueForIncorrect()
        {
            string[] data = ["abcde", "fghij", "klmno", "pqrst", "uhidw"];
            var result = data.ApplyClue("klmnp", "ggggb");
            Assert.Single(result);
            Assert.Equal("klmno", result.First());
        }

        [Fact]
        public void TestApplyClueForIncorrect2()
        {
            string[] data = ["abcde", "abcdf", "abcdg", "pqrst", "uhidw"];
            var result = data.ApplyClue("abcst", "gggbb");

            var resultSet = new HashSet<string>(result);
            Assert.Contains("abcde", resultSet);
            Assert.Contains("abcdf", resultSet);
            Assert.Contains("abcdg", resultSet);
            Assert.Equal(3, resultSet.Count);
        }
    }
}