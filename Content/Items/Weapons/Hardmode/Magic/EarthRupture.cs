using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Weapon.Mage;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Magic
{
    public class EarthRupture : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earth's Rupture");
            Tooltip.SetDefault("Shoots a boulder");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 48;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 18;
            Item.width = 42;
            Item.height = 40;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Boulder>();
            Item.shootSpeed = 12f;
        }
        public override Vector2? HoldoutOrigin()
        {
            return new Vector2(15, 0);
        }
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.DirtBlock, 200)
                .AddIngredient(ItemID.StoneBlock, 130)
                .AddIngredient(ItemID.SoulofNight, 15)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}