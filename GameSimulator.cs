using System;
using Cards;
using CreatureCards;
using Exceptions;
using interfaces;
using SpellCards;

namespace GameSimulators
{
    class GameSimulator
    {
        private Queue<Card> deck;
        private Stack<Card> discardPile;
        private List<Card> hand;
        private string logFilePath = "game_log.txt";
        public GameSimulator()
        {
            deck = new Queue<Card>();
            discardPile = new Stack<Card>();
            hand = new List<Card>();
            InitializeDeck();
        }
        private void InitializeDeck()
        {
            deck.Enqueue(new CreatureCard("Дракон", 5, 7, 5));
            deck.Enqueue(new SpellCard("Огненный шар", 4, "Наносит 6 урона"));
            deck.Enqueue(new CreatureCard("Рыцарь", 3, 3, 4));
            deck.Enqueue(new SpellCard("Исцеление", 2, "Восстанавливает 5 здоровья"));
            deck.Enqueue(new CreatureCard("Гоблин", 1, 2, 1));
        }
        public void StartGame()
        {
            Log("Игра началась");
            try
            {
                DrawCard();
                PlayCardFromHand(0);
                DrawCard();
                PlayCardFromHand(1);
            }
            catch (InvalidActionException ex)
            {
                Log($"Ошибка: {ex.Message}");
            }
            finally
            {
                Log("Игра завершена");
            }
        }
        public void DrawCard()
        {
            if (deck.Count == 0)
                throw new InvalidActionException("Колода пуста!");
            Card drawnCard = deck.Dequeue();
            hand.Add(drawnCard);
            Log($"Взята карта: {drawnCard.Name}");
            Console.WriteLine($"Взята карта: {drawnCard.Name}");
        }

        public void PlayCardFromHand(int index)
        {
            if (index < 0 || index >= hand.Count)
                throw new InvalidActionException("Некорректный индекс карты!");

            Card cardToPlay = hand[index];

            if (cardToPlay is IPlayable playable)
            {
                playable.Play();
                Log($"Использована карта: {cardToPlay.Name}");
                discardPile.Push(cardToPlay);
                hand.RemoveAt(index);
            }
            else
            {
                throw new InvalidActionException("Карта не является играбельной!");
            }
        }
        private void Log(string message)
        {
            using (StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                sw.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
