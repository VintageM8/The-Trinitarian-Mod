using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Trinitarian.Races 
{
	public class RacePlayer : ModPlayer
	{
        public static List<Race> Races= new List<Race>();
        public override void Initialize()
        {
            var types = typeof(Trinitarian.Common.Trinitarian).Assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.IsSubclassOf(typeof(Race)) && !type.IsAbstract)
                {
                    Race r = Activator.CreateInstance(type) as Race;
                    Races.Add(r);
                }
            }

        }

        public Race CurrentRace = new Norace();      
        public override void PreUpdateBuffs()
        {
       //     Main.NewText($"{CurrentRace.GetCurrentRace()}");
            CurrentRace.DoRaceChanges(Player);
            CurrentRace.Passive(Player);
        }
        public override TagCompound Save()
        {
            return new TagCompound {
            {"triRaceCur",CurrentRace.GetCurrentRace()},
    };
        }

        public override void Load(TagCompound tag)
        {
           Race.SetFromType(Player,tag.GetInt("triRaceCur"));
           
        }
    }
   
}
