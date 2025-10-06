using System;
using Cards;
using interfaces;

namespace SpellCards
{
    class SpellCard : Card, IPlayable
    {
        public string Effect { get; private set; }
        public SpellCard(string name, int cost, string effect) : base(name, cost)
        {
            Effect = effect;
        }
        public void Play()
        {
            Console.WriteLine($"Используем заклинание: {Name} - Эффект: {Effect}");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"{Name} - Стоимость: {Cost}, Эффект: {Effect}");
        }
    }

}
