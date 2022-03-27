﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Buffs.Damage
{
    public class Stunned : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Stunned");
            Description.SetDefault("Bruh, Why you reading this, you shouldnt be....SMH YOU LOSER");
            Main.debuff[Type] = true; //denotes that is a debuff
            Main.pvpBuff[Type] = false; //denotes that players can get this in pvp i think? I'm not sure
            Main.buffNoSave[Type] = true; //denotes if this debuff will be saved upon exiting and re-entering a world. If you want the player that has this debuff to keep it if they exit and re-enter the world, change it to false
            longerExpertDebuff = false; //denotes that if an enemy inflicts this to you, it will not double the duration if you are in expert mode. Set this to true if you do want the duration to be doubled in Expert Mode.

        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (!npc.boss)
            {
                npc.velocity.X *= 0f;
                npc.velocity.Y *= 0f;

                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Electric);
                Main.dust[dust].scale = 1.9f;
                Main.dust[dust].velocity *= 3f;
                Main.dust[dust].noGravity = true;
            }

        }
    }
}