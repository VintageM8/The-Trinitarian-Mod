using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian
{
    public abstract class MagusDamageItem : ModItem
    {
        public override bool CloneNewInstances => true;

        public virtual void SafeSetDefaults()
        {
        }

        public sealed override void SetDefaults()
        {
            SafeSetDefaults();
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
        }

        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            add += MagusClassPlayer.ModPlayer(player).magusDamageAdd;
            mult *= MagusClassPlayer.ModPlayer(player).magusDamageMult;
        }

        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            knockback += MagusClassPlayer.ModPlayer(player).magusKnockback;
        }

        public override void GetWeaponCrit(Player player, ref int crit)
        {
            crit += MagusClassPlayer.ModPlayer(player).magusCrit;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                tt.text = damageValue + " magus " + damageWord;
            }

        }
    }
}