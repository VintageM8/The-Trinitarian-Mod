using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Buffs;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Projectiles.Magus.Runes;
using Microsoft.Xna.Framework;

namespace Trinitarian.Projectiles.Magus.Spells
{
    public class SeashellBagProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.ignoreWater = true;
            projectile.aiStyle = 2;
            aiType = ProjectileID.Shuriken;
            projectile.width = 40;
            projectile.penetrate = 3;
            projectile.height = 36;
            projectile.friendly = true;
            projectile.light = 0.40f;
        }

        public override void Kill(int TimeLeft)
		{
			for (int i = 0; i < 30; i++)
				Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke);
			Main.PlaySound(SoundID.Dig, projectile.position);
			for (int i = 0; i < Main.rand.Next(3, 5); i++)
			{
				Vector2 perturbedSpeed = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<OceanRune>(), 40, 5f, projectile.owner);
			}

		}
       
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffType<Drowning>(), 240);
        }
    }
}