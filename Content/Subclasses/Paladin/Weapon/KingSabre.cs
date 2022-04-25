using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Utilities;
using System;
using Trinitarian.Content.Subclasses.Paladin;
using Trinitarian.Content.Projectiles.Subclass.Paladin;
using Trinitarian.Common;

namespace Trinitarian.Content.Subclasses.Paladin.Weapon
{
    public class KingSabre : ModItem
    {
        public int currentAttack = 1;
        public override string Texture => "Trinitarian/Content/Subclasses/Paladin/Weapon/KingSabre";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("King's Sabre");
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
        public override void SetDefaults()
        {
            item.width = item.height = 32;
            item.damage = 92;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useAnimation = item.useTime = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shootSpeed = 1f;
            item.rare = ItemRarityID.Yellow;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<KingSabreSlash>();
        }

        public override bool UseItem(Player player)
        {
            for (int i = 0; i < Math.Min(10, player.GetModPlayer<HolyCombo>().combo / 2); ++i)
            {
                Projectile.NewProjectile(player.Center, new Vector2(Main.rand.NextFloat(4, 7) * player.direction, Main.rand.NextFloat(-8, -5)), ModContent.ProjectileType<LightningShard>(), item.damage, item.knockBack, player.whoAmI);
            }
            return true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if(player.ownedProjectileCounts[ModContent.ProjectileType<LightningSpike>()] == 0)
            {
                if (Main.player[Main.myPlayer] == player)
                {
                    Projectile.NewProjectile((int)(target.position.X), (int)(target.position.Y) - 1200, 0, 0, ModContent.ProjectileType<LightningSpike>(), (int)(item.damage), 3, Main.myPlayer);
                }
            }
        }

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            if (TrinitarianLists.unholyEnemies.Contains(target.type))
            {
                damage = (int)(damage * 1.8f);
            }
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
    }
}
