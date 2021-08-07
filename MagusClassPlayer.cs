using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Trinitarian
{
    public class MagusClassPlayer : ModPlayer
    {
        public static MagusClassPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<MagusClassPlayer>();
        }

        public float magusDamageAdd;
        public float magusDamageMult = 1f;
        public float magusKnockback;
        public int magusCrit;

        public int magusResourceCurrent;
        public const int DefaultExampleResourceMax = 100; //idk what you have planned for this so leaving blank
        public int exampleResourceMax;
        public int exampleResourceMax2;
        public float exampleResourceRegenRate;
        internal int exampleResourceRegenTimer = 0;
        public static readonly Color HealExampleResource = new Color(187, 91, 201);

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            magusDamageAdd = 0f;
            magusDamageMult = 1f;
            magusKnockback = 0f;
            magusCrit = 0;
        }
    }
}