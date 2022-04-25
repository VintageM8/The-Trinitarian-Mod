using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Content.Items.Weapons.PreHardmode.Magic.SteelStaff;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Magic.SteelStaff
{
    public class SteelStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Staff");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 29;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 12;
            Item.width = 42;
            Item.height = 40;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 5;
            Item.value = Item.sellPrice(0, 0, 60, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SteelStaffProj>();
            Item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemType<SteelBar>(), 10)
                .AddIngredient(ItemID.GoldBar, 2)
                .AddIngredient(ItemID.Bone, 10)
                .AddTile(TileID.Anvils)
                .Register();
            CreateRecipe(1)
                .AddIngredient(ItemType<SteelBar>(), 10)
                .AddIngredient(ItemID.Bone, 10)
                .AddIngredient(ItemID.PlatinumBar, 2)
                .Register();
        }
    }
}