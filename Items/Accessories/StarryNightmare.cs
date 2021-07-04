using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Accessories
{
	public class StarryNightmare : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starry Nightmare");
			Tooltip.SetDefault("From the far reaches of the galaxy");
		}

		public override void SetDefaults()
		{
			item.accessory = true;
			item.width = 36;
			item.height = 36;
			item.rare = ItemRarityID.Pink;
			item.value = Item.sellPrice(0, 0, 0, 30);
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 140;
			player.magicDamage += .10f;
			player.manaCost -= 10;
		}
	

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentNebula, 25);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddIngredient(ItemID.FallenStar, 100);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}