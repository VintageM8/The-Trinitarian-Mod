using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Tools
{
	public class StonePick : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Pickaxe");
	    }
		public override void SetDefaults()
		{
			item.damage = 4;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 16;
			item.useAnimation = 16;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 0, 45, 0);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 6;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.pick = 40;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 5);
			recipe.AddIngredient(ItemID.StoneBlock, 16);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}