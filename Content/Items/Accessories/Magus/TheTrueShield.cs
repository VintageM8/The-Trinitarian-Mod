using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;

namespace Trinitarian.Content.Items.Accessories.Magus
{
    public class TheTrueShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The True Shield");
            Tooltip.SetDefault("For the price of 45 life you are immune to Moon Bite, and Feral Bite.\nAll knockback is negated");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.accessory = true;
            item.defense = 15;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[BuffID.Rabies] = true;
            player.buffImmune[BuffID.MoonLeech] = true;
            player.noKnockback = true;
            player.statLifeMax2 -= 45;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MagusShards>(), 12);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}