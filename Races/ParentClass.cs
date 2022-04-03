using Newtonsoft.Json;
using System;
using Terraria;
namespace Trinitarian.Races
{
    /// <summary>
    /// This class will serve as a base for every new race added. 
    /// </summary>
    public abstract class Race
    {
       
        /// <summary>
        /// the current(called every tick) passive
        /// </summary>
        public virtual void Passive( Player p)
        {
            //Main.NewText("no Passive");
        }
        public virtual int HpChange() {
            return 0;
        }

        public virtual int DefIncrease()
        {
            return 0;
        }
        public virtual float MoveSpeed()
        {
            return 0;
        }
        /// <summary>
        /// If your race has the same changes in stats as another, make this diffrent to stop them from being flagged as the same class in the save/load procces. 
        /// </summary>
        /// <returns>amongus</returns>
        public virtual int ID()
        {
            return 0;
        }
        
        /// the int corrsponding to the race. used for save and load + SetFromType
        /// </summary>
        /// <returns></returns>
        public  int GetCurrentRace()
        {
            for(int i = 0; i < RacePlayer.Races.Count; i++)
            {
                Race r = RacePlayer.Races[i];
                if (r.DefIncrease() == this.DefIncrease() && this.HpChange() == r.HpChange() && r.MoveSpeed() == this.MoveSpeed() && r.ID()  == this.ID())
                {
                    return i;
                }
            }
            return 0;
        }
        public static void SetFromType(Player p, int type)
        {
            p.GetModPlayer<RacePlayer>().CurrentRace = RacePlayer.Races[type];
        }
        /// <summary>
        /// Call after changing race
        /// </summary>
        /// <param name="p"> the player being effectede</param>
        public void DoRaceChanges(Player p)
        {
            p.moveSpeed += MoveSpeed();
            p.maxRunSpeed += MoveSpeed();
            p.statLifeMax2 += HpChange();
            p.statDefense += DefIncrease();
        }


    }
}
