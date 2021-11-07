using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Paladin
{
    public class PaladinLVL2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paladin: Level 2");
            Tooltip.SetDefault("Melee\n Increases melee damage by 6%, and gives 5 defense.");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 0, 1);
            item.defense = 5;
        }

        public override void UpdateInventory(Player player)
	    {
		   if (base.item.favorited)
           {  
              player.meleeDamage += 0.6f;
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
