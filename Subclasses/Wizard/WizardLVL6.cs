using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Wizard
{
    public class WizardLVL6 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wizard: Level 6");
            Tooltip.SetDefault("Mage\n Increases magic damage by 20%, and decreases mana cost by 15%.\n decreased crit by 10%");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 0, 1);
        }

        public override void UpdateInventory(Player player)
        {
            if (base.item.favorited)
            {
                player.magicDamage += 0.20f;
                player.magicCrit -= 15;
                player.manaCost -= 09;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentNebula, 10);
            recipe.AddIngredient(ModContent.ItemType<WizardLVL5>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}