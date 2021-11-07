using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.QuestItems.Wizard
{
    public class FrozenHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Etoirir's Frozen Heart");
            Tooltip.SetDefault("Increases magic damage by 4%, and decreases mana cost by 3%.\n Increased crit by 2%");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(0, 5, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.04f;
            player.magicCrit -= 2;
            player.manaCost -= 0.03f;
        }
    }
}