using System.Collections.Generic;
using static WarlockTCPServer.Constants.DeckConstants;

namespace WarlockTCPServer.Constants
{
    public static class DeckPresets
    {
        #region Base Deck
        public static List<(Characters character, int amount)> BaseDeck = new List<(Characters character, int amount)>
        {   // Undead
            (Characters.Skeleton, 3),
            (Characters.Zombie, 3),
            (Characters.Ghost, 3),
            (Characters.Wraith, 3),
            (Characters.Revenant, 3),
            (Characters.Lich, 3),
            // Glacial
            (Characters.Snowfriend, 3),
            (Characters.Ice_Wasp, 3),
            (Characters.Frost_Sprite, 3),
            (Characters.Ice_Pike, 3),
            (Characters.Glacial_Guard, 3),
            (Characters.Ice_Drake, 3),
            // Infernal
            (Characters.Lemure, 3),
            (Characters.Imp, 3),
            (Characters.Inferno, 3),
            (Characters.Incubus, 3),
            (Characters.Gobbler, 3),
            (Characters.Pit_Lord, 3),
            // Bestial
            (Characters.Dire_Wolf, 3),
            (Characters.Bully_Toad, 3),
            (Characters.Black_Asp, 3),
            (Characters.Spider_Queen, 3),
            (Characters.Arch_Druid, 3),
            (Characters.Vine_Behemoth, 3),
            // Aberrant
            (Characters.Slime, 3),
            (Characters.Gazer, 3),
            (Characters.Morlock, 3),
            (Characters.Deep_Hound, 3),
            (Characters.Mind_Eater, 3),
            (Characters.Deep_Tyrant, 3),
            // Aquatic
            (Characters.Mer_Guard, 3),
            (Characters.Sea_Worm, 3),
            (Characters.Man_O_War, 3),
            (Characters.Chomper, 3),
            (Characters.Kraken, 3),
            (Characters.Trident_King, 3),
        };
        #endregion

        public static Dictionary<string, List<(Characters, int)>> Presets = new Dictionary<string, List<(Characters, int)>>
        {
            { "BaseDeck", BaseDeck }
        };

    }
}
