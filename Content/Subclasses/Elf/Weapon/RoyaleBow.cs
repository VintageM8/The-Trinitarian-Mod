using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Trinitarian.Content.Projectiles.Subclass.Elf;

namespace Trinitarian.Content.Subclasses.Elf.Weapon
{
    public class RoyaleBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royale Bow");
            Tooltip.SetDefault("Shoots angelic metoers from the sky. Right click to summon them from your bow.\nHarnesses the true power of the heveans.\nThe most holy and dedicated elves can wield this.");
        }

        public override void SetDefaults()
        {
            Item.damage = 62;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 16;
            Item.height = 36;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.crit = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 0, 25, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<HolyAngel>();
            Item.shootSpeed = 7f;
			Item.useAmmo = AmmoID.Arrow;
        }

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			return base.CanUseItem(player);
		}


		public override float UseTimeMultiplier(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				return 1f;
			}
			return 0.75f;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				int num = Main.rand.Next(4, 6);
				for (int i = 0; i < num; i++)
				{
					float speedX2 = speedX + (float)Main.rand.Next(-30, 31) * 0.05f;
					float speedY2 = speedY + (float)Main.rand.Next(-30, 31) * 0.05f;
					float ai = Main.rand.Next(6);
					Projectile.NewProjectile(position.X, position.Y, speedX2, speedY2, type, damage, knockBack, player.whoAmI, ai, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
				}
				return false;
			}
			float shootSpeed = base.Item.shootSpeed;
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter);
			float num2 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
			float num3 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
			if (player.gravDir == -1f)
			{
				num3 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector.Y;
			}
			float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
			if ((float.IsNaN(num2) && float.IsNaN(num3)) || (num2 == 0f && num3 == 0f))
			{
				num2 = player.direction;
				num3 = 0f;
				num4 = shootSpeed;
			}
			else
			{
				num4 = shootSpeed / num4;
			}
			for (int j = 0; j < 4; j++)
			{
				vector = new Vector2(player.position.X + (float)player.width * 0.5f + (float)Main.rand.Next(201) * (0f - (float)player.direction) + ((float)Main.mouseX + Main.screenPosition.X - player.position.X), player.MountedCenter.Y - 600f);
				vector.X = (vector.X + player.Center.X) / 2f + (float)Main.rand.Next(-200, 201);
				vector.Y -= 100 * j;
				num2 = (float)Main.mouseX + Main.screenPosition.X - vector.X + (float)Main.rand.Next(-40, 41) * 0.03f;
				num3 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
				if (num3 < 0f)
				{
					num3 *= -1f;
				}
				if (num3 < 20f)
				{
					num3 = 20f;
				}
				num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
				num4 = shootSpeed / num4;
				num2 *= num4;
				num3 *= num4;
				float num5 = num2;
				float num6 = num3 + (float)Main.rand.Next(-40, 41) * 0.02f;
				float ai2 = Main.rand.Next(6);
				Projectile.NewProjectile(vector.X, vector.Y, num5 * 0.75f, num6 * 0.75f, type, damage, knockBack, player.whoAmI, ai2, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
			}
			return false;
		}
	}
}
