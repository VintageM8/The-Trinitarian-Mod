using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Buffs.Damage;

public class HolySmite : ModBuff {
    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Holy Smite");
        Description.SetDefault("Thou brûcan onemn dôð Sôðcyning.");
        Main.debuff[Type] = true; //denotes that is a debuff
        Main.pvpBuff[Type] = true; //denotes that players can get this in pvp i think? I'm not sure
    }

    public override void Update(NPC npc, ref int buffIndex) {
        npc.lifeRegen -= 8;

        int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.PinkFairy);
        Main.dust[dust].scale = 1.9f;
        Main.dust[dust].velocity *= 3f;
        Main.dust[dust].noGravity = true;
    }
}