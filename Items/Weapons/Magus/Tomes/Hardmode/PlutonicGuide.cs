using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus.Tome;
using Trinitarian.Items.Materials.RadiatedSubclass;
using Trinitarian.Items.Weapons.Magus.Tomes.PreHardmode;

namespace Trinitarian.Items.Weapons.Magus.Tomes.Hardmode
{
    public class PlutonicGuide : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plutonic Guide");
            Tooltip.SetDefault("Shoots a projectile that infilcs Nofestru and Poison.");
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.damage = 138;
            item.width = 112;
            item.height = 40;
            item.useTime = 18;
            item.useAnimation = 18;
            item.crit = 8;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4f;
            item.value = Item.sellPrice(0, 1, 60, 0);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Plutonic>();
            item.shootSpeed = 12f;
        }
    }
}
