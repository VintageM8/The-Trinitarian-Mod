using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Accessories
{
    public class SnowCuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snow Cuffs");
            Tooltip.SetDefault("2% increased damage");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 26;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 15, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) += 0.02f;
            player.GetDamage(DamageClass.Ranged) += 0.02f;
            player.GetDamage(DamageClass.Magic) += 0.02f;
            player.GetDamage(DamageClass.Summon) += 0.02f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.BorealWood, 8)
                .AddIngredient(ItemID.SnowBlock, 8)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}