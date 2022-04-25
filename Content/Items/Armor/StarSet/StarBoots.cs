using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Armor.StarSet
{
    [AutoloadEquip(EquipType.Legs)]
    public class StarBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Boots");
            Tooltip.SetDefault("10% Increased magic damage");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 16;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Orange;
            Item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Magic) += 0.10f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.MeteoriteBar, 10)
                .AddIngredient(ItemType<StarSteel>(), 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}