using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Quests.Hunts
{
    public class DarkInvasion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Invasion");
            Tooltip.SetDefault("A shadowy, chaotic eye lurks in the darkness\nKill it before it mark our world for the armies of the occult.");
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