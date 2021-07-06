using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses
{
	public class NecromancerLVL1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Necromancer: Level 1");
			Tooltip.SetDefault("Summoner\n Increases summon damage by 3%, and increased summon slots by 1.");
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
			player.minionDamage += 0.3f;
			player.maxMinions += 1;
		}
	}
}