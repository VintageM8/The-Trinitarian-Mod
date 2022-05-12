using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Projectiles.Subclass.Wizard;
using Trinitarian.Dusts;
using Terraria.Audio;

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
            Item.DamageType = DamageClass.Magic;
            Item.mana = 10;
            Item.width = 32;
            Item.height = 32;
            Item.damage = 12;
            Item.crit = 5;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.rare = ItemRarityID.Green;
            Item.channel = true;
        }

        public override void HoldItem(Player player)
        {
            if (player.channel)
            {
                if (charge % 30 == 0 && charge < 90)
                {
                    int index = charge / 30;
                    float rot = MathHelper.Pi / 3f * index - MathHelper.Pi / 3f;
                    int i = Projectile.NewProjectile(player.GetSource_ItemUse(Item), player.Center + Vector2.UnitY.RotatedBy(rot) * -45, Vector2.Zero, ProjectileType<FeuerBall>(), Item.damage, Item.knockBack, player.whoAmI, 0, charge);
                    Main.projectile[i].frame = index;

                    SoundEngine.PlaySound(SoundID.Item8, player.Center);
                }
                charge++;
            }

            else charge = 0;
        }
    }
}