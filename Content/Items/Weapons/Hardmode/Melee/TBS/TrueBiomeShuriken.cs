﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee.TBS;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Items.Materials.Bars;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.TBS
{
	public class TrueBiomeShuriken : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Contains the essence of Terraria\nThrows an extra projectile that changes effects given based off of the biome you're in");
		}
		public override void SetDefaults()
		{
			item.UseSound = SoundID.Item1;
			item.shootSpeed = 18;
			item.crit = 12;
			item.damage = 68;
			item.knockBack = 8f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 12;
			item.useTime = 12;
			item.width = 30;
			item.height = 30;
			item.maxStack = 1;
			item.rare = ItemRarityID.Lime;
			item.consumable = false;
			item.noUseGraphic = true;
			item.melee = true;
			item.autoReuse = true;
			item.value = Item.sellPrice(gold: 5);
			item.shoot = ModContent.ProjectileType<TrueBiomeShurikenProj>();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY);
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<TrueBiomeShurikenProj>(), damage, knockBack, player.whoAmI);
			perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<TrueBiomeShurikenBeam>(), damage, knockBack, player.whoAmI);
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
			recipe.AddIngredient(ItemID.ShroomiteBar, 8);
            recipe.AddIngredient(ModContent.ItemType<Mechtide>(), 18);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.DemonAltar);
			recipe.AddRecipe();
		}
	}
}