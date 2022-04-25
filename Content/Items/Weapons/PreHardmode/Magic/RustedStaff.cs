using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Magic
{
    public class RustedStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rusted Staff");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 5;
            Item.width = 34;
            Item.height = 34;
            Item.useTime = 29;
            Item.useAnimation = 29;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 0, 6, 9);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = false;
            Item.shoot = ProjectileID.TopazBolt;
            Item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddTile(TileID.Anvils)
                .AddIngredient(ModContent.ItemType<RustyMetal>(), 7)
                .Register();
        }
    }
}