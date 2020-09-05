using System;
using System.Collections.Generic;
using System.Text;

namespace WarlockTCPServer.Constants
{
    public static class DeckConstants
    {
        #region Player Deck Arrangements
        public const short DeckSize = 30;
        public const short HandSize = 5;
        public const short PartySize = 6;
        #endregion

        #region Actor Distribution
        // if set to true, then the actor aspects of Origin in each deck will be as equal as possible. If not, then it will be randomized.
        public const bool EqualOriginDistribution = true;
        // if set to true, then the actor aspects of Class in each deck will be as equal as possible. If not, then it will be randomized.
        public const bool EqualClassDistribution = true;
        #endregion

        #region Class Presets
        #region Brute
        public const short BruteHealth = 60;
        public const short BruteDefense = 30;
        public const short BruteAttack = 35;
        public const short BruteSpeed = 20;
        public const short BrutePrecision = 15;
        #endregion
        #region Warden
        public const short WardenHealth = 60;
        public const short WardenDefense = 50;
        public const short WardenAttack = 25;
        public const short WardenSpeed = 20;
        public const short WardenPrecision = 5;
        #endregion
        #region Sorcerer
        public const short SorcererHealth = 20;
        public const short SorcererDefense = 10;
        public const short SorcererAttack = 80;
        public const short SorcererSpeed = 40;
        public const short SorcererPrecision = 0;
        #endregion
        #region Enchanter
        public const short EnchanterHealth = 40;
        public const short EnchanterDefense = 10;
        public const short EnchanterAttack = 60;
        public const short EnchanterSpeed = 40;
        public const short EnchanterPrecision = 0;
        #endregion
        #region Trapper
        public const short TrapperHealth = 40;
        public const short TrapperDefense = 20;
        public const short TrapperAttack = 30;
        public const short TrapperSpeed = 25;
        public const short TrapperPrecision = 60;
        #endregion
        #region Stalker
        public const short StalkerHealth = 30;
        public const short StalkerDefense = 20;
        public const short StalkerAttack = 40;
        public const short StalkerSpeed = 60;
        public const short StalkerPrecision = 25;
        #endregion
        #endregion

        public const int CommonFrequency = 18; // 3 copies of 18 unique common cards
        public const int UncommonFrequency = 12; 
        public const int RareFrequency = 6;

        public enum ActorClass
        {
            Brute,
            Warden,
            Sorcerer,
            Enchanter,
            Trapper,
            Stalker
        }

        public enum ActorOrigin
        {
            Undead,
            Glacial,
            Infernal,
            Nature,
            Aberrant,
            Aquatic
        }
    }
}
