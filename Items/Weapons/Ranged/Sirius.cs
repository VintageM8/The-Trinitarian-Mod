using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using Microsoft.Xna.Framework;

namespace Trinitarian.Items.Weapons.Ranged
{
	public class Sirius : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sirius");
			Tooltip.SetDefault("Changes Bullets to Chlorophyte Bullets");
		}

		public override void SetDefaults()
		{
			item.damage = 140;
			item.ranged = true;
			item.width = 50;
			item.height = 28;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 35;
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.shootSpeed = 18f;
			item.useAmmo = AmmoID.Bullet;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.ChlorophyteBullet;
            }
            return true;
			/* Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true; */
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.Anvils);
			recipe.AddIngredient(ItemID.FragmentVortex, 25);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}