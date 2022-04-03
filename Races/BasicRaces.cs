using System;
using Terraria;

namespace Trinitarian.Races
{
    public class Norace : Race
    {
        public override void Passive(Player p)
        {
        }
        public override int HpChange() => 0;
        public override int DefIncrease() => 0;
      //  public override int GetCurrentRace() => (int)RacePlayer.RaceIDs.None;
 
    }

   
}