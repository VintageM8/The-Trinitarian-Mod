using Trinitarian.Projectiles.Magus;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using Terraria;

namespace Trinitarian.Items.Weapons.Magus.PreHardmode
{
    public class CrownofMadness : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crown of Madness");
            Tooltip.SetDefault("All players within range have their attack increased\n" +
                "Only a true master of the mystic arts can cast a rune.");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.width = 42;
            item.noUseGraphic = true;
            item.height = 42;
            item.rare = ItemRarityID.Orange;
            item.useAnimation = 20;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = true;
            item.UseSound = SoundID.Item103;
            item.consumable = false;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<Rune>();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldCrown, 1);
            recipe.AddIngredient(ItemID.CrimtaneOre, 19);
            recipe.AddIngredient(ModContent.ItemType<FirePart>(), 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.GoldCrown, 1);
            recipe2.AddIngredient(ItemID.DemoniteOre, 19);
            recipe2.AddIngredient(ModContent.ItemType<FirePart>(), 1);
            recipe2.AddTile(TileID.DemonAltar);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
