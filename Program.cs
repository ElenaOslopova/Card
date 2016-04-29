using System.Collections.ObjectModel;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            var cards = new Collection<Card>
            {
                new Card("Мичуринск", "Тамбов"),
                new Card("Тверь", "Рязань"),
                new Card("Москва", "Тверь"),                
                new Card("Рязань", "Мичуринск")
            };

            var sc = CardsProcessor.Process(cards);
        }
    }
}
