using InterfaceExercise.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests
{
    public class IntegrationTests
    {
        [Fact]
        public void Context_returns_correct_party()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            options.UseInMemoryDatabase("DefaultConnection");

            var context = new ApplicationDbContext(options.Options);

            var party1 = new Party() { Name = "Cornelia", SocialSecurityNumber = "9011023981" };
            var party2 = new Party() { Name = "Olof", SocialSecurityNumber = "9001245845" };

            context.Parties.AddRange(party1, party2);
            context.SaveChanges();

            var term = "9011023981";

            var sut = new SearchParty(new RealSearchRepository(context));

            Party result = sut.Search(term);

            Assert.Equal("Cornelia", result.Name);
        }
    }
}