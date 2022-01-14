using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Buffs.Potion;

namespace Trinitarian.Items.Potions
{
    public class OceanPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essance of the Ocean");
            Tooltip.SetDefault("Your stats increase in the Ocean Biome.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 1;
            item.consumable = false;
            item.rare = ItemRarityID.Orange;
            item.buffType = ModContent.BuffType<OceanEssanceBuff>();
            item.buffTime = 7200;
            item.value = Item.buyPrice(gold: 5);
        }
    }
}