using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.RadiatedSubclass;
using Trinitarian.Projectiles.Magus;

namespace Trinitarian.Items.Weapons.Magus
{
    public class SommorSplinter : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sommor Splinter");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 15;
            item.width = 40;
            item.height = 40;
            item.useTime = 10;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.White;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<AshenSplinterproj>();
            item.shootSpeed = 20f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Uranium>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}