using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Content.Projectiles.Weapon.Mage;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Magic
{
    public class PoisonStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Staff");
            Tooltip.SetDefault("Inficts poisoned");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 25;
            item.magic = true;
            item.mana = 10;
            item.width = 42;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<PoisonStaffproj>();
            item.shootSpeed = 8f;
        }
    }
}