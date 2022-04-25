using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Accessories.Magus
{
    public class TrueHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Heart");
            Tooltip.SetDefault("Increases max health by 75\nReleases a rune that shoots homing blood clots");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 32;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //player.GetModPlayer<TrinitarianPlayer>().TrueHeart = true;
            player.statLifeMax2 += 75;
        }
    }
}