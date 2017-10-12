using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceExercise.Models
{
    public class RealSearchRepository : IPartyService
    {
        private ApplicationDbContext _context;

        public RealSearchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Party Get(string term)
        {
            var party = _context.Parties.FirstOrDefault(x => x.SocialSecurityNumber == term);

            if (party == null)
            {
                throw new InvalidOperationException("Ditt valda personnummer fanns inte");
            }
            return party;
        }
    }
}
