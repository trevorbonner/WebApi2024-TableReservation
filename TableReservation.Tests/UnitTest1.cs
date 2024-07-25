namespace TableReservation.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Theory]
        [InlineData(true)]
        //[InlineData(false)]
        [InlineData(true)]
        public void Test2(bool isTrue)
        {
            Assert.True(isTrue);
        }
    }
}