using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Receive.Domain.Tests
{
    public class ReverserTests
    {
        private readonly IReverser _reverser;

        public ReverserTests()
        {
            _reverser = new Reverser();
        }

        [Fact]
        public void phrases_came_out_in_reverse_order()
        {
            // Arrange
            var inputPhrases = new[] { "first", "second", "third" };
            var expectedOutputPhrasesOrder = new[] { "third", "second", "first" };
            
            // Act
            var actualResult = _reverser.Reverse(inputPhrases);

            // Assert
            AssertPhrasesOrderEquality(expectedOutputPhrasesOrder, actualResult.ToList());
        }

        private void AssertPhrasesOrderEquality(
            IReadOnlyList<string> expectedPhrasesOrder, IReadOnlyList<string> actualPhrasesOrder)
        {
            for (int idx = 0; idx < expectedPhrasesOrder.Count; idx++)
            {
                var expectedPhrase = expectedPhrasesOrder[idx];
                var actualPhrase = actualPhrasesOrder[idx];

                Assert.Equal(expectedPhrase, actualPhrase);
            }
        }
    }
}
