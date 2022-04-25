using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged.Ghariel
{
	public class GharielRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ghariel Rifle");
		}
		public override void SetDefaults()
		{
			Item.damage = 40;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
            Item.knockBack = 4;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 2, 0, 0);
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(40));//change to reduce spread
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
		
			return true;
		}
     
        public override void AddRecipes()
		{
            CreateRecipe(1)
				.AddIngredient(ItemID.IllegalGunParts, 1)
				.AddIngredient(ItemID.TitaniumBar, 5)
				.AddIngredient(ModContent.ItemType<OceanBar>(),5)
				.AddTile(TileID.MythrilAnvil)
                .Register();
			CreateRecipe(1)
				.AddIngredient(ItemID.IllegalGunParts, 1)
				.AddIngredient(ItemID.AdamantiteBar, 5)
				.AddIngredient(ModContent.ItemType<OceanBar>(),5)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
		
	}
}