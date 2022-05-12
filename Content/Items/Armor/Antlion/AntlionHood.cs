using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Armor.Antlion
{
    [AutoloadEquip(EquipType.Head)]
    public class AntlionHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Hood");
            Tooltip.SetDefault("Minion damage increased by 7%");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = ItemRarityID.Green;
            Item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.07f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<AntlionPlate>() && legs.type == ItemType<AntlionBoots>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+1 Minion slot and you can run very fast (Like the hermes boots)";
            player.maxMinions += 1;
            player.accRunSpeed = 6f;
            player.moveSpeed += 0.05f;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.AntlionMandible, 10)
                .AddIngredient(ItemID.FossilOre, 1)
                .AddIngredient(ItemID.Amber, 2)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}