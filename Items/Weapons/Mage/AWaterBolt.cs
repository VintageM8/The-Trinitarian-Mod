using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Mage
{
	public class AWaterBolt : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Advanced Water Bolt");
		}

		public override void SetDefaults()
		{
			item.damage = 21;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.mana = 10;
			item.knockBack = 5f;
			item.rare = ItemRarityID.Orange;
			item.width = 38;
			item.height = 24;
			item.useTime = 17;
			item.useAnimation = 17;
			item.UseSound = SoundID.Item12;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 16f;
			item.shoot = ProjectileID.WaterBolt;
			item.value = Item.sellPrice(0, 0, 70, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WaterBolt, 1);
			recipe.AddIngredient(ItemID.Hellstone, 30);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}