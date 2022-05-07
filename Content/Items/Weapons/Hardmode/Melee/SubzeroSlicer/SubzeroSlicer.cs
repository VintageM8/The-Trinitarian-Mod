using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee.SubzeroSlicer;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.SubzeroSlicer
{
    public class SubzeroSlicer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Subzero Slicer");
            Tooltip.SetDefault("Inflicts true pain of the snow.");
        }

        public override void SetDefaults()
        {
            Item.damage = 62;
            Item.DamageType = DamageClass.Melee;
            Item.width = 64;
            Item.height = 64;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 7f;
            Item.crit = 4;
            Item.value = Item.sellPrice(0, 12, 0, 0);
            Item.rare = ItemRarityID.Lime;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SubzeroProj>();
            Item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.HallowedBar, 3)
                .AddIngredient(ItemType<EnchantedIceBall>(), 1)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 440);
        }
    }
}