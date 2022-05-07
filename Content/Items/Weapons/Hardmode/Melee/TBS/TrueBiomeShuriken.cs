using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
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
			Item.UseSound = SoundID.Item1;
			Item.shootSpeed = 18;
			Item.crit = 12;
			Item.damage = 68;
			Item.knockBack = 8f;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 12;
			Item.useTime = 12;
			Item.width = 30;
			Item.height = 30;
			Item.maxStack = 1;
			Item.rare = ItemRarityID.Lime;
			Item.consumable = false;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Melee;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 5);
			Item.shoot = ModContent.ProjectileType<TrueBiomeShurikenProj>();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY);
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<TrueBiomeShurikenProj>(), damage, knockBack, player.whoAmI);
			perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<TrueBiomeShurikenBeam>(), damage, knockBack, player.whoAmI);
			return false;
		}
		public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient(ItemID.ShroomiteBar, 8)
                .AddIngredient(ModContent.ItemType<Mechtide>(), 18)
                .AddIngredient(ItemID.SoulofNight, 10)
				.AddTile(TileID.DemonAltar)
				.Register();
		}
	}
}