using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee.BlueBlade;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.BlueBlade
{
    public class BlueBlade : ModItem
    {
        public bool NPCHit;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Star Blade");
            Tooltip.SetDefault("Fury of the sun rains down on your foes\nAfter 8 consecutive strikes, a homing sun will apper to burn your enemies.")
        }

        public override void SetDefaults()
        {
            Item.damage = 145;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 55, 0, 0);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.FlamingArrow;
            Item.shootSpeed = 60f;
        }

        public override bool? UseItem(Player player)
        {
            player.direction = (Main.MouseWorld.X - player.Center.X > 0) ? 1 : -1;
            return true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<SunWrath>();            
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = -4; i < 4; i++)
            {
                position = Main.MouseWorld + new Vector2(i * 20, -850);
                Vector2 vel = (Main.MouseWorld - position).SafeNormalize(Vector2.Zero).RotatedByRandom(0.05f) * Item.shootSpeed;
                Projectile.NewProjectile(source, position, vel, type, damage, knockback, player.whoAmI);
            }
            return false;
        }

         int charger;
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
             charger++;
            if (charger >= 8)
            {
                SoundEngine.PlaySound(SoundID.Item, (int)target.position.X, (int)target.position.Y, 14);
                Terraria.Projectile.NewProjectile(Item.GetSource_OnHit(target), target.Center.X, target.Center.Y, 0f, 0f, ModContent.ProjectileType<BlueBladeProj>(), damage, knockBack, player.whoAmI);
                charger = 0;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.FragmentSolar, 25)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}