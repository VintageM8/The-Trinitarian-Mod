using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Armor.LifelinkArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class LifelinkHelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lifelink Helm");
            Tooltip.SetDefault("Regen increased by 2%");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 2;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<LifelinkPlate>() && legs.type == ItemType<LifelinkBoots>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Life regen increased by 12%\n Player speed increased by 3%";
            player.lifeRegen += 12;
            player.moveSpeed += 0.3f;
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