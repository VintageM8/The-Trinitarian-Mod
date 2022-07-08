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
            Item.width = 30;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 2, 50, 0);
            Item.rare = ItemRarityID.Green;
            Item.defense = 20;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 2;
        }
    }
}