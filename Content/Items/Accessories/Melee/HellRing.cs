using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;

namespace Trinitarian.Content.Items.Accessories.Melee
{
    public class HellRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell's Ring");
            Tooltip.SetDefault("Life is increased by 25\nLife regen increased\n Melee damage increased by 8%\n No fellowship for this ring");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 24;
            item.height = 26;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.rare = ItemRarityID.Blue;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 25;
            player.lifeRegen += 2;
            player.meleeDamage += 0.08f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 4);
            recipe.AddIngredient(ItemID.HellstoneBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
