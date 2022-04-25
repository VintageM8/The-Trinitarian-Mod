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
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 4;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<SteelChainmail>() && legs.type == ItemType<SteelLeggings>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<SteelBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}