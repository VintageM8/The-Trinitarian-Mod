using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Weapon.Melee
{
    public class Suffocationproj : ModProjectile
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
        int Suffocationtime = 0;
        public override void AI()
        {
            if (Main.rand.NextBool(6))
            {
                Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.Blood);
                Suffocationtime++;

                if (Suffocationtime == 8)
                {                   
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 2, ProjectileID.CursedFlameFriendly, 45, projectile.knockBack, Main.myPlayer);
                    Suffocationtime = 0;
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Dig, projectile.position);
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Confused, 300);
            target.AddBuff(BuffID.CursedInferno, 300);
            target.AddBuff(BuffID.Ichor, 300);
        }
    }
}