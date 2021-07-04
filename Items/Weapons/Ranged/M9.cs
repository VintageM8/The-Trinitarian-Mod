using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;

namespace Trinitarian.Items.Weapons.Ranged
{
	public class M9 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("M9");
		}

		public override void SetDefaults()
		{
			item.damage = 9;
			item.ranged = true;
			item.width = 50;
			item.height = 28;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 35;
			item.rare = 0;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 17f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.Anvils);
			recipe.AddIngredient(ModContent.ItemType<RustyScraps>(), 18);
			recipe.AddIngredient(ModContent.ItemType<GunParts>(), 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}