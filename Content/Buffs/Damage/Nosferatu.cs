using Terraria;
using Terraria.ModLoader;
using Trinitarian.Common.Players;
using Trinitarian.Common.NPCs;

namespace Trinitarian.Content.Buffs.Damage
{
    public class Nosferatu : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nosferatu");
            Description.SetDefault("Health is rapidly deteriarating.");
            Main.debuff[Type] = true; //denotes that is a debuff
            Main.pvpBuff[Type] = true; //denotes that players can get this in pvp i think? I'm not sure
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<TrinitarianPlayer>().nosferatu = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<TrinitarianGlobalNPC>().nosferatu = true;
        }
    }
}

