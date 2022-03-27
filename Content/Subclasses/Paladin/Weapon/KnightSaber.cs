﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Common;

namespace Trinitarian.Content.Subclasses.Paladin.Weapon
{
    public class KnightSaber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knight's Saber");
            Tooltip.SetDefault("Does 80% more damage to unholy enemies.");
        }

        public override void SetDefaults()
        {
            item.damage = 32;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 10;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 2;
            item.value = Item.buyPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            if (TrinitarianLists.unholyEnemies.Contains(target.type))
            {
                damage = (int)(damage * 1.8f);
            }
        }
    }
}