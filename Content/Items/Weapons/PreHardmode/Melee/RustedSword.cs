using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Melee
{
    public class RustedSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rusted Sword");
        }

        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.knockBack = 1f;
            Item.value = Item.sellPrice(0, 0, 35, 22);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.crit = 2;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.scale = 1.2f;
            Item.useTurn = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddTile(TileID.Anvils)
                .AddIngredient(ModContent.ItemType<RustyMetal>(), 8)
                .Register();
        }
    }
}