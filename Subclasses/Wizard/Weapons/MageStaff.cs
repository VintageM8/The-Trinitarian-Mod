using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Wizard.Weapons
{
    public class MageStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mage's Staff");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.magic = true;
            item.mana = 12;
            item.width = 42;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ProjectileID.ApprenticeStaffT3Shot;
            item.shootSpeed = 8f;
        }
    }
}