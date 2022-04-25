using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged
{
    public class RustedBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rusted Bow");
        }

        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 16;
            Item.height = 36;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.crit = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 0, 25, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = false;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 7f;
            Item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddTile(TileID.Anvils)
                .AddIngredient(ModContent.ItemType<RustyMetal>(), 5)
                .Register();
        }
    }
}