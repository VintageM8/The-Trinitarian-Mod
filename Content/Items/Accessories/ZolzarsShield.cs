using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Accessories
{
    public class ZolzarsShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zolzar's Shield");
            Tooltip.SetDefault("Increases all class damage by 50%\nReduces damage by 25%");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 25, 0, 0);
            Item.rare = ItemRarityID.Expert;
            Item.accessory = true;
            Item.defense = 25;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) += 0.50f;
            player.GetDamage(DamageClass.Ranged) += 0.50f;
            player.GetDamage(DamageClass.Magic) += 0.50f;
            player.GetDamage(DamageClass.Summon) += 0.50f;
            player.endurance += 0.25f;
        }
    }
}
