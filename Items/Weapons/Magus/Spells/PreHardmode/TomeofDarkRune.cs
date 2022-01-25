using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus.Runes;

namespace Trinitarian.Items.Weapons.Magus.Spells.PreHardmode
{
    public class TomeofDarkRune : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tome of the Dark Rune");
            Tooltip.SetDefault("Rune Spell\nSummons a rune above your head that casts a burst dark energy.");
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
            item.UseSound = SoundID.Item117;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<DarkRune>();
            item.shootSpeed = 20f;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Book, 12);
            recipe.AddIngredient(ItemID.Bone, 18);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}