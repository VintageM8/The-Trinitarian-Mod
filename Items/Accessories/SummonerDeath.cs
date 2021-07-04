using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using Trinitarian.Items.Materials.Bars;

namespace Trinitarian.Items.Accessories
{
    public class SummonerDeath : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Summoner's Death");
            Tooltip.SetDefault("Let your Summons bring pain to your foes\n Increases minions by 3, Increases max life by 25, and increases minion damage by 8%");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 36;
            item.height = 36;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 3;
            player.statLifeMax2 += 25;
            player.minionDamage += 0.08f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SummonShards>(), 8);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}