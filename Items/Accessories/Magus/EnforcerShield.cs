using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Items.Accessories.Magus
{
    public class EnforcerShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enforcer Shield");
            Tooltip.SetDefault("Adds 3 defense\nIncreases magus damage by 6%\nGrants immunity to frostburn");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
            item.defense = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MagusClassPlayer modPlayer = MagusClassPlayer.ModPlayer(player);
            modPlayer.magusDamageAdd += 0.06f;
            player.buffImmune[BuffID.Frostburn] = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SnowBlock, 10);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Anvils);
            recipe2.AddIngredient(ItemID.SnowBlock, 10);
            recipe2.AddIngredient(ItemID.LeadBar, 5);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}