using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Trinitarian.Content.Projectiles.Subclass.Paladin;
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
            Tooltip.SetDefault("Does 30% more damage to unholy enemies.");
        }

        public override void SetDefaults()
        {
            item.damage = 12;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 10;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 2;
            item.value = Item.buyPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        
        public override bool UseItem(Player player)
        {
            for (int i = 0; i < Math.Min(10, player.GetModPlayer<HolyCombo>().combo / 2); ++i)
            {
                Projectile.NewProjectile(player.Center, new Vector2(Main.rand.NextFloat(4, 7) * player.direction, Main.rand.NextFloat(-8, -5)), ModContent.ProjectileType<LightningShard>(), item.damage, item.knockBack, player.whoAmI);
            }
            return true;
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
