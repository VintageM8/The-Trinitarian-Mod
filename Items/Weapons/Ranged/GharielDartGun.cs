using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class GharielDartGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ghariel Dart Gun");
            Tooltip.SetDefault("Shoots darts.");
        }

        public override void SetDefaults()
        {
            item.damage = 68;
            item.ranged = true;
            item.width = 50;
            item.height = 28;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 35;
            item.rare = ItemRarityID.Lime;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = ProjectileID.PurificationPowder;
            item.shootSpeed = 18f;
            item.useAmmo = AmmoID.Dart;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(ItemID.HallowedBar, 4);
            recipe.AddIngredient(ItemID.DartRifle, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Furnaces);
            recipe2.AddIngredient(ItemID.HallowedBar, 4);
            recipe2.AddIngredient(ItemID.DartPistol, 1);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}