using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Weapons.Ranged
{
    public class FrostedThrower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frosted Thrower");
            Tooltip.SetDefault("Shoots out frosty fire\nUses gel as ammo");
        }

        public override void SetDefaults()
        {
            item.damage = 28;
            item.ranged = true;
            item.width = 44;
            item.height = 16;
            item.useTime = 20;
            item.useAnimation = 20;
            item.crit = 0;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.shoot = ProjectileID.Flames;// Filler till projectile
            item.shootSpeed = 8f;
            item.useAmmo = AmmoID.Gel;
            item.scale = 1.15f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
    }
}