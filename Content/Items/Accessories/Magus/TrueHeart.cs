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
            Item.width = 20;
            Item.height = 32;
            Item.value = Item.buyPrice(0, 5, 0, 0);
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //player.GetModPlayer<TrinitarianPlayer>().TrueHeart = true;
            player.statLifeMax2 += 75;
        }
    }
}