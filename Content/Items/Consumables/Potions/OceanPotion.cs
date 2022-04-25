using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Buffs.Potion;
using Trinitarian.Content.Items.Materials.Parts;

namespace Trinitarian.Content.Items.Consumables.Potions
{
    public class OceanPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essance of the Ocean");
            Tooltip.SetDefault("Your stats increase in the Ocean Biome.");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 99;
            Item.consumable = false;
            Item.rare = ItemRarityID.Orange;
            Item.buffType = ModContent.BuffType<OceanEssanceBuff>();
            Item.buffTime = 7200;
            Item.value = Item.sellPrice(0, 0, 80, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.Coal, 1)
                .AddIngredient(ItemID.SandBlock, 2)
                .AddIngredient(ModContent.ItemType<Algae>(), 1)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}