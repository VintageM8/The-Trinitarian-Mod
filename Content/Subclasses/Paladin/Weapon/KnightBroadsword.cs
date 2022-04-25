using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Trinitarian.Content.Projectiles.Subclass.Paladin;
using System;

namespace Trinitarian.Content.Subclasses.Paladin.Weapon
{
    public class KnightBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knight's Broadsword");
            Tooltip.SetDefault("Does a slash attack.");
        }

        public override void SetDefaults()
        {
            item.damage = 23;
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
    }
}