using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Armor.ReaperArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class ReaperGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reaper Greaves");
            Tooltip.SetDefault("8% Increased movment");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 16;
            item.value = Item.sellPrice(0, 1, 50, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.08f;
        }
    }
}