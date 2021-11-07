using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.QuestItems.Wizard
{
    public class WizardToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wizard Token");
            Tooltip.SetDefault("Take this to the quest master.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.maxStack = 999;
        }
    }
}