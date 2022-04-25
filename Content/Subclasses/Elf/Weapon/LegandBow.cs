using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Content.Projectiles.Subclass.Elf;
using Terraria;
using Trinitarian.Assets;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Subclasses.Elf.Weapon
{
    public class LegandBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Legend's Bow");
            Tooltip.SetDefault("Created from a material gifted from the Paladins,\n" +
                "this bow is only a start to a holy journey\nStuns the unholy, inflicts Holy Smite on all mobs.");
            TrinitarianGlowmask.AddGlowMask(item.type, "Trinitarian/Content/Subclasses/Elf/Weapon/LegandBow_Glow");
        }

        public override void SetDefaults()
        {
            item.damage = 44;
            item.noMelee = true;
            item.ranged = true;
            item.width = 20;
            item.height = 46;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.shoot = 3;
            item.knockBack = 1f;
            item.value = Item.sellPrice(0, 1, 80, 0);
            item.rare = 1;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<HolyArrow>();
            item.shootSpeed = 6.5f;
            item.crit = 8;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture;
            texture = Main.itemTexture[item.type];
            spriteBatch.Draw
            (
                ModContent.GetTexture("Trinitarian/Subclasses/Elf/Weapon/LegandBow_Glow"),
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }
    }
}
