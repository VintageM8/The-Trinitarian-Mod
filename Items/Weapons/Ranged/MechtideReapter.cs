using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Trinitarian.Items.Materials.Bars;

namespace Trinitarian.Items.Weapons.Ranged
{
	public class MechtideReapter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechtide Reapter");
			Tooltip.SetDefault("Turns arrows into Holy Arrows");
		}

        public override void SetDefaults()
        {
            item.damage = 54;
            item.ranged = true;
            item.width = 50;
            item.height = 28;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = 35;
            item.rare = ItemRarityID.White;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = ProjectileID.PurificationPowder;
            item.shootSpeed = 17f;
            item.useAmmo = AmmoID.Arrow;
        }

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.HolyArrow;
			}
			return true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.Anvils);
			recipe.AddIngredient(ModContent.ItemType<Mechtide>(), 5);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}