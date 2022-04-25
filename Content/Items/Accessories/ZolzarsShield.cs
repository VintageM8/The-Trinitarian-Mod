using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Accessories
{
    public class ZolzarsShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zolzar's Shield");
            Tooltip.SetDefault("Increases all class damage by 50%\nReduces damage by 25%");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.rare = ItemRarityID.Expert;
            item.accessory = true;
            item.defense = 25;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.allDamage += 0.50f;
            player.endurance += 0.25f;
        }
    }
}