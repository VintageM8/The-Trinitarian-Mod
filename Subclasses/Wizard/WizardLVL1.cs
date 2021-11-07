using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Wizard
{
    public class WizardLVL1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wizard: Level 1");
            Tooltip.SetDefault("Mage\n Increases magic damage by 3%, and decreases mana cost by 1%.\n decreased crit by 2%");
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
              player.magicDamage += 0.3f;
              player.magicCrit -= 02;
              player.manaCost -= 01;
           }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}