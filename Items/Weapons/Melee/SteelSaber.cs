using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials;
using Trinitarian.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Melee
{
	public class SteelSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
		    DisplayName.SetDefault("Steel Saber");
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = Item.buyPrice(gold: 1); 
			item.rare = 1;
			item.UseSound = SoundID.Item1;
		    item.autoReuse = false;
	    }
            
	     public override void AddRecipes()
		 {
			 ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<SteelBar>(), 10);
			 recipe.AddTile(TileID.Anvils);
			 recipe.SetResult(this);
			 recipe.AddRecipe();
		 }
	}
}