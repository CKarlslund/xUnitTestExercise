using System;
using InterfaceExercise.Models;
using Xunit;

namespace UnitTests
{
    public class SearchPartyTests
    {
        [Fact]
        public void SearchParty_returns_correct_party()
        {
            var term = "9011023981";

            var sut = new SearchParty(new FakeSearchRepository());

            Party result = sut.Search(term);

            Assert.Equal("Cornelia", result.Name);
        }

        [Fact]
        public void SearchParty_returns_correct_exception_if_term_not_found()
        {
            var term = "8511023980";

            var sut = new SearchParty(new FakeSearchRepository());

            var result = Assert.Throws<InvalidOperationException>(() => { sut.Search(term); });
        }
    }
}
