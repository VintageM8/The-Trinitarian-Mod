using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Melee.SeaBlade
{
    public class JörmungandrBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jörmungandr's Blade");
            Tooltip.SetDefault("Does stuff");
        }

        public override void SetDefaults()
        {
            Item.damage = 37;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 25;
            Item.useTime = 10;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 0, 35, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("PrismSlash").Type;
            Item.shootSpeed = 25f;
            Item.channel = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemType<OceanBar>(), 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}