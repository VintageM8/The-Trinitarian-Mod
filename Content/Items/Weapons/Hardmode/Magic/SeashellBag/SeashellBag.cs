using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Content.Items.Bags;
using Trinitarian.Content.Items.Weapons.Hardmode.Magic.SeashellBag;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Magic.SeashellBag
{
    public class SeashellBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean Bag");
            Tooltip.SetDefault("Unleashes a rune that shoots homing seashells\nOnly 5 can be conjured at a time.");
        }
        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item1;
            item.shootSpeed = 15;
            item.magic = true;
            item.mana = 30;
            item.crit = 4;
            item.damage = 30;
            item.knockBack = 4f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 22;
            item.useTime = 22;
            item.width = 40;
            item.height = 36;
            item.rare = ItemRarityID.Orange;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.maxStack = 1;
            item.autoReuse = false;
            item.value = Item.sellPrice(0, 59, 80, 0);
            item.shoot = ModContent.ProjectileType<SeashellBagProj>();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<OceanBar>(), 8);
            recipe.AddIngredient(ItemID.Bone, 35);
            recipe.AddIngredient(ItemID.Coral, 10);
            recipe.AddIngredient(ItemID.SpellTome, 1);
            recipe.AddIngredient(ItemType<AdvancedLootBag>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}