using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Paladin.Weapons
{
	public class PlasmaSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plasma Blade");
		}

		public override void SetDefaults()
		{
			item.width = 89;
			item.damage = 115;
			item.crit += 35;
			item.melee = true;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = 5;
			item.knockBack = 6.5f;
			item.autoReuse = true;
			item.height = 128;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 10;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}
