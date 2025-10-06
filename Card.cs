using System;

namespace Cards
{
    abstract class Card
    {
        public string Name { get; protected set; }
        public int Cost { get; protected set; }
        public Card(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
        public abstract void DisplayInfo();
    }
}
