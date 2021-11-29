using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Magus.Hardmode
{
    public class NightStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Night Scepter");
            Tooltip.SetDefault("Shoots an aura that increases in damage over time\n Any player in the aura will be gain life.");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.NPCHit1;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.damage = 3;
            item.useAnimation = 2;
            item.useTime = 2;
            item.shoot = ModContent.ProjectileType<FocusProjectile>();
            item.knockBack = 0f;
            item.channel = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ItemID.SoulofNight, 20);
            recipe.AddIngredient(ItemID.TitaniumBar, 18);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Anvils);
            recipe2.AddIngredient(ItemID.SoulofNight, 20);
            recipe2.AddIngredient(ItemID.AdamantiteBar, 18);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
