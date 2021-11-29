using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Magus.PreHardmode
{
    public class CausticMire : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caustic Mire");
            Tooltip.SetDefault("Inflicts Nosferatu.\nCaustic Mire, the black goo of death. Not many can wield it....much less hold it.");
        }
        public override void SafeSetDefaults()
        {
            item.UseSound = SoundID.Item1;
            item.crit = 4;
            item.damage = 34;
            item.knockBack = 8f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 35;
            item.useTime = 35;
            item.width = 40;
            item.height = 36;
            item.rare = ItemRarityID.Orange;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.maxStack = 1;
            item.autoReuse = true;
            item.value = Item.sellPrice(0, 0, 80, 0);
            item.shoot = ModContent.ProjectileType<GooOfDeath>();
            item.shootSpeed = 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 35);
            recipe.AddIngredient(ItemID.Bone, 28);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
