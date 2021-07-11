using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Projectiles.Melee;

namespace Trinitarian.Items.Weapons.Melee
{
	public class GiantIcicle : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 10;
			item.useStyle = 5;
			item.useAnimation = 28;
			item.useTime = 32;
			item.shootSpeed = 10f;
			item.knockBack = 7f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<IcicleSpearproj>();
			item.value = Item.sellPrice(0, 0, 80, 0);
			item.noMelee = true;
			item.noUseGraphic = true;
			item.melee = true;
			item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 5);
			recipe.AddIngredient(ItemID.IceBlock, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddTile(TileID.Anvils);
			recipe2.AddIngredient(ItemID.IceBlock, 15);
			recipe2.AddIngredient(ItemID.LeadBar, 5);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
	}
}