using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Common;

namespace Trinitarian.Content.Subclasses.Paladin.Weapon
{
    public class KnightSaber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knight's Saber");
            Tooltip.SetDefault("Does 80% more damage to unholy enemies.");
        }

        public override void SetDefaults()
        {
            Item.damage = 32;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 2;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            if (TrinitarianLists.unholyEnemies.Contains(target.type))
            {
                damage = (int)(damage * 1.8f);
            }
        }
    }
}