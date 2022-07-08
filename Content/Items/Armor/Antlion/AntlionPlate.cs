using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Armor.Antlion
{
    [AutoloadEquip(EquipType.Body)]
    public class AntlionPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Plate");
            Tooltip.SetDefault("+1 minion slot");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.AntlionMandible, 15)
                .AddIngredient(ItemID.FossilOre, 3)
                .AddIngredient(ItemID.Amber, 4)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}