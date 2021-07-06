using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses
{
	public class ElfLVL1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elf: Level 1");
			Tooltip.SetDefault("Ranger\n Increases ranged damage by 2%, and increased speed cost by 4%.");
		}

		public override void SetDefaults()
		{
			item.accessory = true;
			item.width = 26;
			item.height = 24;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(0, 0, 0, 1);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.rangedDamage += 0.3f;
			player.moveSpeed -= 0.02f;
		}
	}
}