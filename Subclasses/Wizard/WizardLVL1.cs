using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Buffs.ClassSpecialty;

namespace Trinitarian.Subclasses.Wizard
{
    public class WizardLVL1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wizard: Mage Specialty");
            Tooltip.SetDefault("Keep this item to obtain new items, weapons, and abilities.");
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
               player.AddBuff(ModContent.BuffType<WizardBuff>(), 60);
            }
        }
    }
}