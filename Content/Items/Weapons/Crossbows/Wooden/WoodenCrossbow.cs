using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;

namespace Trinitarian.Content.Items.Weapons.Crossbows.Wooden
{
	public class WoodenCrossbow : ModItem
	{
		private int charges;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Crossbow");
			Tooltip.SetDefault("Hold to charge" + "\nRelease to fire a barrage of wooden bolts" + "\n Wooden bolts splinter and stick into enemies");
		}

		public override void SetDefaults()
		{
			item.damage = 28;
			item.ranged = true;
			item.width = 60;
			item.height = 62;
			item.useAnimation = 14;
			item.useTime = 14;
			item.useStyle = 5;
			item.noMelee = true;
			//item.value = 100000;
			item.rare = ItemRarityID.Green;
			item.channel = true;
			item.autoReuse = true;
			item.shoot = 12;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.WoodenArrowFriendly; 
		}

		public override void HoldItem(Player player)
		{
			if (!player.channel && charges > 0)
			{
				for (int i = 0; i < charges; i++)
				{
					Projectile shot = Main.projectile[Projectile.NewProjectile(player.MountedCenter, new Vector2(item.shootSpeed * Main.rand.NextFloat(0.75f, 1.333f), 0).RotatedBy((Main.MouseWorld - player.MountedCenter).ToRotation()).RotatedByRandom(0.5f), item.shoot, item.damage, item.knockBack, player.whoAmI)];
					shot.maxPenetrate = 1;
					shot.penetrate = 1;
					shot.timeLeft = 600;
				}
				charges = 0;

				Main.PlaySound(SoundID.Item, player.Center, 9);
			}
			else if (player.channel && !player.HasAmmo(item, false))
			{
				player.itemTime = 10;
				player.itemAnimation = 10;
			}

			if (player.channel)
			{
				player.itemRotation = (Main.MouseWorld - player.MountedCenter).ToRotation();
				if (player.direction == -1) { player.itemRotation += (float)Math.PI; }
			}
		}

		public override bool ConsumeAmmo(Player player)
		{
			return charges < 20;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (charges < 20)
			{
				charges++;
				Main.PlaySound(SoundID.Item, player.MountedCenter, 4);

				for (int i = 0; i < 5; i++)
				{
					Vector2 position30 = player.Center;
					int width27 = 0;
					int height27 = 0;
					float speedX13 = player.velocity.X * 0.5f;
					float speedY13 = player.velocity.Y * 0.5f;
					Color newColor = default(Color);
					Dust.NewDust(position30, width27, height27, 58, speedX13, speedY13, 150, newColor, 1.2f);
				}
				for (int i = 0; i < 3; i++)
				{
					Gore.NewGore(player.MountedCenter - new Vector2(8, 8), new Vector2(player.velocity.X * 0.2f, player.velocity.Y * 0.2f), Main.rand.Next(16, 18));
				}
			}

			return false;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-28, 0);
		}
	}
}
