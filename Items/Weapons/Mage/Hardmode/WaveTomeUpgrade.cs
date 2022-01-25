using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Projectiles.Mage;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Mage.Hardmode
{
    public class WaveTomeUpgrade : ModItem
    {
        bool Cooldown = false;
        int timer = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True tome of the Sea");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 61;
            item.magic = true;
            item.mana = 18;
            item.width = 42;
            item.height = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 50, 60, 70);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<TidalWave>();
            item.shootSpeed = 10f;
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
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int[] proj = new int[8];
            Vector2 Speed = new Vector2(speedX, speedY);
            Speed.Normalize();

            if (player.altFunctionUse == 2)
            {
                for (int i = 0; i < 8; i++)
                {
                    proj[i] = Projectile.NewProjectile(player.Center, new Vector2(14 * (float)Math.Cos(2 * Math.PI * i / 8), 14 * (float)Math.Sin(2 * Math.PI * i / 8)), ModContent.ProjectileType<TidalWave>(), damage, knockBack, player.whoAmI);
                    Main.projectile[proj[i]].timeLeft = 16;
                    Cooldown = true;
                    //TODO Add a debuff for the cooldown.
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    proj[i] = Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY), ModContent.ProjectileType<TidalWave>(), damage, knockBack, player.whoAmI, 0, 0.3f * (i - 1));
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
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<OceanBar>(), 4);
            recipe.AddIngredient(ItemID.ShroomiteBar, 2);
            recipe.AddIngredient(ModContent.ItemType<TrueStarSteel>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}