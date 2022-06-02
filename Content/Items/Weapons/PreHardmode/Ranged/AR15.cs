using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;
using Trinitarian.Content.Projectiles.Ammo;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged
{
    public class AR15 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AR 15");
            Tooltip.SetDefault("11% Chance to not consume ammo\nChanges Bullets to Rusted Bullets");
        }

        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 50;
            Item.height = 28;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 0, 70, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return base.CanConsumeAmmo(ammo, player);
            return Main.rand.NextFloat() >= .11f;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.Bullet)
            {
                type = ModContent.ProjectileType<RustedBulletproj>();
            }
        //    return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddTile(TileID.Anvils)
                .AddIngredient(ModContent.ItemType<RustyScraps>(), 22)
                .AddIngredient(ModContent.ItemType<GunParts>(), 1)
                .Register();
        }
    }
}
