using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Hunts
{
    public class ForestFraud : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fraud in the forest");
            Tooltip.SetDefault("An Eye claims to be the protecter of the forest.\nKill it and mark your alligance to the elvish way.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.maxStack = 1;
        }
    }
}
