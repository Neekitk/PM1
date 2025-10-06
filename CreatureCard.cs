using System;
using Cards;
using interfaces;


namespace CreatureCards
{
    class CreatureCard : Card, IPlayable
    {
        public int Attack { get; private set; }
        public int Health { get; private set; }
        public CreatureCard(string name, int cost, int attack, int health) : base(name, cost)
        {
            Attack = attack;
            Health = health;
        }
        public void Play()
        {
            Console.WriteLine($"Играем существо: {Name} (Атака: {Attack}, Здоровье: {Health})");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"{Name} - Стоимость: {Cost}, Атака: {Attack}, Здоровье: {Health}");
        }
    }
}
