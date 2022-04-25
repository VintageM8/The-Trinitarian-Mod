using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Subclasses.Paladin.Weapon;

namespace Trinitarian.Content.Subclasses.Paladin
{
    public class HolyCombo : ModPlayer
    {
        public int combo;
        public int comboDuration;

        public override void PostUpdate()
        {
            if (comboDuration > 0 && --comboDuration <= 0)
            {
                combo = 0;
                comboDuration = 0;
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (item.type == ModContent.ItemType<HolyBlade>())
            {
                StartCombo();
            }

            if (item.type == ModContent.ItemType<KnightSaber>())
            {
                StartCombo();
            }

            if (item.type == ModContent.ItemType<PaladinWraith>())
            {
                StartCombo();
            }
        }

        public void StartCombo()
        {
            combo++;
            comboDuration = 300;
        }
    }
}