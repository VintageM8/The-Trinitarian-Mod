using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.BlueBlade
{
    public class SunWrath : ModProjectile
    {
        int i;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sun Wrath");
        }
        public override void SetDefaults()
        {
            Projectile.width = 2;
            Projectile.height = 2;
            drawOffsetX = -45;
            Projectile.alpha = 255;
            drawOriginOffsetY = 0;
            Projectile.damage = 65;
            drawOriginOffsetX = 23;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = 5;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 600;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
            i++;
            if (i % 1 == 0)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width / 2, Projectile.height / 2, DustID.TeleportationPotion);
            }
        }
    }
}