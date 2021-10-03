﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Mage;

namespace Trinitarian.Items.Weapons.Mage
{
	class BookOfWhirlspool : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Sharknado is a great movie :).");
			DisplayName.SetDefault("Book of Whirlpool");
		}
		public override void SetDefaults()
		{
			item.damage = 10;
			item.magic = true;
			item.mana = 15;
			item.width = 40;
			item.height = 40;
			item.useTime = 40;
			item.useAnimation = 40;
			item.knockBack = 0;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item13;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Waternado>();
			item.shootSpeed = 10f;
			item.noMelee = true;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position += new Vector2(0, -18);
			return true;
		}
	}
}