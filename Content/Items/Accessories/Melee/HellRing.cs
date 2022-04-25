using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;

namespace Trinitarian.Content.Items.Accessories.Melee
{
    public class HellRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell's Ring");
            Tooltip.SetDefault("Life is increased by 25\nLife regen increased\n Melee damage increased by 8%\n No fellowship for this ring");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 24;
            Item.height = 26;
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.rare = ItemRarityID.Blue;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 25;
            player.lifeRegen += 2;
            player.GetDamage(DamageClass.Melee) += 0.08f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<SteelBar>(), 4)
                .AddIngredient(ItemID.HellstoneBar, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
