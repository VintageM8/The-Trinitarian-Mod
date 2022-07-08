using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Armor.LifelinkArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class LifelinkPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lifelink Plate");
            Tooltip.SetDefault("3% increased melee critical strike chance");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 2, 50, 0);
            Item.rare = ItemRarityID.Green;
            Item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) += 3;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.PlatinumBar, 5)
                .AddIngredient(ItemID.LifeCrystal, 2)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}