using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Projectiles.Subclass.Wizard;

namespace Trinitarian.Content.Subclasses.Wizard.Weapon
{
    public class Waterstorm : ModItem
    {
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) =>
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10)) * (1f - Main.rand.NextFloat(0.5f));

        public override bool AltFunctionUse(Player player) => true;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Waterstorm");

            Tooltip.SetDefault("Summons up to 30 explosive, homing water bubbles"
                + "\nRight click to detonate instantly");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Magic;
            Item.damage = 58;
            Item.knockBack = 5f;
            Item.noMelee = true;

            Item.shoot = ProjectileType<WaterstormBubble>();
            Item.shootSpeed = 12f;
            Item.mana = 14;
            Item.width = Item.height = 16;
            Item.scale = 1f;

            Item.useTime = Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.DD2_LightningAuraZap;
            Item.autoReuse = true;
            Item.useTurn = false;

            Item.value = Item.sellPrice(0, 2, 50, 0);
            Item.rare = ItemRarityID.Green;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    if (Main.projectile[i].type == Item.shoot && player.ownedProjectileCounts[Item.shoot] > 0)
                    {
                        Main.projectile[i].Kill();
                    }
                }

                Item.shoot = ProjectileID.None;
                Item.useTime = Item.useAnimation = 40;
                Item.UseSound = SoundID.DD2_KoboldIgnite;
            }
            else
            {
                Item.shoot = ProjectileType<WaterstormBubble>();
                Item.useTime = Item.useAnimation = 10;
                Item.UseSound = SoundID.DD2_LightningAuraZap;
            }

            return player.ownedProjectileCounts[Item.shoot] < 10;
        }
    }
}
