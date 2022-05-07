using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.TBS
{
	public class TrueBiomeShurikenProj : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.ignoreWater = true;
			Projectile.aiStyle = 2;
			aiType = ProjectileID.Shuriken;
			Projectile.width = 30;
			Projectile.penetrate = 1;
			Projectile.height = 30;
			Projectile.friendly = true;
		}
		public override void Kill(int TimeLeft)
		{
			for (int i = 0; i < 30; i++)
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke);
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < Main.rand.Next(3, 5); i++)
			{
				Vector2 perturbedSpeed = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
				Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<TrueBiomeShurikenBeam>(), 40, 5f, Projectile.owner);
			}

		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.Electrified, 120);
		}
    }
}