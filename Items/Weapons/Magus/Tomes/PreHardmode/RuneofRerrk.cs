using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus.Tome;
using Trinitarian.Items.Materials.Bars;

namespace Trinitarian.Items.Weapons.Magus.Tomes.PreHardmode
{
    public class RuneofRerrk : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune of Rerrk");
            Tooltip.SetDefault("Creats a powerfull attack that deals the devistaing debuff, Nosferatu.\nCreated from the magus sorcerers of ancient this rune hold infinite power and knowladge.");
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.damage = 17;
            item.width = 112;
            item.height = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.crit = 8;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6f;
            item.value = Item.sellPrice(0, 1, 60, 0);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<RerrkBurst>();
            item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Book, 5);
            recipe.AddIngredient(ItemID.CrimtaneBar, 8);
            recipe.AddIngredient(ModContent.ItemType<SteelBar>(), 12);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.Book, 5);
            recipe2.AddIngredient(ItemID.DemoniteBar, 8);
            recipe2.AddIngredient(ModContent.ItemType<SteelBar>(), 12);
            recipe2.AddTile(TileID.Bookcases);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
