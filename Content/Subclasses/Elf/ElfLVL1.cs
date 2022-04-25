using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Buffs.ClassSpecialty;

namespace Trinitarian.Content.Subclasses.Elf
{
    public class ElfLVL1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elf: Ranger Specialty");
            Tooltip.SetDefault("Keep this item to obtain new items, weapons, and abilities.\nFavorite for a unique buff.");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 0, 1);
        }

        public override void UpdateInventory(Player player)
		{
			if (base.item.favorited)
			{
               player.AddBuff(ModContent.BuffType<ElfBuff>(), 60);
            }
        }
    }
}