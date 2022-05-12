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
            Item.UseSound = SoundID.Item1;
            Item.shootSpeed = 15;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 30;
            Item.crit = 4;
            Item.damage = 30;
            Item.knockBack = 4f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.width = 40;
            Item.height = 36;
            Item.rare = ItemRarityID.Orange;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.maxStack = 1;
            Item.autoReuse = false;
            Item.value = Item.sellPrice(0, 59, 80, 0);
            Item.shoot = ModContent.ProjectileType<SeashellBagProj>();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 5;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemType<OceanBar>(), 8)
                .AddIngredient(ItemID.Bone, 35)
                .AddIngredient(ItemID.Coral, 10)
                .AddIngredient(ItemID.SpellTome, 1)
                .AddIngredient(ItemType<AdvancedLootBag>(), 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}