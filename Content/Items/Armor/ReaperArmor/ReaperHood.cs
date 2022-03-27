using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Content.Projectiles.Bonuses;
using Trinitarian.Content.Buffs.Bonuses;

namespace Trinitarian.Content.Items.Armor.ReaperArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class ReaperHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reaper Hood");
            Tooltip.SetDefault("Regen increased by 12%");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Green;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<ReaperVest>() && legs.type == ItemType<ReaperGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+1 Minion slot\nYou gain 1 extra minion that steals life an heals you.\nImmune to bleeding";
            player.maxMinions += 1;
            //Add buff immunce shit here

            if (player.whoAmI == Main.myPlayer)
			{
				if (player.FindBuffIndex(ModContent.BuffType<ReaperSetBuff>()) == -1)
				{
					player.AddBuff(ModContent.BuffType<ReaperSetBuff>(), 3600);
				}
				if (player.ownedProjectileCounts[ModContent.ProjectileType<ReaperMinion>()] < 1)
				{	
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, ModContent.ProjectileType<ReaperMinion>(), 20, 1.25f, player.whoAmI, 0f, 0f);
				}
			}
        }
    }
}