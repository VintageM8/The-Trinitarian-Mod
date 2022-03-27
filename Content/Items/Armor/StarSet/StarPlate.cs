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
            item.width = 30;
            item.height = 20;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 15);
            recipe.AddIngredient(ItemType<StarSteel>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}