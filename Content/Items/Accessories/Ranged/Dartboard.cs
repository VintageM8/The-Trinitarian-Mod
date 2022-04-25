using Terraria;
using Terraria.ID;
using Trinitarian.Common.Players;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Accessories.Ranged
{
    public class Dartboard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dartboard");
            Tooltip.SetDefault("Increased ranged damage by 8%\nRanged attacks may shoot out a dart.");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.value = Item.buyPrice(0, 25, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TrinitarianPlayer>().Dartboard = true;
            player.rangedDamage += 0.08f;
        }
    }
}