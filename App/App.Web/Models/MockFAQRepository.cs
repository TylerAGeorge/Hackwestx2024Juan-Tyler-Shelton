namespace App.Web.Models
{
    public class MockFAQRepository: IFAQRepository
    {
        public IEnumerable<FAQ> GetAll =>
            new List<FAQ>()
            {
                new FAQ() {Question = "how do i fly?", Answer = "You can't", ID=0},
                new FAQ() {Question="why am i alive?", Answer = "idk, ask god", ID=1},
                new FAQ() {Question="how did i get here?", Answer = "how should I know?", ID=2}
            };

    }
}
