using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Armor.ReaperArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class ReaperVest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reaper Vest");
            Tooltip.SetDefault("+2 minion slots");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 2;
        }
    }
}