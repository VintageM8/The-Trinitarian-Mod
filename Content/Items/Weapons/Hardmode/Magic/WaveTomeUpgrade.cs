using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Content.Projectiles.Weapon.Mage;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Magic
{
    public class WaveTomeUpgrade : ModItem
    {
        bool Cooldown = false;
        int timer = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True tome of the Sea");
            Tooltip.SetDefault("Right click to unleash waves all around you\n Has a cooldown");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 73;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 18;
            Item.width = 42;
            Item.height = 40;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 8;
            Item.value = Item.sellPrice(0, 50, 60, 70);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<TidalWave>();
            Item.shootSpeed = 18f;
        }
        public override bool AltFunctionUse(Player player)
        {
            return !Cooldown;
        }
        public override void UpdateInventory(Player player)
        {
            if (Cooldown) timer++;
            if (timer == 600)
            {
                timer = 0;
                Cooldown = false;
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float speedX = position.X;
            float speedY = position.Y;
            int[] proj = new int[8];
            Vector2 Speed = new Vector2(speedX, speedY);
            Speed.Normalize();

            if (player.altFunctionUse == 2)
            {
                for (int i = 0; i < 8; i++)
                {
                    proj[i] = Projectile.NewProjectile(source, player.Center, new Vector2(14 * (float)Math.Cos(2 * Math.PI * i / 8), 14 * (float)Math.Sin(2 * Math.PI * i / 8)), ModContent.ProjectileType<TidalWave>(), damage, knockback, player.whoAmI);
                    Main.projectile[proj[i]].timeLeft = 16;
                    Cooldown = true;
                    //TODO Add a debuff for the cooldown.
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    proj[i] = Projectile.NewProjectile(source, player.Center, new Vector2(speedX, speedY), ModContent.ProjectileType<TidalWave>(), damage, knockback, player.whoAmI, 0, 0.3f * (i - 1));
                    Main.projectile[proj[i]].timeLeft = 75;
                    Main.projectile[proj[i]].width = (int)(Main.projectile[proj[i]].width * (1 + 0.3f * (i - 1)));
                    Main.projectile[proj[i]].height = (int)(Main.projectile[proj[i]].height * (1 + 0.3f * (i - 1)));
                    Main.projectile[proj[i]].Center = player.Center + i * Speed * 30 * (1 + 0.07f * (i - 1));
                }
            }
            return false;
        }
        public override void HoldItem(Player player)
        {
            base.HoldItem(player);
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemType<OceanBar>(), 4)
                .AddIngredient(ItemID.ShroomiteBar, 2)
                .AddIngredient(ModContent.ItemType<TrueStarSteel>(), 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}