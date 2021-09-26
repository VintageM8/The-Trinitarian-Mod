using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Melee;

namespace Trinitarian.Items.Weapons.Melee
{
    public class BloodyChakruim : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Chakram");
        }

        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item1;
            item.shootSpeed = 10;
            item.crit = 4;
            item.damage = 32;
            item.knockBack = 5f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 13;
            item.useTime = 13;
            item.width = 22;
            item.height = 22;
            item.maxStack = 1;
            item.rare = ItemRarityID.Blue;
            item.consumable = false;
            item.noUseGraphic = true;
            item.melee = true;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<BloodyChakramproj>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TissueSample, 25);
            recipe.AddIngredient(ItemID.ThornChakram, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}