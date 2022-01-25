using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Buffs
{
    public class HolySmite : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Holy Smite");
            Description.SetDefault("Thou brûcan onemn dôð Sôðcyning.");
            Main.debuff[Type] = true; //denotes that is a debuff
            Main.pvpBuff[Type] = true; //denotes that players can get this in pvp i think? I'm not sure
            Main.buffNoSave[Type] = true; //denotes if this debuff will be saved upon exiting and re-entering a world. If you want the player that has this debuff to keep it if they exit and re-enter the world, change it to false
            longerExpertDebuff = false; //denotes that if an enemy inflicts this to you, it will not double the duration if you are in expert mode. Set this to true if you do want the duration to be doubled in Expert Mode.
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<TrinitarianGlobalNPC>().HolySmite = true;

            int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.PinkFlame);
            Main.dust[dust].scale = 1.9f;
            Main.dust[dust].velocity *= 3f;
            Main.dust[dust].noGravity = true;
        }
    }
}
