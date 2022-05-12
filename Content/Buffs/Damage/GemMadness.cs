using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Buffs.Damage
{
    public class GemMadness : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem Madness");
            Description.SetDefault("You are frozen in place.");
            Main.debuff[Type] = true; //denotes that is a debuff
            Main.pvpBuff[Type] = false; //denotes that players can get this in pvp i think? I'm not sure

        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (!npc.boss)
            {
                npc.velocity.X *= 0f;
                npc.velocity.Y *= 0f;

                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.PinkTorch);
                Main.dust[dust].scale = 1.9f;
                Main.dust[dust].velocity *= 3f;
                Main.dust[dust].noGravity = true;
            }
                
        }
    }
}