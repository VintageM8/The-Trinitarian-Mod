using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Trinitarian.Items.Weapons.Ranged
{
	public class TempleStormer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Temple Stormer");
			Tooltip.SetDefault("Converts bullets into RocketII\n Shoots a 3 round burst");
		}

		public override void SetDefaults()
		{
			item.damage = 98;
			item.ranged = true;
			item.width = 50;
			item.height = 28;
			item.useTime = 7;
			item.useAnimation = 12;
			item.reuseDelay = 14;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 9f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.RocketII;
			}
			return true;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return !(player.itemAnimation < item.useAnimation - 2);
		}
	}
}