using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Trinitarian.Content.Items.Weapons.Hardmode.Magic.NightStaff;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Magic.NightStaff
{
    public class NightStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Night Scepter");
            Tooltip.SetDefault("Summons an aura that deals more damage as it gets smaller.");
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.NPCHit1;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 60;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.damage = 3;
            Item.useAnimation = 2;
            Item.useTime = 2;
            Item.shoot = ModContent.ProjectileType<FocusProjectile>();
            Item.knockBack = 0f;
            Item.channel = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<FocusProjectile>()] < 1)
            {
                position = Main.MouseWorld;
                return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
            }
            else
            {
                return false;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddTile(TileID.Anvils)
                .AddIngredient(ItemID.SoulofNight, 20)
                .AddIngredient(ItemID.TitaniumBar, 18)
                .Register();
            CreateRecipe(1)
                .AddTile(TileID.Anvils)
                .AddIngredient(ItemID.SoulofNight, 20)
                .AddIngredient(ItemID.AdamantiteBar, 18)
                .Register();
        }
    }
}
