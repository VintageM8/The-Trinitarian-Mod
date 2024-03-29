﻿using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Content.Buffs.Minion
{
    public class IceDragBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Dragon");
            Description.SetDefault("A powerful frost dragon will fight for your cause.");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("FrostDragonproj").Type] > 0)
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