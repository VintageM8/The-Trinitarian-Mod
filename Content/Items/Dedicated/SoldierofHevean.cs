using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Utilities;
using System.Collections.Generic;
using System.Linq;
using Terraria.Graphics.Shaders;
using System;
using Trinitarian.Common;

namespace Trinitarian.Content.Items.Dedicated
{
    public class SoldierofHevean : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mannlicher M1895");
            Tooltip.SetDefault("[c/eeff00f:Dedicated Item:] Dedicated to the [c/00e1ff:Soldier of Hevean]\nMay you have found your way to Valhalla.");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.ranged = true;
            item.width = 50;
            item.height = 28;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Cyan;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = ProjectileID.PurificationPowder;
            item.shootSpeed = 18f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Vector2 pos = item.Center - Main.screenPosition;
            Texture2D texture = Main.itemTexture[item.type];
            Texture2D spot = ModContent.GetTexture("Trinitarian/Assets/Textures/Spotlight");
            float alpha = 0.8f;
            float s = 0.5f * scale;
            for (int i = 0; i < 6; i++)
            {
                spriteBatch.Draw(
                    spot,
                    pos,
                    null,
                    Color.Lerp(Color.White, Color.LightYellow, (float)i / 3) * alpha,
                    0f,
                    new Vector2(spot.Width, spot.Height) / 2,
                    s * (1f + ((float)Math.Sin((Main.GlobalTime * 2) + (MathHelper.PiOver4 * i)) * 0.15f)),
                    SpriteEffects.None,
                    0f);
                s *= 2;
                alpha *= 0.9f;
            }
            spriteBatch.Draw(texture, pos, null, Color.White, -MathHelper.PiOver4, new Vector2(texture.Width, texture.Height) / 2, scale, SpriteEffects.None, 0f);
            return false;
        }
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Vector2 pos = Utilty.GetInventoryPosition(position, frame, origin, scale);
            Texture2D texture = Main.itemTexture[item.type];
            Texture2D flash = ModContent.GetTexture("Trinitarian/Assets/Textures/Flash2");
            UnifiedRandom rand = new UnifiedRandom(item.whoAmI);
            for (int i = 0; i < 5; i++)
            {
                float alpha = 0.3f + (0.15f * i);
                float r = rand.NextFloat();
                float s = 0.6f - (0.06f * i);
                spriteBatch.Draw(
                    flash,
                    pos,
                    null,
                    Color.LightYellow * alpha,
                    Main.GlobalTime * r,
                    new Vector2(flash.Width / 2, flash.Height),
                    new Vector2(0.2f, s),
                    SpriteEffects.None,
                    0f);
            }
            spriteBatch.Draw(texture, pos, null, Color.White, 0f, texture.Size() / 2, scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}
