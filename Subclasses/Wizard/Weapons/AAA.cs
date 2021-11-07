using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles;

namespace Trinitarian.Subclasses.Wizard.Weapons
{
    public class AAA : ModItem
    {
        private Vector2 position;
        private float speedX;
        private float speedY;
        private int proj;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Mage's Rune");
            Tooltip.SetDefault("Shoots a Fireball \nRight click to shoot a burst of 5");
        }
        public override void SetDefaults()
        {
            item.damage = 53;
            item.magic = true;
            item.mana = 15;
            item.width = 42;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.Red;
            item.shoot = ModContent.ProjectileType<Fireballrune>();
            item.shootSpeed = 5;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useTime = 60;
                item.useAnimation = 60;
                item.shoot = ModContent.ProjectileType<Fireballshotblast>();
            }
            else
            {
                item.shoot = ModContent.ProjectileType<Fireballrune>();
            }
            return base.CanUseItem(player);
        }
    }
}