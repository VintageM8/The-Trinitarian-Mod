using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses
{
	public class PaladinLVL1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paladin: Level 1");
			Tooltip.SetDefault("Melee\n Increases melee damage by 3%, and gives 5 defense.\n Slows you down by 5%");
		}

		public override void SetDefaults()
		{
			item.accessory = true;
			item.width = 26;
			item.height = 24;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(0, 0, 0, 1);
			item.defense = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamage += 0.3f;
			player.moveSpeed -= 0.05f;
		}
	}
}