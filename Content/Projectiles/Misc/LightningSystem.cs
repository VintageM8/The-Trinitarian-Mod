using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian.Content.Projectiles.Misc
{
    public class LightningBolt : ModProjectile
    {
        public float widthdecrease = 0.1f;
        public Vector2 start;
        public Vector2 end;
        public Color color = Color.White;
        public float scale = 1;
        public double jagamount = 1.3;
        public int segmentamount = 20;
        public float widthreset = 10;
        public Vector2[] positions;
        public int ticks = 0;
        public virtual void CustomDrawPerPixel(Vector2 vec) { }
        public virtual void CustomDraw(Vector2[] positions) { }
        public override string Texture => "Trinitarian/Assets/Textures/Pixel";
        public void DrawLine(Vector2 start, Vector2 end, Color color,  float scale)
        {
            Vector2 unit = end - start;
            float length = unit.Length();
            unit.Normalize();
            for (int i = 0; i < length; i++)
            {
                Vector2 drawpos = start + unit * i - Main.screenPosition;
                Main.EntitySpriteDraw(Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value, drawpos, null, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
                CustomDrawPerPixel(drawpos);
            }
        }
        public void DrawLine(Vector2 start, Vector2 end, Color color, SpriteBatch spriteBatch, Vector2 scale)
        {
            Vector2 unit = end - start;
            float length = unit.Length();
            unit.Normalize();
            for (int i = 0; i < length; i++)
            {
                Vector2 drawpos = start + unit * i - Main.screenPosition;
                spriteBatch.Draw(Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value, drawpos, null, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0f);
                CustomDrawPerPixel(drawpos);
            }
        }
        public virtual Color GetColor(int progress) { return Color.White; }
        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(ticks);
        }
        public override void ReceiveExtraAI(BinaryReader reader)
        {
            ticks = reader.ReadInt32();
        }
        public virtual void SetDrawVariables()
        {
            start = Main.player[(int)Projectile.ai[0]].Center;
            end = Main.MouseWorld;
        }
        public virtual void CustomPositionSet() { }
        public override bool PreDraw(ref Color lightColor)
        {
            SetDrawVariables();
            color = GetColor(ticks);
            Vector2 unit = end - start;
            scale = widthreset;
            float length = unit.Length();
            while (length < 300f)
                length++;
            unit.Normalize();
            if (IsMovingCloser(Projectile.Center, unit, Main.player[(int)Projectile.ai[0]].Center))
                unit *= -1;
            if (ticks == 0)
            {
                widthreset = scale;
                positions = new Vector2[segmentamount];
                positions[0] = start;
                ticks++;
                for (int i = 1; i < positions.Length; i++)
                {
                    positions[i] = (positions[i - 1] + unit.RotatedByRandom(jagamount) * ((int)length / positions.Length));
                }
                positions[positions.Length - 1] = end;
                CustomPositionSet();
            }

            for (int i = 0; i < positions.Length - 1; i++)
            {
                scale -= 0.5f;
                if (scale < 0.01f)
                {
                    scale = 0.1f;
                    color = Color.Transparent;
                }
                DrawLine(positions[i], positions[i + 1], color,  scale);
                color = GetColor(ticks);
            }
            if (!Main.gamePaused)
            {
                if (ticks++ > 21)
                    ticks = 1;
                widthreset -= widthdecrease;
            }
            CustomDraw(positions);

            return false;
        }
        public int Clamp(int i, int min, int max)
        {
            if (i < 0)
                if (i < -max)
                    i = -max;
                else if (i > -min)
                    i = -min;
            if (i > 0)
                if (i > max)
                    i = max;
                else if (i < min)
                    i = min;
            return i;
        }
        public bool IsMovingCloser(Vector2 start, Vector2 unit, Vector2 comparison)
        {

            return Vector2.Distance(start, comparison) > Vector2.Distance(start + unit, comparison);
        }
    }
}