using System;
using System.Collections.Generic;
using System.Text;
using WarlockTCPServer.GameLogic.Actor;
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
            Actor[] deck = new Actor[DeckSize];
            for (short i = 0; i < deck.Length; i++)
            {
                deck[i] = ActorBuilder.CreateActor((short)(i + 1), ActorClass;
            }
            return deck;
        }

        private enum ActorClass
        {
            Brute,
            Warden,
            Sorcerer,
            Enchanter,
            Trapper,
            Stalker
        }
    }
}
