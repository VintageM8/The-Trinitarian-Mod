using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Materials.RadiatedSubclass
{
    public class MagusShards : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magus Shard");
            // ticksperframe, frameCount
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = false;
            ItemID.Sets.ItemNoGravity[item.type] = false;
        }

        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = 38;
            item.height = 32;
            item.maxStack = 999;
            item.value = 1000;
            item.rare = ItemRarityID.Red;
        }
    }
}