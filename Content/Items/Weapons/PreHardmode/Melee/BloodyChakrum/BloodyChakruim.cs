using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.PreHardmode.Melee.BloodyChakrum;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Melee.BloodyChakrum
{
    public class BloodyChakruim : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Chakram");
            Tooltip.SetDefault("Unleashes a spurt of blood when you hit a foe.");
        }

        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item1;
            Item.shootSpeed = 10;
            Item.crit = 4;
            Item.damage = 32;
            Item.knockBack = 5f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 13;
            Item.useTime = 13;
            Item.width = 22;
            Item.height = 22;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Blue;
            Item.consumable = false;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<BloodyChakramproj>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.TissueSample, 25)
                .AddIngredient(ItemID.ThornChakram, 1)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}