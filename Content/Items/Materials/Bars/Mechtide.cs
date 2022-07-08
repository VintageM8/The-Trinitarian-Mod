using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Materials.Bars; 

public class Mechtide : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Mechtide");
        Tooltip.SetDefault("Legands say its the strongest metal");
    }

    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.maxStack = 999;
        Item.rare = ItemRarityID.Pink;
        Item.value = Item.sellPrice(0, 2, 50, 0);
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 10;
        Item.autoReuse = true;
        Item.consumable = true;
    }

    public override void AddRecipes()
        {
            CreateRecipe(2)
                .AddIngredient(ItemID.HellstoneBar, 1)
                .AddIngredient(ItemID.SoulofNight, 1)
                .AddIngredient(ItemID.SoulofLight, 1)
                .AddTile(TileID.AdamantiteForge)
                .Register();
        }
}
