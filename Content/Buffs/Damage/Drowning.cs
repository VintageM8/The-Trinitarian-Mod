using Terraria;
using Terraria.ModLoader;
using Trinitarian.Common.NPCs;

namespace Trinitarian.Content.Buffs.Damage
{
    public class Drowning : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Drowning");
            Description.SetDefault("You cannot breathe");
            Main.debuff[Type] = true; //denotes that is a debuff
            Main.buffNoSave[Type] = true; //denotes if this debuff will be saved upon exiting and re-entering a world. If you want the player that has this debuff to keep it if they exit and re-enter the world, change it to false
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
           
            npc.GetGlobalNPC<TrinitarianGlobalNPC>().drowning = true;
        }
    }
}