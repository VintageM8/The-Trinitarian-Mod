using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Ocean
{
    public class UndeadTerror : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Undead Terror");
            Tooltip.SetDefault("In the depths of the ocean, many creatures harbor there\nOne such creature is the Sabertooth Fish.\nThey are rare but a select few have a very powerful item that can summon the dead of the sea.");
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