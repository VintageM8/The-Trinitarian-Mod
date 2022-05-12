using Terraria;
using Terraria.ID;
using Trinitarian.Content.Items.Materials.Parts;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Weapons.PreHardmode.Melee.IceSpear;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Melee.IceSpear
{
    public class IceSpear : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 28;
            Item.useTime = 32;
            Item.shootSpeed = 5f;
            Item.knockBack = 10f;
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<IceSpearproj>();
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddTile(TileID.Anvils)
                .AddIngredient(ModContent.ItemType<IceShards>(), 12)
                .AddIngredient(ItemID.TissueSample, 15)
                .Register();
            CreateRecipe(1)
                .AddTile(TileID.Anvils)
                .AddIngredient(ItemID.ShadowScale, 15)
                .AddIngredient(ModContent.ItemType<IceShards>(), 12)
                .Register();
        }
    }
}