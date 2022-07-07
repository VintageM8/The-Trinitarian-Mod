using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Buffs.ClassSpecialty;

namespace Trinitarian.Content.Subclasses.Wizard
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
            Item.width = 26;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 0, 1);
        }

        public override void UpdateInventory(Player player)
		{
			if (base.Item.favorited)
			{
               player.AddBuff(ModContent.BuffType<WizardBuff>(), 60);
            }
        }
    }
}