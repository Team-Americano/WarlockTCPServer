using System;
using System.Collections.Generic;
using System.Text;
using WarlockTCPServer.GameLogic.Actor;

namespace WarlockTCPServer.Constants
{
    public static class DeckConstants
    {
        #region Character Registry
        public enum Characters
        {
            // Undead
            Skeleton = 1,       // Undead Warden
            Zombie,             // Undead Brute
            Ghost,              // Undead Sorcerer
            Wraith,             // Undead Sorcerer
            Revenant,           // Undead Warden
            Lich,               // Undead Enchanter
            // Glacial
            Snowfriend,         // Glacial Enchanter
            Ice_Wasp,           // Glacial Stalker
            Frost_Sprite,       // Glacial Sorcerer
            Ice_Pike,           // Glacial Brute
            Glacial_Guard,      // Glacial Warden
            Ice_Drake,          // Glacial Warden
            // Infernal
            Lemure,             // Infernal Brute
            Imp,                // Infernal Stalker
            Inferno,            // Infernal Brute
            Incubus,            // Infernal Enchanter
            Gobbler,            // Infernal Trapper
            Pit_Lord,           // Infernal Brute
            // Bestial
            Dire_Wolf,          // Bestial Stalker
            Bully_Toad,         // Bestial Brute
            Black_Asp,          // Bestial Stalker
            Spider_Queen,       // Bestial Trapper
            Arch_Druid,         // Bestial Enchanter
            Vine_Behemoth,      // Bestial Trapper
            // Aberrant
            Slime,              // Aberrant Brute
            Gazer,              // Aberrant Sorcerer
            Morlock,            // Aberrant Brute
            Deep_Hound,         // Aberrrant Sorcerer
            Mind_Eater,         // Aberrant Stalker
            Deep_Tyrant,        // Aberrant Sorcerer
            // Aquatic
            Mer_Guard,          // Aquatic Warden
            Sea_Worm,           // Aquatic Stalker
            Man_O_War,          // Aquatic Trapper
            Chomper,            // Aquatic Brute
            Kraken,             // Aquatic Trapper
            Trident_King        // Aquatic Warden
        }
        #endregion

        #region Character Associations
        public static Dictionary<Characters, (ActorOrigins, ActorClasses, ActorRarities)> CharacterLegend = new Dictionary<Characters, (ActorOrigins, ActorClasses, ActorRarities)>
        {
            // Undead
            { Characters.Skeleton, (ActorOrigins.Undead, ActorClasses.Warden, ActorRarities.Common) },
            { Characters.Zombie, (ActorOrigins.Undead, ActorClasses.Brute, ActorRarities.Common) },
            { Characters.Ghost, (ActorOrigins.Undead, ActorClasses.Sorcerer, ActorRarities.Common) },
            { Characters.Wraith, (ActorOrigins.Undead, ActorClasses.Sorcerer, ActorRarities.Uncommon) },
            { Characters.Revenant, (ActorOrigins.Undead, ActorClasses.Warden, ActorRarities.Uncommon) },
            { Characters.Lich, (ActorOrigins.Undead, ActorClasses.Enchanter, ActorRarities.Rare) },
            // Glacial
            { Characters.Snowfriend, (ActorOrigins.Glacial, ActorClasses.Enchanter, ActorRarities.Common) },
            { Characters.Ice_Wasp, (ActorOrigins.Glacial, ActorClasses.Stalker, ActorRarities.Common) },
            { Characters.Frost_Sprite, (ActorOrigins.Glacial, ActorClasses.Sorcerer, ActorRarities.Common) },
            { Characters.Ice_Pike, (ActorOrigins.Glacial, ActorClasses.Brute, ActorRarities.Uncommon) },
            { Characters.Glacial_Guard, (ActorOrigins.Glacial, ActorClasses.Warden, ActorRarities.Uncommon) },
            { Characters.Ice_Drake, (ActorOrigins.Glacial, ActorClasses.Warden, ActorRarities.Rare) },
            // Infernal
            { Characters.Lemure, (ActorOrigins.Infernal, ActorClasses.Brute, ActorRarities.Common) },
            { Characters.Imp, (ActorOrigins.Infernal, ActorClasses.Stalker, ActorRarities.Common) },
            { Characters.Inferno, (ActorOrigins.Infernal, ActorClasses.Brute, ActorRarities.Common) },
            { Characters.Incubus, (ActorOrigins.Infernal, ActorClasses.Enchanter, ActorRarities.Uncommon) },
            { Characters.Gobbler, (ActorOrigins.Infernal, ActorClasses.Trapper, ActorRarities.Uncommon) },
            { Characters.Pit_Lord, (ActorOrigins.Infernal, ActorClasses.Brute, ActorRarities.Rare) },
            // Bestial
            { Characters.Dire_Wolf, (ActorOrigins.Bestial, ActorClasses.Stalker, ActorRarities.Common) },
            { Characters.Bully_Toad, (ActorOrigins.Bestial, ActorClasses.Brute, ActorRarities.Common) },
            { Characters.Black_Asp, (ActorOrigins.Bestial, ActorClasses.Stalker, ActorRarities.Common) },
            { Characters.Spider_Queen, (ActorOrigins.Bestial, ActorClasses.Trapper, ActorRarities.Uncommon) },
            { Characters.Arch_Druid, (ActorOrigins.Bestial, ActorClasses.Enchanter, ActorRarities.Uncommon) },
            { Characters.Vine_Behemoth, (ActorOrigins.Bestial, ActorClasses.Trapper, ActorRarities.Rare) },
            // Aberrant
            { Characters.Slime, (ActorOrigins.Aberrant, ActorClasses.Brute, ActorRarities.Common) },
            { Characters.Gazer, (ActorOrigins.Aberrant, ActorClasses.Sorcerer, ActorRarities.Common) },
            { Characters.Morlock, (ActorOrigins.Aberrant, ActorClasses.Brute, ActorRarities.Common) },
            { Characters.Deep_Hound, (ActorOrigins.Aberrant, ActorClasses.Sorcerer, ActorRarities.Uncommon) },
            { Characters.Mind_Eater, (ActorOrigins.Aberrant, ActorClasses.Stalker, ActorRarities.Uncommon) },
            { Characters.Deep_Tyrant, (ActorOrigins.Aberrant, ActorClasses.Sorcerer, ActorRarities.Rare) },
            // Aquatic
            { Characters.Mer_Guard, (ActorOrigins.Aquatic, ActorClasses.Warden, ActorRarities.Common) },
            { Characters.Sea_Worm, (ActorOrigins.Aquatic, ActorClasses.Stalker, ActorRarities.Common) },
            { Characters.Man_O_War, (ActorOrigins.Aquatic, ActorClasses.Trapper, ActorRarities.Common) },
            { Characters.Chomper, (ActorOrigins.Aquatic, ActorClasses.Brute, ActorRarities.Uncommon) },
            { Characters.Kraken, (ActorOrigins.Aquatic, ActorClasses.Trapper, ActorRarities.Uncommon) },
            { Characters.Trident_King, (ActorOrigins.Aquatic, ActorClasses.Warden, ActorRarities.Rare) }
        };
        #endregion

        #region Origins and Stats
        public enum ActorOrigins
        {
            Undead = 1,
            Glacial,
            Infernal,
            Bestial,
            Aberrant,
            Aquatic
        }

        public static Dictionary<ActorOrigins, (short health, short defense, short attack, short speed, short precison)> 
            BaseOrigins = new Dictionary<ActorOrigins, (short health, short defense, short attack, short speed, short precison)>
        {
            { ActorOrigins.Undead, (0, 0, 0, 0, 0) },
            { ActorOrigins.Undead, (0, 0, 0, 0, 0) },
            { ActorOrigins.Undead, (0, 0, 0, 0, 0) },
            { ActorOrigins.Undead, (0, 0, 0, 0, 0) },
            { ActorOrigins.Undead, (0, 0, 0, 0, 0) },
        };
        #endregion

        #region Classes and Stats
        public enum ActorClasses
        {
            Brute = 1,
            Warden,
            Sorcerer,
            Enchanter,
            Trapper,
            Stalker
        }
        #endregion

        #region Rarities and Stats
        public enum ActorRarities
        {
            Common = 1,
            Uncommon,
            Rare
        }
        #endregion



        #region Defunct
        //#region Player Deck Arrangements
        //public const short DeckSize = 30;
        //public const short HandSize = 5;
        //public const short PartySize = 6;
        //#endregion

        //#region Actor Distribution
        //// if set to true, then the actor aspects of Origin in each deck will be as equal as possible. If not, then it will be randomized.
        //public const bool EqualOriginDistribution = true;
        //// if set to true, then the actor aspects of Class in each deck will be as equal as possible. If not, then it will be randomized.
        //public const bool EqualClassDistribution = true;
        //#endregion

        //#region Class Presets
        //#region Brute
        //public const short BruteHealth = 60;
        //public const short BruteDefense = 30;
        //public const short BruteAttack = 35;
        //public const short BruteSpeed = 20;
        //public const short BrutePrecision = 15;
        //#endregion
        //#region Warden
        //public const short WardenHealth = 60;
        //public const short WardenDefense = 50;
        //public const short WardenAttack = 25;
        //public const short WardenSpeed = 20;
        //public const short WardenPrecision = 5;
        //#endregion
        //#region Sorcerer
        //public const short SorcererHealth = 20;
        //public const short SorcererDefense = 10;
        //public const short SorcererAttack = 80;
        //public const short SorcererSpeed = 40;
        //public const short SorcererPrecision = 0;
        //#endregion
        //#region Enchanter
        //public const short EnchanterHealth = 40;
        //public const short EnchanterDefense = 10;
        //public const short EnchanterAttack = 60;
        //public const short EnchanterSpeed = 40;
        //public const short EnchanterPrecision = 0;
        //#endregion
        //#region Trapper
        //public const short TrapperHealth = 40;
        //public const short TrapperDefense = 20;
        //public const short TrapperAttack = 30;
        //public const short TrapperSpeed = 25;
        //public const short TrapperPrecision = 60;
        //#endregion
        //#region Stalker
        //public const short StalkerHealth = 30;
        //public const short StalkerDefense = 20;
        //public const short StalkerAttack = 40;
        //public const short StalkerSpeed = 60;
        //public const short StalkerPrecision = 25;
        //#endregion
        //#endregion

        ////public const int CommonFrequency = 18; // 3 copies of 18 unique common cards
        ////public const int UncommonFrequency = 12; 
        ////public const int RareFrequency = 6;
        #endregion
    }
}
