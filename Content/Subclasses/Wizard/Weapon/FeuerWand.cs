using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Projectiles.Subclass.Wizard;
using Trinitarian.Dusts;

namespace Trinitarian.Content.Subclasses.Wizard.Weapon
{
    class FeuerWand : ModItem
    {
        int charge = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Archaic Feuer Wand");
            Tooltip.SetDefault("Hold to summon up to 3 Feuer Balls\nReleasing will fire the Feuer towards your cursor\nIf you continue to hold, the Feuer will expolde, dealing damage to you.");
        }

        public override void SetDefaults()
        {
            item.magic = true;
            item.mana = 10;
            item.width = 32;
            item.height = 32;
            item.damage = 12;
            item.crit = 5;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 30;
            item.useAnimation = 30;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = ItemRarityID.Green;
            item.channel = true;
        }

        public override void HoldItem(Player player)
        {
            if (player.channel)
            {
                if (charge % 30 == 0 && charge < 90)
                {
                    int index = charge / 30;
                    float rot = MathHelper.Pi / 3f * index - MathHelper.Pi / 3f;
                    int i = Projectile.NewProjectile(player.Center + Vector2.UnitY.RotatedBy(rot) * -45, Vector2.Zero, ProjectileType<FeuerBall>(), item.damage, item.knockBack, player.whoAmI, 0, charge);
                    Main.projectile[i].frame = index;

                    Main.PlaySound(SoundID.Item8, player.Center);
                }
                charge++;
            }

            else charge = 0;
        }
    }
}