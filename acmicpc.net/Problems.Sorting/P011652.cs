using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Sorting
{
    public class P011652
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, Card> cards = new Dictionary<int, Card>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (cards.TryGetValue(number, out Card card) == false)
                {
                    card = new Card(number);
                    cards.Add(number, card);
                }

                card.Count++;
            }

            var sorted = cards.Values.ToList();
            sorted.Sort();
            Console.WriteLine(sorted[0].Number);
        }

        public class Card : IComparable<Card>
        {
            public int Number;
            public int Count;
            public Card(int number)
            {
                Number = number;
            }

            public int CompareTo(Card other)
            {
                int cmp = this.Count.CompareTo(other.Count) * -1;
                if (cmp != 0)
                    return cmp;
                
                return this.Number.CompareTo(other.Number);
            }
        }
    }
}