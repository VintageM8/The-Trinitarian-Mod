using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus;

namespace Trinitarian.Items.Weapons.Magus.PreHardmode
{
    public class TomeofDarkRune : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome of the Dark Rune");
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.damage = 39;
            item.width = 112;
            item.height = 40;
            item.useTime = 16;
            item.useAnimation = 16;
            item.crit = 4;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 3f;
            item.value = Item.sellPrice(0, 1, 60, 0);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<DarkRune>();
            item.shootSpeed = 20f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Book, 12);
            recipe.AddIngredient(ItemID.Bone, 18);
            recipe.AddIngredient(ModContent.ItemType<RuneofRerrk>(), 1);
            recipe.AddIngredient(ModContent.ItemType<CrownofMadness>(), 1);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}