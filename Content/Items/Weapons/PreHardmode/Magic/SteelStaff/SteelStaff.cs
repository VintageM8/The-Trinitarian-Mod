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
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 29;
            item.magic = true;
            item.mana = 12;
            item.width = 42;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<SteelStaffProj>();
            item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<SteelBar>(), 10);
            recipe.AddIngredient(ItemID.GoldBar, 2);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemType<SteelBar>(), 10);
            recipe2.AddIngredient(ItemID.Bone, 10);
            recipe2.AddIngredient(ItemID.PlatinumBar, 2);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}