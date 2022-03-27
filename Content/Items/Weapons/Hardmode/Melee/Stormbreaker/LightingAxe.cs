using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Content.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee.Stormbreaker;
using System;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.Stormbreaker
{
    public class LightingAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning Breaker");
            Tooltip.SetDefault("Shoots an axe that harnasses the power of thunder.\nThe axe explodes into a burst of lightning.");
        }

        public override void SetDefaults()
        {
            item.damage = 103;
            item.width = 60;
            item.height = 60;
            item.useTime = 20;
            item.useAnimation = 20;
            item.crit = 8;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.melee = true;
            item.noMelee = true;
            item.knockBack = 1;
            item.useTurn = false;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<LightAxe>();
            item.shootSpeed = 6f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<VikingMetal>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}