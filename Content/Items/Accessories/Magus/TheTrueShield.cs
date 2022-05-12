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
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = true;
            Item.defense = 15;
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
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<MagusShards>(), 12)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}