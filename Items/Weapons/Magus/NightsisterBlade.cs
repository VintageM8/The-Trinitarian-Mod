using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Magus
{
	public class NightsisterBlade : MagusDamageItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nightsister's Blade");
			Tooltip.SetDefault("Forged from the fury of the night\n Deals Venom");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 59;
			item.width = 66;
			item.height = 66;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 12, 0, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddIngredient(ItemID.DarkShard, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Venom, 320);
		}
	}
}