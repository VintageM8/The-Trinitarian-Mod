using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Weapons.Melee;
using Trinitarian.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Melee
{
	public class FlamingSteelSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flaming Steel Saber");
		}

		public override void SetDefaults()
		{
			item.damage = 22;
			item.melee = true;
			item.width = 48;
			item.height = 54;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = Item.sellPrice(0, 0, 80, 0);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<SteelSaber>(), 1);
			recipe.AddIngredient(ItemType<FirePart>(), 1);
			recipe.AddIngredient(ItemID.Obsidian, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}