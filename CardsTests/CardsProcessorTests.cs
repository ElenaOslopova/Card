using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace Cards.Tests
{
    [TestClass()]
    public class CardsProcessorTests
    {
        [TestMethod()]
        public void ProcessTestSuccess()
        {
            var cards = new Collection<Card>
            {
                new Card("Мичуринск", "Тамбов"),
                new Card("Тверь", "Рязань"),
                new Card("Москва", "Тверь"),
                new Card("Рязань", "Мичуринск")
            };

            var expectedCollection = new Collection<Card>
            {
                cards[2],
                cards[1],
                cards[3],
                cards[0]
            };

            var result = CardsProcessor.Process(cards);
            CollectionAssert.AreEqual(expectedCollection, (ICollection)result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProcessTestCardsNullException()
        {
            var result = CardsProcessor.Process(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessTestCardsCountException()
        {
            var result = CardsProcessor.Process(new Collection<Card>());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProcessTestCardNullException()
        {
            var cards = new Collection<Card>
            {
                new Card("Мичуринск", "Тамбов"),
                null,
                new Card("Москва", "Тверь"),
                new Card("Рязань", "Мичуринск")
            };

            var result = CardsProcessor.Process(cards);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProcessTestInputNullException()
        {
            var cards = new Collection<Card>
            {
                new Card("Мичуринск", "Тамбов"),
                new Card("Тверь", "Рязань"),
                new Card("Москва", null),
                new Card("Рязань", "Мичуринск")
            };

            var result = CardsProcessor.Process(cards);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProcessTestOutputNullException()
        {
            var cards = new Collection<Card>
            {
                new Card("Мичуринск", "Тамбов"),
                new Card("Тверь", "Рязань"),
                new Card(null, "Тверь"),
                new Card("Рязань", "Мичуринск")
            };

            var result = CardsProcessor.Process(cards);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessTestSameInputException()
        {
            var cards = new Collection<Card>
            {
                new Card("Мичуринск", "Тверь"),
                new Card("Мичуринск", "Тамбов"),
                new Card("Тверь", "Рязань"),
                new Card("Москва", "Тверь"),
                new Card("Рязань", "Мичуринск")
            };

            var result = CardsProcessor.Process(cards);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessTestSameOutputException()
        {
            var cards = new Collection<Card>
            {
                new Card("Воронеж", "Тверь"),
                new Card("Мичуринск", "Тамбов"),
                new Card("Тверь", "Рязань"),
                new Card("Москва", "Тверь"),
                new Card("Рязань", "Мичуринск")
            };

            var result = CardsProcessor.Process(cards);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessTestCycleException()
        {
            var cards = new Collection<Card>
            {
                new Card("Тамбов", "Москва"),
                new Card("Мичуринск", "Тамбов"),
                new Card("Тверь", "Рязань"),
                new Card("Москва", "Тверь"),
                new Card("Рязань", "Мичуринск")
            };

            var result = CardsProcessor.Process(cards);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessTestManyChainsException()
        {
            var cards = new Collection<Card>
            {
                new Card("Воронеж", "Горловка"),
                new Card("Мичуринск", "Тамбов"),
                new Card("Тверь", "Рязань"),
                new Card("Москва", "Тверь"),
                new Card("Рязань", "Мичуринск")
            };

            var result = CardsProcessor.Process(cards);
        }
    }
}