using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Melee
{
	public class LightingAxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning Breaker");
			Tooltip.SetDefault("Shoots a bolt of lighting");
		}

		public override void SetDefaults()
		{
			item.damage = 103;
			item.melee = true;
			item.width = 64;
			item.height = 64;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = Item.sellPrice(0, 25, 0, 0);
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<VikingMetal>(), 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}