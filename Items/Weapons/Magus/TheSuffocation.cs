using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Magus
{
	public class TheSuffocation : MagusDamageItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Suffocation");
		}

		public override void SafeSetDefaults()
		{
            item.damage = 67;
			item.crit = 8;
			item.knockBack = 5f;
            item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 13;
			item.useTime = 13;
			item.width = 22;
			item.height = 22;
			item.maxStack = 1;
			item.rare = ItemRarityID.Yellow;
			item.consumable = false;
			item.noUseGraphic = true;
			item.melee = false;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<Suffocationproj>();
			item.shootSpeed = 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TempleKey, 1);
            recipe.AddIngredient(ItemID.Ectoplasm, 15);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.ShroomiteBar, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}