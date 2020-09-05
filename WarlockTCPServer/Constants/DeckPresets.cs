using System.Collections.Generic;
using static WarlockTCPServer.Constants.DeckConstants;

namespace WarlockTCPServer.Constants
{
    public static class DeckPresets
    {
        public static Dictionary<string, List<(Characters, int)>> Presets = new Dictionary<string, List<(Characters, int)>>
        {
            { "BaseDeck", BaseDeck }
        };

        #region Base Deck
        public static List<(Characters character, int amount)> BaseDeck = new List<(Characters character, int amount)>
        {   // Undead
            (Characters.Skeleton, 3),
            (Characters.Zombie, 3),
            (Characters.Ghost, 3),
            (Characters.Wraith, 2),
            (Characters.Revenant, 2),
            (Characters.Lich, 1),
            // Glacial
            (Characters.Snowfriend, 3),
            (Characters.Ice_Wasp, 3),
            (Characters.Frost_Sprite, 3),
            (Characters.Ice_Pike, 2),
            (Characters.Glacial_Guard, 2),
            (Characters.Ice_Drake, 1),
            // Infernal
            (Characters.Lemure, 3),
            (Characters.Imp, 3),
            (Characters.Inferno, 3),
            (Characters.Incubus, 2),
            (Characters.Gobbler, 2),
            (Characters.Pit_Lord, 1),
            // Bestial
            (Characters.Dire_Wolf, 3),
            (Characters.Bully_Toad, 3),
            (Characters.Black_Asp, 3),
            (Characters.Spider_Queen, 2),
            (Characters.Arch_Druid, 2),
            (Characters.Vine_Behemoth, 1),
            // Aberrant
            (Characters.Slime, 3),
            (Characters.Gazer, 3),
            (Characters.Morlock, 3),
            (Characters.Deep_Hound, 2),
            (Characters.Mind_Eater, 2),
            (Characters.Deep_Tyrant, 1),
            // Aquatic
            (Characters.Mer_Guard, 3),
            (Characters.Sea_Worm, 3),
            (Characters.Man_O_War, 3),
            (Characters.Chomper, 2),
            (Characters.Kraken, 2),
            (Characters.Trident_King, 1),
        };
        #endregion
    }
}
