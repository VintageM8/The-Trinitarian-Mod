using Terraria.ModLoader;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using System.Collections.Generic;
using On.Terraria.DataStructures;
using System.IO;
using Terraria.Localization;
using System.Linq;
using System;
using Trinitarian.Content.NPCs.Bosses.Zolzar;
using Trinitarian.Content.NPCs.Bosses.Ocean;
using Trinitarian.Content.NPCs.Bosses;
using Trinitarian.Content.Items.Materials.Parts;
using Trinitarian.Content.Items.Weapons.PreHardmode.Magic;
using Trinitarian.Content.Items.Weapons.PreHardmode.Melee;
using Trinitarian.Content.Items.Weapons.PreHardmode.Ranged;
using Trinitarian.Content.Items.Consumables.BossSummons;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Common.Players;

namespace Trinitarian.Common
{
    public class Trinitarian : Mod
    {
	    public static Trinitarian Mod { get; set; }
	     public static ModKeybind UseAbilty;

	    public Trinitarian()
	    {
		    Mod = this;
		    
	    }
	    public override void Unload()
	    {
		    Mod = null;
            TrinitarianLists.UnloadLists();
		    UseAbilty = null;
	    }
	    public override void Load()
        {
            TrinitarianLists.LoadLists();
	        UseAbilty = KeybindLoader.RegisterKeybind(Mod, "Use Abilty", "R");

			 /*ModTranslation text = CreateTranslation("TrinitarianStuff"); Boss Checklist stuff, DOnt know if its needed or not, we shall see once the mod can build
            text = CreateTranslation("BossSpawnInfo.IceBoss");
            text.SetDefault(string.Format("A frozen rune [i:{0}] being used in the Frosted Tundra of the overworld will awaken the ancient guardian.", ModContent.ItemType<FrozenRune>()));
            AddTranslation(text);

            text = CreateTranslation("BossSpawnInfo.OceanGhost");
            text.SetDefault(string.Format("The Sunken Gem... [i:{0}] legand says it can summon a the crew of the lost ship, Sepheris.", ModContent.ItemType<SunkenGem>()));
            AddTranslation(text);

            text = CreateTranslation("BossSpawnInfo.Viking");
            text.SetDefault(string.Format("Time has come[i:{0}] Ragnorok is upon us.", ModContent.ItemType<AsgardsCalling>()));
            AddTranslation(text);*/

            Filters.Scene["Trinitarian:VikingBoss"] = new Filter(new VikingScreenShaderData("FilterCrystalDestructionColor").UseColor(3f, 0.35f, 0.15f).UseOpacity(0.70f));
            SkyManager.Instance["Trinitarian:VikingBoss"] = new VikingSky();
	    }
        public override void PostSetupContent()
        {
	    bool HasOreDictionary = ModLoader.TryGetMod("OreDictionary", out var oreDictionary);
	    if (HasOreDictionary && !Main.dedServ)
	    {
	    	oreDictionary.Call("SetDictionaryKey", ModContent.ItemType<Content.Items.Materials.Parts.Charcoal>(), "Charcoal");
	    	oreDictionary.Call("SetDictionaryKey", ModContent.ItemType<Content.Items.Materials.Parts.IceShards>(), "IceShard");
	    	oreDictionary.Call("SetDictionaryKey", ModContent.ItemType<Content.Items.Materials.Bars.SteelBar>(), "SteelBar");
	    }
            bool HasCheckList = ModLoader.TryGetMod("BossChecklist", out var bossChecklist);
            if (HasCheckList)
            {
                bossChecklist?.Call(
                   "AddBoss",
                   2.3f,
                   new List<int> { ModContent.NPCType<IceBoss>() },
                   this,
                   "Njor, the Frozen Elemental",
                   (Func<bool>)(() => TrinitarianWorld.downedIceBoss),
                   ModContent.ItemType<FrozenRune>(),
                   new List<int> { ModContent.ItemType<IceSword>(), ModContent.ItemType<NjorsStaff>(), ModContent.ItemType<IcyTundra>(), ModContent.ItemType<RustedBow>(), },
                   "$Mods.Trinitarian.BossSpawnInfo.IceBoss"
               );

                bossChecklist?.Call(
                    "AddBoss",
                    6.3f,
                    new List<int> { ModContent.NPCType<OceanGhost>() },
                    this,
                    "The Fallen Captian",
                    (Func<bool>)(() => TrinitarianWorld.downedOceanGhost),
                    ModContent.ItemType<SunkenGem>(),
                    "$Mods.Trinitarian.BossSpawnInfo.OceanGhost"
                );


                bossChecklist?.Call(
                   "AddBoss",
                   14.3f,
                   new List<int> { ModContent.NPCType<VikingBoss>() },
                   this,
                   "Zolzar, Berserker Viking",
                   (Func<bool>)(() => TrinitarianWorld.downedViking),
                   ModContent.ItemType<AsgardsCalling>(),
                   new List<int> { ModContent.ItemType<UlvkilSoul>(), },
                   "$Mods.Trinitarian.BossSpawnInfo.Viking"
               );
            }
        }

		public override void AddRecipes()
        {
			Mod.CreateRecipe(ItemID.Torch, 10)
				.AddIngredient(ModContent.ItemType<Charcoal>(), 3)
				.AddIngredient(ItemID.Wood, 8)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
