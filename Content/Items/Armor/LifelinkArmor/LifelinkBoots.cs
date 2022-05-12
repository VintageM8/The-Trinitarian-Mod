using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Armor.LifelinkArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class LifelinkBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lifelink Boots");
            Tooltip.SetDefault("8% Increased Melee damage");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 16;
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = ItemRarityID.Green;
            Item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.08f;
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