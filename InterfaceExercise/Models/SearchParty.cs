namespace InterfaceExercise.Models
{
    public class SearchParty
    {
        private readonly IPartyService _repository;

        public SearchParty(IPartyService fakeSearchRepository)
        {
            _repository = fakeSearchRepository;
        }

        public Party Search(string term)
        {
            return _repository.Get(term);
        }
    }
}