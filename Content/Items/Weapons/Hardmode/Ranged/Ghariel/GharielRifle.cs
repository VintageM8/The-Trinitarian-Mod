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
			item.damage = 40;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
            item.knockBack = 4;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.sellPrice(0, 2, 0, 0);
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
     
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.TitaniumBar, 5);
			recipe.AddIngredient(ModContent.ItemType<OceanBar>(),5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
            recipe.AddRecipe();
            
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe2.AddIngredient(ItemID.AdamantiteBar, 5);
			recipe2.AddIngredient(ModContent.ItemType<OceanBar>(),5);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
		
	}
}