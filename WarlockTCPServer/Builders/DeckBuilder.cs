using System;
using System.Collections.Generic;
using System.Text;
using WarlockTCPServer.GameLogic.Actor;
using static WarlockTCPServer.Constants.DeckConstants;
using static WarlockTCPServer.Builders.ActorBuilder;

namespace WarlockTCPServer.Builders
{
    public class DeckBuilder
    {
        private int DeckSize;

        public DeckBuilder(int deckSize)
        {
            DeckSize = deckSize;
        }

        public Actor[] Build()
        {
            Actor[] deck;
            if (EqualClassDistribution)
                deck = CreateEqualDeck();
            else
                deck = CreateRandomDeck();

            if (EqualOriginDistribution)



            return deck;
        }

        private Actor[] CreateEqualDeck()
        {
            Actor[] deck = new Actor[DeckSize];
            Random random = new Random();
            int offset = random.Next(6);
            for (int i = 0; i < DeckSize; i++)
            {
                deck[i] = CreateActor((short)(i + 1), (ActorClass)(offset + i));
            }
            return deck;
        }
        private Actor[] CreateRandomDeck()
        {
            Actor[] deck = new Actor[DeckSize];
            Random random = new Random();
            int offset = random.Next(6);
            for (int i = 0; i < DeckSize; i++)
            {
                deck[i] = CreateActor((short)(i + 1), (ActorClass)(random.Next(6)));
            }
            return deck;
        }
    }
}
