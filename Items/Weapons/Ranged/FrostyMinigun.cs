using Terraria.ID;
using Terraria;
using Trinitarian.Items.Materials.Parts;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class FrostyMinigun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frosty Minigun");
            Tooltip.SetDefault("Shoots bullets out at high speed");
        }

        public override void SetDefaults()
        {
            item.damage = 8;
            item.ranged = true;
            item.width = 50;
            item.height = 28;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = 35;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = ProjectileID.PurificationPowder;
            item.shootSpeed = 27f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ModContent.ItemType<IceShards>(), 4);
            recipe.AddIngredient(ItemID.Minishark, 1);
            recipe.AddIngredient(ItemID.TissueSample, 8);
            recipe.SetResult(this);
            recipe.AddRecipe();

             ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Anvils);
            recipe2.AddIngredient(ItemID.Minishark, 1);
            recipe2.AddIngredient(ItemID.ShadowScale, 8);
            recipe.AddIngredient(ModContent.ItemType<IceShards>(), 4);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
