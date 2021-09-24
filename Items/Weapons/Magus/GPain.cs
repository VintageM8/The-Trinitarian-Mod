using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Trinitarian.Projectiles.Ammo;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Magus
{
	public class GPain : MagusDamageItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galactic Pain");
			Tooltip.SetDefault("Inflicts pain");
		}

	    public override void SafeSetDefaults()
		{
			item.damage = 89;
			item.width = 112;
			item.height = 40;
			item.useTime = 16;
			item.useAnimation = 16;
			item.crit = 4;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 6f;
			item.value = Item.sellPrice(0, 25, 60, 0);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<PainLaser>();
			item.shootSpeed = 20f;
		}
	}
}