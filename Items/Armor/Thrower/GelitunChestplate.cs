using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Armor.Thrower
{
    [AutoloadEquip(EquipType.Body)]
    public class GelitunChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gelitun Chestplate");
            Tooltip.SetDefault("4% increased throwing critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownCrit += 4;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 40);
            recipe.AddIngredient(ItemID.PinkGel, 8);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Anvils);
            recipe2.AddIngredient(ItemID.Gel, 40);
            recipe2.AddIngredient(ItemID.PinkGel, 8);
            recipe2.AddIngredient(ItemID.LeadBar, 10);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}