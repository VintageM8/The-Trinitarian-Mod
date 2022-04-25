using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.PreHardmode.Ranged.SoulEater;

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
            projectile.arrow = true;
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(6))
            {
                Dust.NewDust(projectile.Center, projectile.width, projectile.height, 199); 
            }
        }

        public override void Kill(int TimeLeft)
		{
			for (int i = 0; i < 30; i++)
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 199);
			Main.PlaySound(SoundID.Dig, projectile.position);
			for (int i = 0; i < Main.rand.Next(1, 2); i++)
			{
				Vector2 perturbedSpeed = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<CorruptHead>(), 40, 5f, projectile.owner);
			}

		}
    }
}