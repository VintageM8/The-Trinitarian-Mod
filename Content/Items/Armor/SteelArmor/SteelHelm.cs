using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Materials.Bars;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Buffs.Bonuses;
using Trinitarian.Content.Projectiles.Bonuses;

namespace Trinitarian.Content.Items.Armor.SteelArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class SteelHelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Helm");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.defense = 4;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<SteelChainmail>() && legs.type == ItemType<SteelLeggings>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemType<SteelBar>(), 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}