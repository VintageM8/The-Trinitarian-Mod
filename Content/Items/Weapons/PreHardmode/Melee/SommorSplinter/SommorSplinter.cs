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
            Item.damage = 15;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 10;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.consumable = false;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<AshenSplinterproj>();
            Item.shootSpeed = 20f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<UraniumBar>(), 8)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 3;
        }
    }
}