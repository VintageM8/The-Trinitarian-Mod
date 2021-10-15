
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;


namespace Trinitarian.Projectiles.Mage
{
    class DrawLaser : ModProjectile
    {
        //TODO make it only work on channeling. make it collide with terrain.
        const int Length = 30;
        Vector2[] Positions = new Vector2[Length];
        double MaxTurningAngle = 2 * Math.PI / 13f;

        public override void SetDefaults()
        {
            projectile.ignoreWater = false;
            projectile.width = 30;
            projectile.penetrate = -1;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.light = 1f;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;            
        }
        public override string Texture => "Trinitarian/Projectiles/Mage/ShaperBall";
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            bool temp = false;
            if (projHitbox.Intersects(targetHitbox))
            {
                return true;
            }
            for (float i = targetHitbox.BottomLeft().X; i < targetHitbox.BottomLeft().X + targetHitbox.Width; i += 2)
            {
                if (CollidingPoint(Positions, new Vector2(i, targetHitbox.BottomLeft().Y)) == true) temp = true;
            }
            for (float i = targetHitbox.BottomRight().Y; i > targetHitbox.BottomRight().Y - targetHitbox.Height; i -= 2)
            {
                if (CollidingPoint(Positions, new Vector2(targetHitbox.BottomRight().X, i)) == true) temp = true;
            }
            for (float i = targetHitbox.TopLeft().X; i < targetHitbox.TopLeft().X + targetHitbox.Width; i += 2)
            {
                if (CollidingPoint(Positions, new Vector2(i, targetHitbox.TopLeft().Y)) == true) temp = true;
            }
            for (float i = targetHitbox.BottomLeft().Y; i > targetHitbox.BottomLeft().Y - targetHitbox.Height; i -= 2)
            {
                if (CollidingPoint(Positions, new Vector2(targetHitbox.BottomRight().X, i)) == true) temp = true;
            }
            return temp;

            //return CollidingPoint(Positions, new Vector2(targetHitbox.Center.X, targetHitbox.Center.Y));
        }
        public override void AI()
        {
            float projspeed = 10 + Main.player[projectile.owner].velocity.Length();
            if (projectile.velocity.Length() == 0)
            {
                Vector2 ProjectilePosition = Main.MouseWorld - projectile.Center;
                if (projectile.position != Vector2.Zero)
                {

                    ProjectilePosition.Normalize();

                }
                ProjectilePosition *= projspeed;
                projectile.velocity = ProjectilePosition;
            }
            else
            {
                Vector2 target = Main.MouseWorld;
                double temp = Math.Atan2(target.Y - projectile.Center.Y, target.X - projectile.Center.X);
                double TurningAngle;

                if (projectile.position != Vector2.Zero)
                {
                    projectile.velocity.Normalize();
                }
                if ((projectile.Center - Main.MouseWorld).LengthSquared() < 50 * 50)
                {
                    projectile.velocity *= projspeed * (projectile.Center - Main.MouseWorld).LengthSquared() / (50 * 50);
                }
                else
                {
                    projectile.velocity *= projspeed;
                }

                TurningAngle = temp - projectile.velocity.ToRotation();
                if (TurningAngle > Math.PI)
                {
                    TurningAngle = TurningAngle - 2 * Math.PI;
                }
                else if (TurningAngle < -Math.PI)
                {
                    TurningAngle = TurningAngle + 2 * Math.PI;
                }
                if (TurningAngle > MaxTurningAngle)
                {
                    projectile.velocity = projectile.velocity.RotatedBy(MaxTurningAngle);
                }
                else if (TurningAngle < -MaxTurningAngle)
                {
                    projectile.velocity = projectile.velocity.RotatedBy(-MaxTurningAngle);
                }
                else
                {
                    projectile.velocity = projectile.velocity.RotatedBy(TurningAngle);
                }

            }



            for (int i = Length - 1; i > 0; i--)
            {
                Positions[i] = Positions[i - 1];
            }
            Positions[0] = projectile.Center;

        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Color c = new Color(155, 0, 0);
            Texture2D texture = ModContent.GetTexture("Trinitarian/Projectiles/Mage/Test");
            Texture2D texture2 = ModContent.GetTexture("Trinitarian/Projectiles/Mage/ShaperBeam");
            for (int i = 1; i < Length; i++)
            {
                if (Positions[i] != Vector2.Zero) {
                    //spriteBatch.Draw(texture, Positions[i] - Main.screenPosition, c);
                    DrawLaserLinear(spriteBatch, Positions[i], Positions[i - 1], texture2);
                }            
            }
            //Rectangle targetHitbox = Rectangle.Empty;
            //for (int i = 0; i < Main.npc.Length; i++)
            //{
            //    if (Main.npc[i].type == NPCID.TargetDummy)
            //    {
            //        targetHitbox = Main.npc[i].Hitbox;
            //    }
            //}
            //for (float i = targetHitbox.BottomLeft().X; i < targetHitbox.BottomLeft().X + targetHitbox.Width; i += 5)
            //{
            //    spriteBatch.Draw(texture, new Vector2(i, targetHitbox.BottomLeft().Y) - Main.screenPosition, c);
            //}
            //for (float i = targetHitbox.BottomRight().Y; i > targetHitbox.BottomRight().Y - targetHitbox.Height; i -= 5)
            //{
            //    spriteBatch.Draw(texture, new Vector2(targetHitbox.BottomRight().X, i) - Main.screenPosition, c);               
            //}
            //for (float i = targetHitbox.TopLeft().X; i < targetHitbox.TopLeft().X + targetHitbox.Width; i += 5)
            //{
            //    spriteBatch.Draw(texture, new Vector2(i, targetHitbox.TopLeft().Y) - Main.screenPosition, c);
            //}
            //for (float i = targetHitbox.BottomLeft().Y; i > targetHitbox.BottomLeft().Y - targetHitbox.Height; i -= 5)
            //{
            //    spriteBatch.Draw(texture, new Vector2(targetHitbox.BottomLeft().X, i) - Main.screenPosition, c);
            //}
            return true;
        }

        private void DrawLaserLinear(SpriteBatch spriteBatch, Vector2 Pos1, Vector2 Pos2, Texture2D texture)
        {
            float distSQ = (Pos1 - Pos2).LengthSquared();
            for (int i = 0; i * i <= distSQ; i += 2)
            {
                float r = (float)Math.PI / 2f + (float)Math.Atan2(Pos1.Y - Pos2.Y, Pos1.X - Pos2.X);
                Color d = Color.White;
                Vector2 temp = Pos2 - Pos1;
                if (temp != Vector2.Zero)
                {
                    temp.Normalize();
                }
                Vector2 origin = Pos1 + i*temp;
                spriteBatch.Draw(texture, origin - Main.screenPosition,
                    new Rectangle(0, 26, 30, 6), d, r,
                    new Vector2(26 * .5f, 6 * .5f), 1f, 0, 0);
            }
        }
        public bool CollidingPoint(Vector2[] Positions, Vector2 Point)
        {
            for (int i = 0; i < Positions.Length - 1; i++)
            {
                if (Positions[i] - Positions[i + 1] != Vector2.Zero && Positions[i] != Vector2.Zero && Positions[i + 1] != Vector2.Zero) 
                {
                    Vector2 v = Positions[i + 1] - Positions[i];
                    float lambda = Vector2.Dot((Point - Positions[i]), v) / v.LengthSquared();
                    if (lambda <= 1 && lambda >= 0)
                    {
                        Vector2 temp = Positions[i] + lambda * v - Point;
                        if (temp.Length() < 15) return true;
                    }
                }
            }
            return false;

        }
    }
}
