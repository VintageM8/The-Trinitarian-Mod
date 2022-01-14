using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Buffs.Rune;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Projectiles.Magus.Spells
{
    public class CrimsonBurst : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy Burst");
            Main.projFrames[projectile.type] = 9;
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 100;
            projectile.extraUpdates = 1;

            drawOffsetX = -15;
            drawOriginOffsetY = -2;
        }

        public override void AI()
        {
            if (base.projectile.alpha > 0)
            {
                base.projectile.alpha -= 25;
                if (base.projectile.alpha < 0)
                {
                    base.projectile.alpha = 0;
                }
            }
            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 200f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
            }

            base.projectile.localAI[0] += 1f;
            if (base.projectile.localAI[0] > 4f)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, DustID.Blood, 0f, 0f, 100);
                Main.dust[num].noGravity = true;
                int num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, DustID.Fire, 0f, 0f, 100);
                Main.dust[num2].noGravity = true;
                int num3 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 174, 0f, 0f, 100);
                Main.dust[num3].noGravity = true;
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.ai[0] > -1)
            {
                return Color.Red;
            }
            else
            {
                return null;
            }
        }

        public override void Kill(int timeLeft)
        {

            for (int i = 0; i < Main.maxPlayers; i++)
            {
                float distance = Vector2.Distance(projectile.Center, Main.player[i].Center);
                if (distance <= 1050 && projectile.ai[0] > -1)
                {
                    Main.player[i].GetModPlayer<TrinitarianPlayer>().ScreenShake = 15;
                }
            }

            Vector2 origin = projectile.Center;
            float radius = 15;
            int numLocations = projectile.ai[0] > -1 ? 30 : 6;

            for (int i = 0; i < 6; i++)
            {
                Vector2 position = origin + Vector2.UnitX.RotatedByRandom(MathHelper.ToRadians(360f / numLocations * i)) * radius;
                Vector2 dustvelocity = new Vector2(0f, (projectile.ai[0] > -1 ? 5f : 3f)).RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * (projectile.ai[0] > 1 ? Main.rand.Next(1, 4) : 1);
            }
            Main.PlaySound(SoundID.Item14);

            if (projectile.penetrate == 1)
            {
                // Makes the projectile hit all enemies as it circunvents the penetrate limit.
                projectile.maxPenetrate = -1;
                projectile.penetrate = -1;

                int explosionArea = 60;
                Vector2 oldSize = projectile.Size;
                // Resize the projectile hitbox to be bigger.
                projectile.position = projectile.Center;
                projectile.Size += new Vector2(explosionArea);
                projectile.Center = projectile.position;

                projectile.tileCollide = false;
                projectile.velocity *= 0.01f;
                // Damage enemies inside the hitbox area
                projectile.Damage();
                projectile.scale = 0.01f;

                //Resize the hitbox to its original size
                projectile.position = projectile.Center;
                projectile.Size = new Vector2(10);
                projectile.Center = projectile.position;
            }
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 15f)
            {
                vector *= 15f / magnitude;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.player[projectile.owner].AddBuff(ModContent.BuffType<BlazeRune>(), 300); //Filler till 0.3.2
        }

        public Color TrailColor(float progress)
        {
            return Color.Lerp(Color.Green, Color.Black, progress) * (1f - progress);
        }

        public float TrailSize(float progress)
        {
            return 16f * (1f - progress);
        }
    }
}