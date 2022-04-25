using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Melee.SteelSabers
{
    public class FlamingSteelSaber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flaming Steel Saber");
            Tooltip.SetDefault("Inflicts On Fire");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.melee = true;
            item.width = 48;
            item.height = 54;
            item.useTime = 10;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 0, 80, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<SteelSaber>(), 1);
            recipe.AddIngredient(ItemType<FirePart>(), 1);
            recipe.AddIngredient(ItemID.Obsidian, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 320);
        }
    }
}