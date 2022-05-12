using Terraria.ID;
using Terraria;
using Trinitarian.Content.Items.Materials.Parts;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged.FrostyMini
{
    public class FrostyMinigun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frosty Minigun");
            Tooltip.SetDefault("Shoots bullets out at high speed");
        }

        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 50;
            Item.height = 28;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 0;
            Item.value = 35;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 27f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddTile(TileID.Anvils)
                .AddIngredient(ModContent.ItemType<IceShards>(), 4)
                .AddIngredient(ItemID.Minishark, 1)
                .AddIngredient(ItemID.TissueSample, 8)
                .Register();
            CreateRecipe(1)
                .AddTile(TileID.Anvils)
                .AddIngredient(ItemID.Minishark, 1)
                .AddIngredient(ItemID.ShadowScale, 8)
                .AddIngredient(ModContent.ItemType<IceShards>(), 4)
                .Register();
        }
    }
}
