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
            Item.accessory = true;
            Item.width = 26;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.value = Item.buyPrice(0, 25, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TrinitarianPlayer>().Dartboard = true;
            player.GetDamage(DamageClass.Ranged) += 0.08f;
        }
    }
}