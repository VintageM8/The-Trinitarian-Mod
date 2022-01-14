using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Mage
{
    public class WaterStaffCentral : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Bendness");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 16;
            projectile.aiStyle = 43;
            aiType = 227;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 54;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            var player = Main.player[projectile.owner];
            if (Main.myPlayer != projectile.owner)
                return;
            Vector2 vector;
            vector.X = Main.MouseWorld.X - 30f;
            vector.Y = Main.MouseWorld.Y - 30f;
            projectile.netUpdate = true;
            projectile.position = vector;
        }

        public override void Kill(int timeLeft)
        {
            var player = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 75f, 0.0f, 0.2f, ModContent.ProjectileType<WaterMagic>(), (int)(15 * player.magicDamage), 3.0f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X - 75f, projectile.Center.Y, 0.2f, 0.0f, ModContent.ProjectileType<WaterMagic>(), (int)(15 * player.magicDamage), 3.0f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 75f, 0.0f, -0.2f, ModContent.ProjectileType<WaterMagic>(), (int)(15 * player.magicDamage), 3.0f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X + 75f, projectile.Center.Y, -0.2f, 0.0f, ModContent.ProjectileType<WaterMagic>(), (int)(15 * player.magicDamage), 3.0f, projectile.owner, 0.0f, 0.0f);
        }
    }
}
