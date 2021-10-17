using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Trinitarian.Items.Weapons.Ranged
{
	public class GharielRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghariel Rifle");
		}
		public override void SetDefaults()
		{
			item.damage = 20; 
			item.ranged = true;
			item.width = 40;
			item.height = 20; 
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; 
			item.knockBack = 4;
			item.value = 40000;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true; 
			item.shoot = 10;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(40));//change to reduce spread
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
	}
}