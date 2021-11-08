using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Trinitarian.NPCs.Bosses.Zolzar;
using Trinitarian.NPCs.Bosses;
using Trinitarian.Items.Materials.Parts;
using Trinitarian.Items.Weapons.Mage;
using Trinitarian.Items.Weapons.Melee;
using Trinitarian.Items.Weapons.Ranged;
using Trinitarian.Items.Weapons.Summoner;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian
{
    public class Trinitarian : Mod
    {
	    public static Trinitarian Mod { get; set; }
	     public static ModHotKey UseAbilty;
	    public Trinitarian()
	    {
		    Mod = this;
		    
	    }
	    public override void Unload()
	    {
		    Mod = null;
		      UseAbilty = null;
	    }
	    public override void Load()
        {
	       UseAbilty = RegisterHotKey("Use Abilty", "R");
	    }

		public override void PostSetupContent()
		{
			var bossChecklist = ModLoader.GetMod("BossChecklist");

			if (bossChecklist != null)
			{
				  bossChecklist.Call("AddBossWithInfo", "Njor, The Frozen Elemental", 2.5f, (Func<bool>)(() => TrinitarianWorld.downedIceBoss), "Use a [i:" + ItemType("FrozenRune") + "] in Snow biome after beating Eye Of Cthulhu");
				 bossChecklist.Call("AddBossWithInfo", "Zolzar, Beserker Viking", 14.5f, (Func<bool>)(() => TrinitarianWorld.downedVikingBoss), "Use a [i:" + ItemType("AsgardsCalling") + "] anywhere, anytime after Moonlord");
			}
		}
	}
}
		
