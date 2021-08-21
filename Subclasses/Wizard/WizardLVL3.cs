using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Subclasses;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Subclasses.Wizard
{
    public class WizardLVL3 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wizard: Level 3");
            Tooltip.SetDefault("Mage\n Increases magic damage by 8%, and decreases mana cost by 5%.\n decreased crit by 8%");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 0, 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.8f;
            player.manaCost -= 5;
            player.magicCrit -= 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 45);
            recipe.AddIngredient(ModContent.ItemType<WizardLVL2>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}