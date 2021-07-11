using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Trinitarian.Items.Weapons.Melee
{
	public class StabbyKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stabby Knife");
		}

		public override void SetDefaults()
		{
			item.damage = 45;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}