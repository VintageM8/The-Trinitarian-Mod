using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Utilities;
using System;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.VikingAxe
{
    public class ZolzarAxe : ModItem
    {
        public int currentAttack = 1;
        public override string Texture => "Trinitarian/Content/Items/Weapons/Hardmode/Melee/VikingAxe/ZolzarAxe";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zolzar's Infuser");
        }

        public override void SetDefaults()
        {
            Item.width = Item.height = 92;
            Item.damage = 16;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.useAnimation = Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 1f;
            Item.rare = ItemRarityID.Yellow;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<VikingAxeProj>();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int dir = currentAttack;
            currentAttack = -currentAttack;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0, dir);
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<UlvkilSoul>(), 4)
                .AddIngredient(ModContent.ItemType<StormEnergy>(), 12)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }
}
