using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Accessories;
using Trinitarian.Items.Materials.Parts;

namespace Trinitarian
{
    public class TrinitarianGlobalNPC : GlobalNPC
    {
        // TODO: Does nothing, also doesn't work unless you set "InstancePerEntity".
        // public bool drowning;
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