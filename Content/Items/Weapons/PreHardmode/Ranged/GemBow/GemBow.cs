using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using Microsoft.Xna.Framework;
using Trinitarian.Content.Projectiles.Ammo;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged.GemBow
{
    public class GemBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem Bow");
            Tooltip.SetDefault("Shoots out 3 arrows at a time");
        }

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 16;
            Item.height = 36;
            Item.useTime = 4;
            Item.useAnimation = 12;
            Item.crit = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = false;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 7f;
            Item.reuseDelay = 14;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override bool CanConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < Item.useAnimation - 2);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ModContent.ProjectileType<GemArrowProj>();
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddTile(TileID.Anvils)
                .AddIngredient(ModContent.ItemType<SteelBar>(), 8)
                .AddIngredient(ItemID.Ruby, 4)
                .AddIngredient(ItemID.Sapphire, 4)
                .AddIngredient(ItemID.Topaz, 4)
                .AddIngredient(ItemID.Amethyst, 4)
                .Register();
        }
    }
}