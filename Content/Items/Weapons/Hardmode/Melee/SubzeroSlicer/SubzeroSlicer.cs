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
            item.damage = 62;
            item.melee = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 7f;
            item.crit = 4;
            item.value = Item.sellPrice(0, 12, 0, 0);
            item.rare = ItemRarityID.Lime;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<SubzeroProj>();
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 3);
            recipe.AddIngredient(ItemType<EnchantedIceBall>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 440);
        }
    }
}