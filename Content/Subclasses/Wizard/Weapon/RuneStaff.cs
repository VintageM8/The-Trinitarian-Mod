/*using Microsoft.Xna.Framework;
using Trinitarian.Content.Projectiles.Subclass.Wizard;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Trinitarian.Content.Subclasses.Wizard.Weapon
{
	public class RuneStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Runic Wand");
			Tooltip.SetDefault("Shoots clumps of horrific runes\nKilling enemies with these runes releases homing shadow souls");
		}


		public override void SetDefaults()
		{
			Item.damage = 28;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 9;
			Item.width = 39;
			Item.height = 36;
			Item.useTime = 24;
			Item.useAnimation = 38;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.staff[Item.type] = true;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = Terraria.Item.sellPrice(0, 0, 8, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = false;
			Item.shoot = ModContent.ProjectileType<Runes>();
			Item.shootSpeed = 15f;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity)) * 45f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}
	}
}*/