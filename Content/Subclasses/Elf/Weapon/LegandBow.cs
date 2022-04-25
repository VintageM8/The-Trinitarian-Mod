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
            TrinitarianGlowmask.AddGlowMask(Item.type, "Trinitarian/Content/Subclasses/Elf/Weapon/LegandBow_Glow");
        }

        public override void SetDefaults()
        {
            Item.damage = 44;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 20;
            Item.height = 46;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = 5;
            Item.shoot = 3;
            Item.knockBack = 1f;
            Item.value = Item.sellPrice(0, 1, 80, 0);
            Item.rare = 1;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<HolyArrow>();
            Item.shootSpeed = 6.5f;
            Item.crit = 8;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture;
            texture = Main.itemTexture[Item.type];
            spriteBatch.Draw
            (
                ModContent.Request<Texture2D>("Trinitarian/Subclasses/Elf/Weapon/LegandBow_Glow"),
                new Vector2
                (
                    Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
                    Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
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
