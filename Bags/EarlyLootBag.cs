using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Items.Materials.Parts;
using static Microsoft.Xna.Framework.Rectangle;

namespace Trinitarian.Items.Bags
{
	public class EarlyLootBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Early Loot Bag");
			Tooltip.SetDefault("Contains Early Loot\n{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 26;
			item.height = 34;
			item.rare = ItemRarityID.White;
			item.expert = false;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			if (Main.rand.Next(4) == 0)
				player.QuickSpawnItem(ItemID.ManaCrystal, 2);
			    player.QuickSpawnItem(ModContent.ItemType<RustyMetal>(), 10);
			    player.QuickSpawnItem(ItemID.IronBar, 3);
            if (Main.rand.Next(5) == 0)
                player.QuickSpawnItem(ModContent.ItemType<IceShards>(), 2);
				 player.QuickSpawnItem(ModContent.ItemType<FirePart>(), 1);
			if (Main.rand.Next(7) == 0)
				player.QuickSpawnItem(ItemID.LifeCrystal, 1);
		}
	}
}