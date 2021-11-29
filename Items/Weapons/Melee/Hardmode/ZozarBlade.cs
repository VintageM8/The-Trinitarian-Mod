using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Melee;

namespace Trinitarian.Items.Weapons.Melee.Hardmode
{
    public class ZozarBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zozar's Blade");
            Tooltip.SetDefault("Shoots a projectile");
        }

        public override void SetDefaults()
        {
            item.damage = 60;
            item.melee = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<ZozarBladeproj>();
            item.shootSpeed = 10f;
        }
    }
}