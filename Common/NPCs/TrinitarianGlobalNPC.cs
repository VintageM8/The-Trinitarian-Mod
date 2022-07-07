using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Items.Accessories.Ranged;
using Trinitarian.Content.Items.Materials.Parts;
using Trinitarian.Content.Items.Quests.Drops;
using Trinitarian.Content.Subclasses.Elf;
using Trinitarian.Content.Subclasses.Wizard;

namespace Trinitarian.Common.NPCs;

public class TrinitarianGlobalNPC : GlobalNPC {
    // TODO: REWORK
    public int[] Add = new int[50];
    public Vector2[] AddPositions = new Vector2[50];

    // TODO: better name
    public bool gettingSucked;
    public override bool InstancePerEntity => true;

    /*public override bool CheckDead(NPC npc)
      {
          if (npc.boss == false && npc.type != ModContent.NPCType<Corpse>())
          {
               NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<Corpse>(), 0, npc.velocity.X, npc.velocity.Y);
           }
          return true;
      }*/
    public override void SetupShop(int type, Chest shop, ref int nextSlot) 
    {

        switch (type) 
        {
            case NPCID.ArmsDealer:
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<GunParts>());
                nextSlot++;
                break;
            case NPCID.WitchDoctor:
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Dartboard>());
                nextSlot++;
                break;
            case NPCID.Merchant: 
            {
                if (NPC.downedFishron) 
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<StormEnergy>());
                    nextSlot++;
                }
                break;
            }
            case NPCID.Dryad: 
            {
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<NymphToken>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<ElfLVL1>());
                    nextSlot++;
                }
                break;
            }
            case NPCID.SkeletonMerchant: 
            {
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<EtoirirHeart>()))
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<WizardLVL1>());
                    nextSlot++;
                }
                break;
            }
            case NPCID.Clothier: 
            {
                if (Main.LocalPlayer.HasItem(ModContent.ItemType<ClothierDildo>()))
                {
                    shop.item[nextSlot].SetDefaults(ItemID.LeinforsAccessory);
                    nextSlot++;
                }
                break;
            }

        }
    }
}
