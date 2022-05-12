using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Accessories.Melee
{
    public class WarriorOcean : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warrior's Ocean");
            Tooltip.SetDefault("Increases melee damage by 5% and provides water breathing");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 26;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 45, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) += 0.05f;
            player.gills = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemType<OceanBar>(), 4)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}