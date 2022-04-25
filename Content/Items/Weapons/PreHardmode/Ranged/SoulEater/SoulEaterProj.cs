using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.PreHardmode.Ranged.SoulEater;
using Terraria.Audio;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged.SoulEater
{
    public class SoulEaterProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Eater");
        }

        public override void SetDefaults()
        {
            Projectile.arrow = true;
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(6))
            {
                Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, 199); 
            }
        }

        public override void Kill(int TimeLeft)
		{
			for (int i = 0; i < 30; i++)
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 199);
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < Main.rand.Next(1, 2); i++)
			{
				Vector2 perturbedSpeed = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
				Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<CorruptHead>(), 40, 5f, Projectile.owner);
			}

		}
    }
}