using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Hunts
{
    public class SludgyMess : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sludgy Mess");
            Tooltip.SetDefault("An evil sludge has taken root\nSwear your Oath to the Paladin cause and slay the monster!");
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
