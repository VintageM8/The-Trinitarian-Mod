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
            Item.width = 26;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 0, 1);
        }

        public override void UpdateInventory(Player player)
		{
			if (base.Item.favorited)
			{
               player.AddBuff(ModContent.BuffType<ElfBuff>(), 60);
            }
        }
    }
}