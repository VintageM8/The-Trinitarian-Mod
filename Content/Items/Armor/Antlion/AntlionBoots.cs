using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Armor.Antlion
{
    [AutoloadEquip(EquipType.Legs)]
    public class AntlionBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Boots");
            Tooltip.SetDefault("4% Increased movment");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 16;
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.rare = ItemRarityID.Green;
            Item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.04f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.AntlionMandible, 10)
                .AddIngredient(ItemID.FossilOre, 2)
                .AddIngredient(ItemID.Amber, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}