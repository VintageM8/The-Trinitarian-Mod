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
            item.width = 18;
            item.height = 16;
            item.value = Item.sellPrice(0, 0, 80, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.04f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AntlionMandible, 10);
            recipe.AddIngredient(ItemID.FossilOre, 2);
            recipe.AddIngredient(ItemID.Amber, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}