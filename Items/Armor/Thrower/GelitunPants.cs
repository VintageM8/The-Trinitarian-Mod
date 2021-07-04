using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Armor.Thrower
{
    [AutoloadEquip(EquipType.Legs)]
    public class GelitunPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gelitun Pants");
            Tooltip.SetDefault("15% Increased throwing damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 16;
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 25);
            recipe.AddIngredient(ItemID.IronBar, 8);
            recipe.AddIngredient(ItemID.PinkGel, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Anvils);
            recipe2.AddIngredient(ItemID.Gel, 25);
            recipe2.AddIngredient(ItemID.PinkGel, 5);
            recipe2.AddIngredient(ItemID.LeadBar, 8);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}