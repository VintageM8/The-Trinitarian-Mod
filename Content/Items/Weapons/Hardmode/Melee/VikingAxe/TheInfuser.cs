using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee.VikingAxe;
using static Terraria.ModLoader.ModContent;
using Terraria.Audio;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.VikingAxe
{
    public class TheInfuser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Infuser");
        }
        public override void SetDefaults()
        {
            //projectile.CloneDefaults(ProjectileID.PaladinsHammerFriendly);
            Projectile.width = 36;
            Projectile.height = 36;
            //projectile.aiStyle = 3;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
            Projectile.ignoreWater = true;
        }

        int Suffocationtime = 0;
        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 0f, 1f, 0f);
            if (Projectile.soundDelay == 0)
            {
                Projectile.soundDelay = 8;
                SoundEngine.PlaySound(SoundID.Item7, Projectile.position);
            }

            if (Projectile.ai[0] == 0f)
            {
                if (Projectile.ai[1] <= 5)
                {
                    Projectile.width = 4;
                    Projectile.height = 4;
                }
                else
                {
                    Projectile.width = 36;
                    Projectile.height = 36;
                }
                Projectile.ai[1] += 1f;
                if (Projectile.ai[1] >= 30f) // Return back code
                {
                    Projectile.ai[0] = 1f;
                    Projectile.ai[1] = 0f;
                    Projectile.netUpdate = true;
                }
            }
            else
            {
                // Projectile is returning
                Projectile.tileCollide = false;
                float num149 = 16f;
                float num150 = 1.2f;
                num149 = 15f;
                num150 = 3f;


                Vector2 vector163 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
                float num152 = Main.player[Projectile.owner].position.X + (float)(Main.player[Projectile.owner].width / 2) - vector163.X;
                float num154 = Main.player[Projectile.owner].position.Y + (float)(Main.player[Projectile.owner].height / 2) - vector163.Y;
                float num155 = (float)Math.Sqrt(num152 * num152 + num154 * num154);

                // Maximum distance
                if (num155 > 3000f)
                {
                    Projectile.Kill();
                }
                num155 = num149 / num155;
                num152 *= num155;
                num154 *= num155;
                if (Projectile.velocity.X < num152)
                {
                    Projectile.velocity.X = Projectile.velocity.X + num150;
                    if (Projectile.velocity.X < 0f && num152 > 0f)
                    {
                        Projectile.velocity.X = Projectile.velocity.X + num150;
                    }
                }
                else if (Projectile.velocity.X > num152)
                {
                    Projectile.velocity.X = Projectile.velocity.X - num150;
                    if (Projectile.velocity.X > 0f && num152 < 0f)
                    {
                        Projectile.velocity.X = Projectile.velocity.X - num150;
                    }
                }
                if (Projectile.velocity.Y < num154)
                {
                    Projectile.velocity.Y = Projectile.velocity.Y + num150;
                    if (Projectile.velocity.Y < 0f && num154 > 0f)
                    {
                        Projectile.velocity.Y = Projectile.velocity.Y + num150;
                    }
                }
                else if (Projectile.velocity.Y > num154)
                {
                    Projectile.velocity.Y = Projectile.velocity.Y - num150;
                    if (Projectile.velocity.Y > 0f && num154 < 0f)
                    {
                        Projectile.velocity.Y = Projectile.velocity.Y - num150;
                    }
                }

                if (Main.myPlayer == Projectile.owner)
                {
                    Rectangle rectangle = new Rectangle((int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height);
                    Rectangle value99 = new Rectangle((int)Main.player[Projectile.owner].position.X, (int)Main.player[Projectile.owner].position.Y, Main.player[Projectile.owner].width, Main.player[Projectile.owner].height);
                    if (rectangle.Intersects(value99))
                    {
                        Projectile.Kill();
                    }
                }
            }

            Projectile.rotation += 0.35f;

            if (Main.rand.NextBool(6))
            {
                Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Blood);
                Suffocationtime++;

                if (Suffocationtime == 5)
                {
                    Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, 0, -3, ProjectileType<FragmentalShurikenProj>(), 45, Projectile.knockBack, Main.myPlayer);
                    Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, 0, 3, ProjectileType<FragmentalShurikenProj>(), 45, Projectile.knockBack, Main.myPlayer);
                    Suffocationtime = 0;
                }
            }
        }
    

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            Projectile.ai[0] = 1f;
            Projectile.velocity.X = 0f - Projectile.velocity.X;
            Projectile.velocity.Y = 0f - Projectile.velocity.Y;
            Projectile.netUpdate = true;
            SoundEngine.PlaySound(SoundID.Dig, (int)Projectile.position.X, (int)Projectile.position.Y);
            return false;
        }
    }
}