using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Buffs.Damage;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Magic.SeashellBag
{
    public class SeashellBagProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 2;
            aiType = ProjectileID.Shuriken;
            Projectile.width = 40;
            Projectile.penetrate = 3;
            Projectile.height = 36;
            Projectile.friendly = true;
            Projectile.light = 0.40f;
        }

        public override void Kill(int TimeLeft)
		{
			for (int i = 0; i < 30; i++)
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Water);
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < Main.rand.Next(3, 5); i++)
			{
				Vector2 perturbedSpeed = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
				Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<OceanRune>(), 40, 5f, Projectile.owner);
			}

		}
       
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffType<Drowning>(), 240);
        }
    }
}