using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Armor.LifelinkArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class LifelinkPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lifelink Plate");
            Tooltip.SetDefault("3% increased melee critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.LifeCrystal, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}