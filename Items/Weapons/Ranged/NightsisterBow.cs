using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Ammo;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Ranged
{
	public class NightsisterBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("NightSister's Bow");
		}

		public override void SetDefaults()
		{
			item.damage = 14;
			item.ranged = true;
			item.width = 32;
			item.height = 161;
			item.useTime = 16;
			item.useAnimation = 16;
			item.crit = 1;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(0, 0, 60, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<NightLaser>();
			item.shootSpeed = 20f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.DarkShard, 3);
			recipe.AddIngredient(ItemID.SoulofNight, 14);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}