using System.Collections.Generic;

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
        public static Dictionary<Characters, (ActorOrigins, ActorClasses, ActorRarities, string name)> CharacterLegend = new Dictionary<Characters, (ActorOrigins, ActorClasses, ActorRarities, string name)>
        {
            // Undead
            { Characters.Skeleton, (ActorOrigins.Undead, ActorClasses.Warden, ActorRarities.Common, "Skeleton") },
            { Characters.Zombie, (ActorOrigins.Undead, ActorClasses.Brute, ActorRarities.Common, "Zombie") },
            { Characters.Ghost, (ActorOrigins.Undead, ActorClasses.Sorcerer, ActorRarities.Common, "Ghost") },
            { Characters.Wraith, (ActorOrigins.Undead, ActorClasses.Sorcerer, ActorRarities.Uncommon, "Wraith") },
            { Characters.Revenant, (ActorOrigins.Undead, ActorClasses.Warden, ActorRarities.Uncommon, "Revenant") },
            { Characters.Lich, (ActorOrigins.Undead, ActorClasses.Enchanter, ActorRarities.Rare, "Lich") },
            // Glacial
            { Characters.Snowfriend, (ActorOrigins.Glacial, ActorClasses.Enchanter, ActorRarities.Common, "Snowfriend") },
            { Characters.Ice_Wasp, (ActorOrigins.Glacial, ActorClasses.Stalker, ActorRarities.Common, "Ice Wasp") },
            { Characters.Frost_Sprite, (ActorOrigins.Glacial, ActorClasses.Sorcerer, ActorRarities.Common, "Frost Sprite") },
            { Characters.Ice_Pike, (ActorOrigins.Glacial, ActorClasses.Brute, ActorRarities.Uncommon, "Ice Pike") },
            { Characters.Glacial_Guard, (ActorOrigins.Glacial, ActorClasses.Warden, ActorRarities.Uncommon, "Glacial Guard") },
            { Characters.Ice_Drake, (ActorOrigins.Glacial, ActorClasses.Warden, ActorRarities.Rare, "Ice Drake") },
            // Infernal
            { Characters.Lemure, (ActorOrigins.Infernal, ActorClasses.Brute, ActorRarities.Common, "Lemure") },
            { Characters.Imp, (ActorOrigins.Infernal, ActorClasses.Stalker, ActorRarities.Common, "Imp") },
            { Characters.Inferno, (ActorOrigins.Infernal, ActorClasses.Brute, ActorRarities.Common, "Inferno") },
            { Characters.Incubus, (ActorOrigins.Infernal, ActorClasses.Enchanter, ActorRarities.Uncommon, "Incubus") },
            { Characters.Gobbler, (ActorOrigins.Infernal, ActorClasses.Trapper, ActorRarities.Uncommon, "Gobbler") },
            { Characters.Pit_Lord, (ActorOrigins.Infernal, ActorClasses.Brute, ActorRarities.Rare, "Pit Lord") },
            // Bestial
            { Characters.Dire_Wolf, (ActorOrigins.Bestial, ActorClasses.Stalker, ActorRarities.Common, "Dire Wolf") },
            { Characters.Bully_Toad, (ActorOrigins.Bestial, ActorClasses.Brute, ActorRarities.Common, "Bully Toad") },
            { Characters.Black_Asp, (ActorOrigins.Bestial, ActorClasses.Stalker, ActorRarities.Common, "Black Asp") },
            { Characters.Spider_Queen, (ActorOrigins.Bestial, ActorClasses.Trapper, ActorRarities.Uncommon, "Spider Queen") },
            { Characters.Arch_Druid, (ActorOrigins.Bestial, ActorClasses.Enchanter, ActorRarities.Uncommon, "Arch Druid") },
            { Characters.Vine_Behemoth, (ActorOrigins.Bestial, ActorClasses.Trapper, ActorRarities.Rare, "Vine Behemoth") },
            // Aberrant
            { Characters.Slime, (ActorOrigins.Aberrant, ActorClasses.Brute, ActorRarities.Common, "Slime") },
            { Characters.Gazer, (ActorOrigins.Aberrant, ActorClasses.Sorcerer, ActorRarities.Common, "Gazer") },
            { Characters.Morlock, (ActorOrigins.Aberrant, ActorClasses.Brute, ActorRarities.Common, "Morlock") },
            { Characters.Deep_Hound, (ActorOrigins.Aberrant, ActorClasses.Sorcerer, ActorRarities.Uncommon, "Deep Hound") },
            { Characters.Mind_Eater, (ActorOrigins.Aberrant, ActorClasses.Stalker, ActorRarities.Uncommon, "Mind Eater") },
            { Characters.Deep_Tyrant, (ActorOrigins.Aberrant, ActorClasses.Sorcerer, ActorRarities.Rare, "Deep Tyrant") },
            // Aquatic
            { Characters.Mer_Guard, (ActorOrigins.Aquatic, ActorClasses.Warden, ActorRarities.Common, "Mer Guard") },
            { Characters.Sea_Worm, (ActorOrigins.Aquatic, ActorClasses.Stalker, ActorRarities.Common, "Sea Worm") },
            { Characters.Man_O_War, (ActorOrigins.Aquatic, ActorClasses.Trapper, ActorRarities.Common, "Man-O-War") },
            { Characters.Chomper, (ActorOrigins.Aquatic, ActorClasses.Brute, ActorRarities.Uncommon, "Chomper") },
            { Characters.Kraken, (ActorOrigins.Aquatic, ActorClasses.Trapper, ActorRarities.Uncommon, "Kraken") },
            { Characters.Trident_King, (ActorOrigins.Aquatic, ActorClasses.Warden, ActorRarities.Rare, "Trident King") }
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

        public static Dictionary<ActorOrigins, (short health, short defense, short attack, short speed, short precision, string origin)> 
            OriginStats = new Dictionary<ActorOrigins, (short health, short defense, short attack, short speed, short precision, string origin)>
        {
            { ActorOrigins.Undead, (10, 0, 0, 0, 0, "Undead") },
            { ActorOrigins.Glacial, (0, 10, 0, 0, 0, "Glacial") },
            { ActorOrigins.Infernal, (0, 5, 5, 0, 0, "Infernal") },
            { ActorOrigins.Bestial, (0, 0, 10, 0, 0, "Bestial") },
            { ActorOrigins.Aberrant, (5, 0, 5, 0, 0, "Aberrant") },
            { ActorOrigins.Aquatic, (5, 5, 0, 0, 0, "Aquatic") }
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

        public static Dictionary<ActorClasses, (short health, short defense, short attack, short speed, short precision, string @class)>
            ClassStats = new Dictionary<ActorClasses, (short health, short defense, short attack, short speed, short precision, string @class)>
        {
            { ActorClasses.Brute, (60, 30, 35, 20, 15, "Brute") },
            { ActorClasses.Warden, (60, 50, 25, 20, 5, "Warden") },
            { ActorClasses.Sorcerer, (20, 10, 80, 40, 0, "Sorcerer") },
            { ActorClasses.Enchanter, (40, 10, 60, 40, 0, "Enchanter") },
            { ActorClasses.Trapper, (40, 20, 30, 60, 25, "Trapper") },
            { ActorClasses.Stalker, (30, 20, 40, 60, 25, "Stalker") }
        };
        #endregion

        #region Rarities and Stats
        public enum ActorRarities
        {
            Common = 1,
            Uncommon,
            Rare
        }

        public static Dictionary<ActorRarities, (short health, short defense, short attack, short speed, short precision, short manaCost, string rarity)>
            RarityStats = new Dictionary<ActorRarities, (short health, short defense, short attack, short speed, short precision, short manaCost, string rarity)>
        {
            { ActorRarities.Common, (0, 0, 0, 0, 0, 1, "Common") },
            { ActorRarities.Uncommon, (10, 10, 10, 0, 0, 2, "Uncommon") },
            { ActorRarities.Rare, (30, 30, 30, 0, 0, 3, "Rare") }
        };
        #endregion

        // TODO: Associate Actions/Abilites to Characters

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
