using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Content.Items.Materials.Parts;

namespace Trinitarian.Content.Items.Bags
{
    public class AdvancedLootBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Advanced Loot Bag");
            Tooltip.SetDefault("Contains Loot\n{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 26;
            Item.height = 34;
            Item.rare = ItemRarityID.LightRed;
            Item.expert = false;
            Item.value = Item.sellPrice(0, 0, 25, 0);
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (Main.rand.Next(4) == 0)
                player.QuickSpawnItem(ItemID.HallowedSeeds, 2);
            player.QuickSpawnItem(ItemID.CobaltBar, 2);
            if (Main.rand.Next(7) == 0)
                player.QuickSpawnItem(ItemID.MythrilAnvil, 1);
        }
    }
}