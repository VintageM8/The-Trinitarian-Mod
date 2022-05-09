using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Trinitarian.Content.Projectiles.Subclass.Paladin.Combo;
using Trinitarian.Common;
using static Terraria.ModLoader.ModContent;
using System;

namespace Trinitarian.Content.Subclasses.Paladin.Weapon
{
    public class HolyBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Blade");
            Tooltip.SetDefault("After 5 consecutive hits, holy energy will encapsulate near foes\n After 7 hits you will recive Shadow Dodge buff\nDoes 30% more damage to unholy enemies.");
        }

        public override void SetDefaults()
        {
            Item.damage = 12;
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
