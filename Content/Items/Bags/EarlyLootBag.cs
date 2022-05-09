using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Content.Items.Materials.Parts;

namespace Trinitarian.Content.Items.Bags
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
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 26;
            Item.height = 34;
            Item.rare = ItemRarityID.White;
            Item.expert = false;
            Item.value = Item.sellPrice(0, 0, 0, 10);
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (Main.rand.Next(4) == 0)
                player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemID.ManaCrystal, 2);
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<RustyMetal>(), 2);
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemID.IronBar, 3);
            if (Main.rand.Next(5) == 0)
                player.QuickSpawnItem(player.GetSource_GiftOrReward(),ModContent.ItemType<IceShards>(), 2);
            player.QuickSpawnItem(player.GetSource_GiftOrReward(), ModContent.ItemType<FirePart>(), 1);
            if (Main.rand.Next(7) == 0)
                player.QuickSpawnItem(player.GetSource_GiftOrReward(),ItemID.IronAnvil, 1);
                player.QuickSpawnItem(player.GetSource_GiftOrReward(), ItemID.LifeCrystal, 1);
        }
    }
}