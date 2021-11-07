using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Wizard
{
    public class WizardLVL2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wizard: Level 2");
            Tooltip.SetDefault("Mage\n Increases magic damage by 5%, and decreases mana cost by 3%.\n decreased crit by 4%");
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
              player.magicDamage += 0.5f;
              player.magicCrit -= 04;
              player.manaCost -= 03;
           }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 45);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}