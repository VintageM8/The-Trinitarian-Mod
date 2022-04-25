using Microsoft.Xna.Framework;
using Trinitarian.Content.Projectiles.Subclass.Wizard;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
			item.damage = 28;
			item.magic = true;
			item.mana = 9;
			item.width = 39;
			item.height = 36;
			item.useTime = 24;
			item.useAnimation = 38;
			item.useStyle = ItemUseStyleID.HoldingOut;
			Item.staff[item.type] = true;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = Terraria.Item.sellPrice(0, 0, 8, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = ModContent.ProjectileType<Runes>();
			item.shootSpeed = 15f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}
	}
}