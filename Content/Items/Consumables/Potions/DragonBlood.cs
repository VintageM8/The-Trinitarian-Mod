using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Consumables.Potions
{
    public class DragonBlood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon's Blood, Infinite");
            Tooltip.SetDefault("Heals for 180 life\n Has unlimited uses.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 17;
            item.useTime = 17;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 1;
            item.consumable = false;
            item.rare = ItemRarityID.LightRed;
            item.healLife = 180; // While we change the actual healing value in GetHealLife, item.healLife still needs to be higher than 0 for the item to be considered a healing item
            item.potion = true; // Makes it so this item applies potion sickness on use and allows it to be used with quick heal
            item.value = Item.sellPrice(0, 4, 0, 0);
        }
    }
}