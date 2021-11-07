using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Accessories.Magus;

namespace Trinitarian.Items.Accessories.Magus
{
    public class TheShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Shield");
            Tooltip.SetDefault("Adds 5 defense\nIncreases all magus damage by 8%\nGrants immunity to frostburn, onfire, and poisened\nIncreses magus crit\nNegats knockback");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
            item.defense = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MagusClassPlayer modPlayer = MagusClassPlayer.ModPlayer(player);
            modPlayer.magusDamageAdd += 0.08f;
            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            modPlayer.magusCrit += 8;
            player.noKnockback = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<JungleShield>(), 1);
            recipe.AddIngredient(ItemID.ObsidianShield, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}