using System;
using System.Collections.Generic;
using WarlockTCPServer.GameLogic;
using static WarlockTCPServer.Constants.DeckConstants;
using static WarlockTCPServer.Constants.DeckPresets;

namespace WarlockTCPServer.Builders
{
    public class DeckBuilder
    {

        private Actor[] FinalDeck;
        private List<Actor> RawDeck = new List<Actor>();

        #region Builder Functions
        public Actor[] Build(string deckName)
        {
            var deckScaffold = Presets[deckName];
            return Build(deckScaffold);
        }
        public Actor[] Build(List<(Characters, int)> deckScaffold)
        {
            var random = new Random();
            short cardId = 0;
            for (int i = 0; i < deckScaffold.Count; i++)
            {
                for (int j = 0; j < deckScaffold[i].Item2; j++)
                {
                    cardId++;
                    var actor = ActorBuilder.Build(deckScaffold[i].Item1, cardId);
                    int randomIndex = random.Next(RawDeck.Count);
                    RawDeck.Insert(randomIndex, actor);
                }
            }
            FinalDeck = RawDeck.ToArray();
            return FinalDeck;
        }
        #endregion

        #region Defunct
        //private int DeckSize;

        //public DeckBuilder(int deckSize)
        //{
        //    DeckSize = deckSize;
        //}

        //public Actor[] Build()
        //{
        //    Actor[] deck = new Actor[DeckSize];
        //    if (EqualClassDistribution)
        //        SetEqualClasses(deck);
        //    else
        //        SetRandomClasses(deck);

        //    if (EqualOriginDistribution)
        //        SetEqualOrigins(deck);
        //    else
        //        SetRandomOrigins(deck);

        //    BalanceCosts(deck);

        //    return deck;
        //}

        //#region Adding Class Types
        //private void SetEqualClasses(Actor[] deck)
        //{
        //    List<int> classes = RandomOrderEqualList(deck.Length, 0, 6); // 0, 1, 2, 3, 4, 5
        //    for (int i = 0; i < deck.Length; i++)
        //    {
        //        int @class = classes[i];
        //        deck[i] = CreateActor((short)(i + 1), (ActorClass)@class);
        //    }
        //}
        //private void SetRandomClasses(Actor[] deck)
        //{
        //    Random random = new Random();
        //    for (int i = 0; i < deck.Length; i++)
        //    {
        //        deck[i] = CreateActor((short)(i + 1), (ActorClass)(random.Next(6)));
        //    }
        //}
        //#endregion

        //#region Adding Origin Types
        //private void SetEqualOrigins(Actor[] deck)
        //{
        //    List<int> origins = RandomOrderEqualList(deck.Length, 0, 6); // 0, 1, 2, 3, 4, 5
        //    for (int i = 0; i < deck.Length; i++)
        //    {
        //        int origin = origins[i];
        //        deck[i].Origin = ((ActorOrigin)origin).ToString();
        //    }
        //}

        //private void SetRandomOrigins(Actor[] deck)
        //{
        //    Random random = new Random();
        //    for (int i = 0; i < deck.Length; i++)
        //    {
        //        deck[i].Origin = ((ActorOrigin)random.Next(6)).ToString();
        //    }
        //}
        //#endregion

        //private void BalanceCosts(Actor[] deck)
        //{
        //    Dictionary<string, int> classes = new Dictionary<string, int>();
        //    foreach (var card in deck)
        //    {
        //        if (classes.ContainsKey(card.Class))
        //            classes[card.Class]++;
        //        else
        //            classes.Add(card.Class, 0);
        //    }

        //}

        ///// <summary>
        ///// Creates a helpful list for randomly assigning values. Useful for enums.
        ///// </summary>
        ///// <param name="length">Length of list.</param>
        ///// <param name="min">Inclusive lower bound.</param>
        ///// <param name="max">Exclusive upper bound.</param>
        ///// <returns></returns>
        //private List<int> RandomOrderEqualList(int length, int min, int max)
        //{
        //    int distSpread = max - min;
        //    int remainderArea = length % distSpread;
        //    Random rand = new Random();

        //    List<int> list = new List<int>(length);
        //    List<int> prevAdds = new List<int>();
        //    Dictionary<int, int> tracker = new Dictionary<int, int>(distSpread);
        //    // setting up a group of integers to pull from to guarantee equal distribution
        //    for (int i = min; i < max; i++)
        //    {
        //        tracker.Add(i, (int)(length / distSpread));
        //    }
        //    // pulling from the collection we made to add to the list in a random order
        //    int index = 0;
        //    while (tracker.Count > 0)
        //    {
        //        int num = rand.Next(min, max);
        //        if (tracker.ContainsKey(num))
        //        {
        //            list[index] = num;
        //            index++;
        //            tracker[num]--;
        //            if (tracker[num] == 0)
        //            {
        //                tracker.Remove(num);
        //            }
        //        }
        //    }
        //    // if the range of integers does not fit evenly, this adds the remaining amount at random, without any duplicates
        //    while (index < length)
        //    {
        //        int num = rand.Next(min, max);
        //        if (!prevAdds.Contains(num))
        //        {
        //            list[index] = num;
        //            prevAdds.Add(num);
        //            index++;
        //        }
        //    }
        //    // final shuffle, possibly redundant, but feels nice
        //    list.Reverse();

        //    return list;
        //}
        #endregion
    }
}
