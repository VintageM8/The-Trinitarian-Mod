using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Paladin
{
	public class PaladinLVL6 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paladin: Level 6");
			Tooltip.SetDefault("Melee\n Increases melee damage by 28%, and gives 20 defense.");
		}

		public override void SetDefaults()
		{
			item.accessory = true;
			item.width = 26;
			item.height = 24;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(0, 0, 0, 1);
			item.defense = 20;
		}

		public override void UpdateInventory(Player player)
	    {
		   if (base.item.favorited)
           {  
              player.meleeDamage += 0.28f;
           }
        } 

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ModContent.ItemType<PaladinLVL5>(), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}