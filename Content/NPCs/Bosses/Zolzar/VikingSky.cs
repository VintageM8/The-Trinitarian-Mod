using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace Trinitarian.Content.NPCs.Bosses.Zolzar
{
	public class VikingSky : CustomSky
	{
		private bool isActive;

        private float intensity;

		private int VikingIndex;

		public override void Update(GameTime gameTime)
        {
            if (isActive && intensity < 1f)
            {
                intensity += 0.01f;
            }
            else if (!isActive && intensity > 0f)
            {
                intensity -= 0.01f;
            }
        }

		private bool UpdateVikingIndex()
		{
			int VikingType = ModLoader.GetMod("Trinitarian").Find<ModNPC>("VikingBoss").Type;
			if (VikingIndex >= 0 && Main.npc[VikingIndex].active && Main.npc[VikingIndex].type == VikingType)
			{
				return true;
			}
			VikingIndex = -1;
			for (int i = 0; i < Main.npc.Length; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == VikingType)
				{
					VikingIndex = i;
					break;
				}
			}
			return VikingIndex >= 0;
		}

		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (maxDepth >= float.MaxValue && minDepth < float.MaxValue)
			{
				spriteBatch.Draw(ModContent.Request<Texture2D>("Trinitarian/Assets/Background/VikingBackground"), new Rectangle(0, Math.Max(0, (int)((Main.worldSurface * 16.0 - (double)Main.screenPosition.Y - 2400.0) * 0.10000000149011612)), Main.screenWidth, Main.screenHeight), Color.White * Math.Min(1f, (Main.screenPosition.Y - 800f) / 1000f) * intensity);
			}
		}

		public override float GetCloudAlpha()
		{
			return 0f;
		}

		public override void Activate(Vector2 position, params object[] args)
		{
			isActive = true;
		}

		public override void Deactivate(params object[] args)
		{
			isActive = false;
		}

		public override void Reset()
		{
			isActive = false;
		}

		public override bool IsActive()
		{
			if (!isActive)
			{
				return intensity > 0f;
			}
			return true;
		}
	}
}