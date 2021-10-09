using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Armor.Summoner
{
    [AutoloadEquip(EquipType.Head)]
    public class ReaperHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reaper Hood");
            Tooltip.SetDefault("Regen increased by 12%");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<ReaperVest>() && legs.type == ItemType<ReaperGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+3 Minion slots";
            player.maxMinions += 3;
        }
    }
}