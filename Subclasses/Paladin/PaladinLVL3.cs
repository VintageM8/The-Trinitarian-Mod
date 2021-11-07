using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Paladin
{
    public class PaladinLVL3 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paladin: Level 3");
            Tooltip.SetDefault("Melee\n Increases melee damage by 10%, and gives 7 defense.");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 0, 1);
            item.defense = 7;
        }

        public override void UpdateInventory(Player player)
	    {
		   if (base.item.favorited)
           {  
              player.meleeDamage += 0.10f;
           }
        } 
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 28);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
