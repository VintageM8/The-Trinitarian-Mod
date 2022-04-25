using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged.SoulEater
{
    public class TheSoulEater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Soul Eater");
        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 16;
            Item.height = 36;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.crit = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5;
            Item.value = Item.sellPrice(0, 8, 50, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SoulEaterProj>();
            Item.shootSpeed = 12f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddTile(TileID.Anvils)
                .AddIngredient(ItemID.DemoniteBar, 22)
                .AddIngredient(ItemID.ShadowScale, 25)
                .Register();
        }
    }
}