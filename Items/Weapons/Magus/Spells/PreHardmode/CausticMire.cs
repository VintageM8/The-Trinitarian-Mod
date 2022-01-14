using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus.Runes;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Magus.Spells.PreHardmode
{
    public class CausticMire : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caustic Mire");
            Tooltip.SetDefault("Rune Spell\nSummons a rune above your head that shoots a black, gooey substance.");
        }
        public override void SafeSetDefaults()
        {
            item.UseSound = SoundID.Item1;
            item.crit = 4;
            item.damage = 15;
            item.knockBack = 8f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 35;
            item.useTime = 35;
            item.width = 40;
            item.height = 36;
            item.rare = ItemRarityID.Orange;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.maxStack = 1;
            item.autoReuse = false;
            item.value = Item.sellPrice(0, 0, 80, 0);
            item.shoot = ModContent.ProjectileType<MerchantRune>();
            item.shootSpeed = 8;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 50);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
