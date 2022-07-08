using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Armor.StarSet
{
    [AutoloadEquip(EquipType.Body)]
    public class StarPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Steel Plate");
            Tooltip.SetDefault("8% increased magic crit chance");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Orange;
            Item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Magic) += 8;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.MeteoriteBar, 15)
                .AddIngredient(ItemType<StarSteel>(), 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}