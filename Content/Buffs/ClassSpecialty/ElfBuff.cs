﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Trinitarian.Content.Buffs.ClassSpecialty
{
    public class ElfBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forest's Blessing");
            Description.SetDefault("Your speed is being increased");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.09f;
        }
    }
}