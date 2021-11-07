using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Accessories;
using Trinitarian.Items.Accessories.Ranged;
using Trinitarian.Items.Materials.Parts;

namespace Trinitarian
{
    public class TrinitarianGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
 
        public bool drowning = false;

        public Vector2[] AddPositions = new Vector2[50];
        public int[] Add = new int[50];
        public override void ResetEffects(NPC npc)
        {
            drowning = false;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (drowning)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 8; //change this number to how fast you want the debuff to damage the players. Every 2 is 1 hp lost per second
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.ArmsDealer)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<GunParts>());
                nextSlot++;
            }

            if (type == NPCID.WitchDoctor)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Dartboard>());
                nextSlot++;
            }
        }
    }
}