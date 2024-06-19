using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        // Test if addition works correctly
        [Fact]
        public void AdditionTest()
        {
            int result = 2 + 3;
            Assert.Equal(5, result);
        }

        // Test if subtraction works correctly
        [Fact]
        public void SubtractionTest()
        {
            int result = 5 - 3;
            Assert.Equal(2, result);
        }

        // Test if multiplication works correctly
        [Fact]
        public void MultiplicationTest()
        {
            int result = 4 * 3;
            Assert.Equal(12, result);
        }

        // Test if division works correctly
        [Fact]
        public void DivisionTest()
        {
            int result = 10 / 2;
            Assert.Equal(5, result);
        }

        // Test if division by zero throws exception
        [Fact]
        public void DivisionByZeroTest()
        {
            Assert.Throws<System.DivideByZeroException>(() => { int result = 10 / 1; });
        }

        // Test if string concatenation works correctly
        [Fact]
        public void StringConcatenationTest()
        {
            string result = "Hello" + " " + "World";
            Assert.Equal("Hello World", result);
        }

        // Test if array contains a specific value
        [Fact]
        public void ArrayContainsValueTest()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Assert.Contains(3, numbers);
        }

        // Test if array does not contain a specific value
        [Fact]
        public void ArrayDoesNotContainValueTest()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Assert.DoesNotContain(6, numbers);
        }

        // Test if a value is null
        [Fact]
        public void ValueIsNullTest()
        {
            object obj = null;
            Assert.Null(obj);
        }

        // Test if a value is not null
        [Fact]
        public void ValueIsNotNullTest()
        {
            object obj = new object();
            Assert.NotNull(obj);
        }

        // Test if an object is of a specific type
        [Fact]
        public void ObjectIsOfTypeTest()
        {
            object obj = "Hello World";
            Assert.IsType<string>(obj);
        }

        // Test if a collection contains the expected number of elements
        [Fact]
        public void CollectionCountTest()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Assert.Equal(5, numbers.Length);
        }
    }
}
