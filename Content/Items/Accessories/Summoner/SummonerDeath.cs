using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Parts;
using Trinitarian.Content.Items.Materials.Bars;
using Trinitarian.Common.Players;

namespace Trinitarian.Content.Items.Accessories.Summoner
{
    public class SummonerDeath : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Summoner's Death");
            Tooltip.SetDefault("Let your Summons bring pain to your foes\n Increases minions by 2\nAll Summons heal you");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 36;
            Item.height = 36;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 2;

            player.GetModPlayer<TrinitarianPlayer>().SummonerDeath = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<SummonShards>(), 8)
                .AddIngredient(ModContent.ItemType<StarSteel>(), 15)
                .AddIngredient(ItemID.FallenStar, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}