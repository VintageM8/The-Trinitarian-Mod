using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Buffs
{
    public class Drowning : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Drowning");
            Description.SetDefault("You cannot breathe");
            Main.debuff[Type] = true; //denotes that is a debuff
            Main.pvpBuff[Type] = true; //denotes that players can get this in pvp i think? I'm not sure
            Main.buffNoSave[Type] = true; //denotes if this debuff will be saved upon exiting and re-entering a world. If you want the player that has this debuff to keep it if they exit and re-enter the world, change it to false
            longerExpertDebuff = false; //denotes that if an enemy inflicts this to you, it will not double the duration if you are in expert mode. Set this to true if you do want the duration to be doubled in Expert Mode.
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<TrinitarianPlayer>().drowning = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            // TODO: Not Implemented
            npc.GetGlobalNPC<TrinitarianGlobalNPC>().drowning = true;
        }
    }
}