﻿using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Content.Buffs.Minion
{
    public class FishBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Giant Fish");
            Description.SetDefault("A unusally large fish will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("GiantFish")] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}