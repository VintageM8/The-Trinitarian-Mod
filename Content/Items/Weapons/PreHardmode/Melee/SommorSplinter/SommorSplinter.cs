using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Content.Items.Weapons.PreHardmode.Melee.SommorSplinter;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Melee.SommorSplinter
{
    public class SommorSplinter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sommor Splinter");
            Tooltip.SetDefault("Summons daggers around you.");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.width = 40;
            item.height = 40;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 10;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.consumable = false;
            item.noUseGraphic = true;
            item.melee = true;
            item.shoot = ModContent.ProjectileType<AshenSplinterproj>();
            item.shootSpeed = 20f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<UraniumBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 3;
        }
    }
}