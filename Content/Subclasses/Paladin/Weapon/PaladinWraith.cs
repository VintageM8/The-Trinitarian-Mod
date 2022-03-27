using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Subclass.Paladin;

namespace Trinitarian.Content.Subclasses.Paladin.Weapon
{
	public class PaladinWraith : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Paladin Wrath");
			Tooltip.SetDefault("'The power of God is with you'");
		}


		public override void SetDefaults()
		{
			item.damage = 200;
			item.melee = true;
			item.width = 70;
			item.height = 76;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Terraria.Item.sellPrice(1, 0, 0, 0);
			item.rare = 12;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<HolyFire>();
			item.shootSpeed = 4f;
			item.autoReuse = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 origVect = new Vector2(speedX, speedY);
			//generate the remaining projectiles

			Vector2 newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(72, 1800) / 10));
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, ModContent.ProjectileType<PalaBeam>(), damage, knockBack, player.whoAmI, 0f, 0f);
			newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(72, 1800) / 10));
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, ModContent.ProjectileType<PalaBeam2>(), damage, knockBack, player.whoAmI, 0f, 0f);
			newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(72, 1800) / 10));
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, ModContent.ProjectileType<PalaBeam>(), damage, knockBack, player.whoAmI, 0f, 0f);
			newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(72, 1800) / 10));
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, ModContent.ProjectileType<PalaBeam2>(), damage, knockBack, player.whoAmI, 0f, 0f);
			newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(72, 1800) / 10));
			Projectile.NewProjectile(position.X, position.Y, newVect.X * 1.5f, newVect.Y * 1.5f, ModContent.ProjectileType<PalaBeam>(), damage, knockBack, player.whoAmI, 0f, 0f);

			return false;
		}
	}
}