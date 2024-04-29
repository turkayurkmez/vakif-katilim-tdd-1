namespace FizzBuzz.Tests
{
    public class FizzBuzzGameTests
    {
        private FizzBuzzGame game;
        public FizzBuzzGameTests()
        {
            game = new FizzBuzzGame();
        }
        [Fact]
        public void When_Parameter_Is_Number_Then_Return_String()
        {
            //Arrange:
            //FizzBuzzGame game = new FizzBuzzGame();
            //Act:
            string word = game.GetWord(8);
            //Assert:

        }

        [Fact]
        public void Given_3_Then_Return_Fizz()
        {
            //FizzBuzzGame game = new FizzBuzzGame();
            var value = 3;

            var word = game.GetWord(value);

            Assert.Equal("Fizz", word);
        }

        [Fact]
        public void Given_5_Then_Return_Buzz()
        {
            //FizzBuzzGame game = new FizzBuzzGame();
            var value = 5;
            var word = game.GetWord(value);
            Assert.Equal("Buzz", word);

        }

        [Fact]
        public void Given_15_Then_Return_FizzBuzz()
        {
            var value = 15;
            var word = game.GetWord(value);
            Assert.Equal("FizzBuzz", word);

        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public void Given_Number_Then_Return_String_of_this_number(int value)
        {
            var word = game.GetWord(value);
            Assert.Equal(value.ToString(), word);
        }



        [Theory]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        public void Given_Divisible_By_3_And_5_Then_FizzBuzz(int number)
        {
            var result = game.GetWord(number);
            Assert.Equal("FizzBuzz", result);
        }
    }
}