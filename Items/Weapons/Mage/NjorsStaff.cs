using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Projectiles.Mage;

namespace Trinitarian.Items.Weapons.Mage
{
    public class NjorsStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Njor's Staff");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 22;
            item.magic = true;
            item.mana = 8;
            item.width = 34;
            item.height = 34;
            item.useTime = 29;
            item.useAnimation = 29;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<NjorsStaffproj>();
            item.shootSpeed = 10f;
        }
    }
}