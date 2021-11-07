using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Projectiles.Magus;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Magus.PreHardmode
{
    public class SeashellBag : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seashell Bag");
            Tooltip.SetDefault("Inflicts Drowning.");
        }
        public override void SafeSetDefaults()
        {
            item.UseSound = SoundID.Item1;
            item.shootSpeed = 15;
            item.crit = 4;
            item.damage = 20;
            item.knockBack = 4f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 22;
            item.useTime = 22;
            item.width = 40;
            item.height = 36;
            item.rare = ItemRarityID.Green;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.maxStack = 1;
            item.autoReuse = true;
            item.value = Item.sellPrice(0, 59, 80, 0);
            item.shoot = ModContent.ProjectileType<SeashellBagProj>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<OceanBar>(), 8);
            recipe.AddIngredient(ItemID.Coral, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}