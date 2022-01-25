using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Melee;

namespace Trinitarian.Items.Weapons.Melee.PreHardmode
{
    public class IceSpear : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 15;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 28;
            item.useTime = 32;
            item.shootSpeed = 5f;
            item.knockBack = 10f;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.shoot = ModContent.ProjectileType<IceSpearproj>();
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.melee = true;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ModContent.ItemType<IceShards>(), 12);
            recipe.AddIngredient(ItemID.TissueSample, 15);
            recipe.SetResult(this);
            recipe.AddRecipe();

             ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Anvils);
            recipe2.AddIngredient(ItemID.ShadowScale, 15);
            recipe.AddIngredient(ModContent.ItemType<IceShards>(), 12);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}