using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Projectiles.Melee;

namespace Trinitarian.Items.Weapons.Melee
{
	public class IceSpear : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 23;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 32;
			item.shootSpeed = 5f;
			item.knockBack = 10f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<IceSpearproj>();	
		    item.value = Item.sellPrice(0, 5, 0, 0);
			item.noMelee = true;
			item.noUseGraphic = true;
			item.melee = true;
			item.autoReuse = false;
		}
	}
}