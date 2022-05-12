using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Trinitarian.Content.Items.Weapons.Hardmode.Ranged.VikingBow;
using Terraria.DataStructures;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged.VikingBow
{
    public class VikingBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ulvkil Bow");
        }

        public override void SetDefaults()
        {
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item5;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.damage = 250;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.width = 30;
            Item.height = 60;
            Item.shoot = AmmoID.Arrow;
            Item.shootSpeed = 8f;
            Item.knockBack = 10f;
            Item.DamageType = DamageClass.Ranged;
            Item.value = Item.sellPrice(gold: 48);
            Item.useAmmo = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position.X, position.Y, position.X, position.Y, ModContent.ProjectileType<BowAxe>(), damage, knockback, player.whoAmI);
			return true;
		}

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemType<UlvkilSoul>(), 4)
                .AddIngredient(ItemType<StormEnergy>(), 13)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}