using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Localization;
using Trinitarian.Content.Projectiles.Misc.Orbiting;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Melee.SommorSplinter
{
    public class AshenSplinterproj : OrbitingProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = false;
            Projectile.width = 30;
            Projectile.penetrate = 1;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.light = 0f;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            Projectile.timeLeft = 60 * 60 * 3;
            ProjectileSlot = 1;
            Period = 300;
            PeriodFast = 100;
            ProjectileSpeed = 8;
            OrbitingRadius = 300;
            CurrentOrbitingRadius = 300;
        }
        public override void AI()
        {
            player = Main.player[Projectile.owner];
            RelativeVelocity = player.velocity;
            OrbitCenter = player.Center;
            base.AI();
        }
        public override void Kill(int timeLeft)
        {
            if (Proj_State == 1 || Proj_State == 2)
            {
                GeneratePositionsAfterKill();
            }
        }

        public override void Attack()
        {
            Vector2 ProjectileVelocity = Main.MouseWorld - Projectile.Center;
            if (ProjectileVelocity != Vector2.Zero)
            {
                ProjectileVelocity.Normalize();
            }
            ProjectileVelocity *= 16;
            Projectile.velocity = ProjectileVelocity;
            Proj_State = 5;
            //This method is responsible for correctly reordering the projetiles when one of them dies. We call this here to make sure the already fired projectiles do not count towards the current ones.
            GeneratePositionsAfterKill();
        }
    }
}