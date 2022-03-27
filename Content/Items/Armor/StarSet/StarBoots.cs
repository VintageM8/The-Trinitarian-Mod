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
            item.width = 18;
            item.height = 16;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Orange;
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(ItemType<StarSteel>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}