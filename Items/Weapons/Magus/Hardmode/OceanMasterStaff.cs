using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Trinitarian.Projectiles.Magus;

namespace Trinitarian.Items.Weapons.Magus.Hardmode
{
    public class OceanMasterStaff : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean Master Qaurterstaff");
            Tooltip.SetDefault("Deals Venom and Drowning.\nShoots a  projectile that gives an extra boost if you are in the Ocean Biome.");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 75;
            item.crit = 10;
            item.knockBack = 9f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 13;
            item.useTime = 13;
            item.width = 22;
            item.height = 22;
            item.maxStack = 1;
            item.rare = ItemRarityID.Cyan;
            item.consumable = false;
            item.noUseGraphic = true;
            item.melee = false;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<OceanMasterProj>();
            item.shootSpeed = 10;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 2;
        }
    }
}
