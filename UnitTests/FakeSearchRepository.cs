using InterfaceExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests
{
    public class FakeSearchRepository : IPartyService
    {
        private List<Party> _parties;

        public FakeSearchRepository()
        {
            _parties = new List<Party>();

            var party1 = new Party(){Name = "Cornelia", SocialSecurityNumber = "9011023981"};
            var party2 = new Party(){ Name = "Olof", SocialSecurityNumber = "9001245845"};
            _parties.Add(party1);
            _parties.Add(party2);
        }
        public Party Get(string term)
        {
            var party = _parties.FirstOrDefault(x => x.SocialSecurityNumber == term);

            if (party == null)
            {
                throw new InvalidOperationException("Ditt valda personnummer fanns inte");
            }
            return party;
        }
    }
}
