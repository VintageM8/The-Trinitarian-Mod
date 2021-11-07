using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Buffs;
using Trinitarian.Projectiles.Magus;

namespace Trinitarian.Projectiles.Magus
{
    public class TrueOceanMasterProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.ignoreWater = false;
            projectile.width = 24;
            projectile.penetrate = -1;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.light = 1f;
            projectile.tileCollide = true;
            projectile.aiStyle = 3;
        }

        public override void Kill(int TimeLeft)
        {
            for (int i = 0; i < 30; i++)
                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke);
            Main.PlaySound(SoundID.Dig, projectile.position);
            for (int i = 0; i < Main.rand.Next(3, 5); i++)
            {
                Vector2 perturbedSpeed = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<OceanMastery>(), 40, 5f, projectile.owner);
            }

        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Dig, projectile.position);
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Venom, 300);
            target.AddBuff(BuffID.OnFire, 300);
            target.AddBuff(BuffID.Oiled, 300);
            target.AddBuff(BuffType<Drowning>(), 300);
        }
    }
}