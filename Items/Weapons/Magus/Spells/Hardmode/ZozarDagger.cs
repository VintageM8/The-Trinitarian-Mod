using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using Trinitarian.Projectiles.Magus;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Trinitarian.Items.Weapons.Magus.Spells.Hardmode
{
    public class ZozarDagger : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zozar's Dagger");
            Tooltip.SetDefault("Mythic Spell\nSummons daggers all over the screen\nOnly 50 can be used at a time.");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 28;
            item.width = 10;
            item.mana = 8;
            item.height = 24;
            item.useTime = 8;
            item.useAnimation = 8;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 1, 80, 0);
            item.rare = ItemRarityID.LightRed;
            item.maxStack = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<ThrowingKnife>();
            item.shootSpeed = 12f;
            item.noUseGraphic = true;
        }

        float dynamicCounter = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 3 + (Main.expertMode ? 1 : 0); i++)
            {
                Vector2 toLocation = player.Center + new Vector2(Main.rand.NextFloat(100, 240), 0).RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(360)));
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    damage = item.damage;
                    Projectile.NewProjectile(toLocation, Vector2.Zero, ModContent.ProjectileType<ThrowingKnife>(), damage, 0, Main.myPlayer, player.whoAmI);
                }
                Vector2 toLocationVelo = toLocation - player.Center;
                Vector2 from = player.Center;
                for (int j = 0; j < 300; j++)
                {
                    Vector2 velo = toLocationVelo.SafeNormalize(Vector2.Zero);
                    from += velo * 12;
                    Vector2 circularLocation = new Vector2(10, 0).RotatedBy(MathHelper.ToRadians(j * 12 + dynamicCounter));

                    int dust = Dust.NewDust(from + new Vector2(-4, -4) + circularLocation, 0, 0, DustID.TeleportationPotion, 0, 0, 0, default, 1.25f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0.1f;
                    Main.dust[dust].scale = 1.8f;

                    if ((from - toLocation).Length() < 24)
                    {
                        break;
                    }
                }
            }
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 50;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.TitaniumBar, 14);
            recipe.AddIngredient(ModContent.ItemType<VikingMetal>(), 8);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Anvils);
            recipe2.AddIngredient(ItemID.SoulofNight, 15);
            recipe2.AddIngredient(ItemID.AdamantiteBar, 14);
            recipe2.AddIngredient(ModContent.ItemType<VikingMetal>(), 8);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}