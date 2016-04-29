using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    public static class CardsProcessor
    {
        public static ICollection<Card> Process(ICollection<Card> cards)
        {
            Validate(cards);

            var start = cards.First(); ;
            var sortedCards = new LinkedList<Card>();
            sortedCards.AddFirst(start);

            for (var previous = cards.FirstOrDefault(c => start.Input == c.Output);
                previous != null;
                previous = cards.FirstOrDefault(c => previous.Input == c.Output))
            {
                sortedCards.AddFirst(previous);
            }

            for (var next = cards.FirstOrDefault(c => start.Output == c.Input);
                next != null; next = cards.FirstOrDefault(c => next.Output == c.Input))
            {
                sortedCards.AddLast(next);
            }

            return sortedCards;
        }

        private static void Validate(ICollection<Card> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("Не назначена коллекция карточек");
            }

            var count = cards.Count;

            if (count == 0)
            {
                throw new ArgumentException("Коллекция карточек пустая");
            }

            var inputCount = 0;
            var outputCount = 0;

            foreach (var card1 in cards)
            {
                var isInput = false;
                var isOutput = false;

                if (card1 == null)
                {
                    throw new ArgumentNullException("Не назначена карточка");
                }

                if (card1.Input == null)
                {
                    throw new ArgumentNullException("Не назначен пункт отправления");
                }

                if (card1.Output == null)
                {
                    throw new ArgumentNullException("Не назначен пункт назначения");
                }

                foreach (var card2 in cards)
                {
                    if (card2 == null)
                    {
                        throw new ArgumentNullException("Не назначена карточка");
                    }

                    if (card1 != card2)
                    {
                        if (card1.Input == card2.Input)
                        {
                            throw new ArgumentException("Одинаковые пункты отправления");
                        }

                        if (card1.Output == card2.Output)
                        {
                            throw new ArgumentException("Одинаковые пункты назначения");
                        }

                        if (card1.Output == card2.Input)
                        {
                            isOutput = true;
                        }

                        if (card1.Input == card2.Output)
                        {
                            isInput = true;
                        }
                    }
                }
                inputCount += (isInput ? 0 : 1);
                outputCount += (isOutput ? 0 : 1);
            }

            if (inputCount == 0 || outputCount == 0)
            {
                throw new ArgumentException("Цикл");
            }

            if (inputCount > 1 || outputCount > 1)
            {
                throw new ArgumentException("Более одной цепочки городов");
            }
        }
    }
}
