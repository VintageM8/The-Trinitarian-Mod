using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Content.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee.Stormbreaker;
using System;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.Stormbreaker; 

public class LightingAxe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Lightning Breaker");
        Tooltip.SetDefault("Shoots an axe that harnasses the power of thunder.\nThe axe explodes into a burst of lightning.");
    }

    public override void SetDefaults()
    {
        Item.damage = 48;
        Item.width = 60;
        Item.height = 60;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.crit = 9;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.DamageType = DamageClass.Melee;
        Item.noMelee = true;
        Item.knockBack = 5;
        Item.useTurn = false;
        Item.value = Item.sellPrice(0, 10, 0, 0);
        Item.rare = ItemRarityID.Lime;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<LightAxe>();
        Item.shootSpeed = 10f;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemType<VikingMetal>(), 25)
            .AddTile(TileID.Anvils)
            .Register();
    }
}
