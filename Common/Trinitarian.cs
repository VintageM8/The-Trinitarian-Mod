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
	     public static ModHotKey UseAbilty;

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
            Prims.Load();
            TrinitarianLists.LoadLists();
	       UseAbilty = RegisterHotKey("Use Abilty", "R");

			 ModTranslation text = CreateTranslation("TrinitarianStuff");
            text = CreateTranslation("BossSpawnInfo.IceBoss");
            text.SetDefault(string.Format("A frozen rune [i:{0}] being used in the Frosted Tundra of the overworld will awaken the ancient guardian.", ModContent.ItemType<FrozenRune>()));
            AddTranslation(text);

            text = CreateTranslation("BossSpawnInfo.OceanGhost");
            text.SetDefault(string.Format("The Sunken Gem... [i:{0}] legand says it can summon a the crew of the lost ship, Sepheris.", ModContent.ItemType<SunkenGem>()));
            AddTranslation(text);

            text = CreateTranslation("BossSpawnInfo.Viking");
            text.SetDefault(string.Format("Time has come[i:{0}] Ragnorok is upon us.", ModContent.ItemType<AsgardsCalling>()));
            AddTranslation(text);

            Filters.Scene["Trinitarian:VikingBoss"] = new Filter(new VikingScreenShaderData("FilterCrystalDestructionColor").UseColor(3f, 0.35f, 0.15f).UseOpacity(0.70f));
            SkyManager.Instance["Trinitarian:VikingBoss"] = new VikingSky();
	    }

		public override void PostSetupContent()
		{
			var bossChecklist = ModLoader.GetMod("BossChecklist");

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


		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) 
		{			

            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                TrinitarianPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<TrinitarianPlayer>();
                if (modPlayer.ShowText)
                {
                    layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "Trinitarian: Title",
                    delegate
                    {
                        BossTitle(modPlayer.TitleID);
                        return true;
                    },
                    InterfaceScaleType.UI));
                }
            }
        }

        internal void BossTitle(int BossID)
        {
            string BossName = "";
            string BossTitle = "";
            Color titleColor = Color.White;
            Color nameColor = Color.White;
            switch (BossID)
            {
                case 1:
                    BossName = "Njor";
                    BossTitle = "The Frozen Elmental";
                    nameColor = Color.FloralWhite;
                    titleColor = Color.Snow;
                    break;
                case 2:
                    BossName = "The Fallen Captain";
                    BossTitle = "Ruler of the Sea";
                    nameColor = Color.LightCyan;
                    titleColor = Color.Cyan;
                    break;
                case 3:
                    BossName = "Zolzar";
                    BossTitle = "The Berserker Viking";
                    nameColor = Color.Cyan;
                    titleColor = Color.DarkCyan;
                    break;
                      default:
                    BossName = "snoop dogg";
                    BossTitle = "high king";
                    nameColor = Color.LimeGreen;
                    titleColor = Color.Green;
                    break;
            }
            Vector2 textSize = Main.fontDeathText.MeasureString(BossName);
            Vector2 textSize2 = Main.fontDeathText.MeasureString(BossTitle) * 0.5f;
            float textPositionLeft = (Main.screenWidth / 2) - textSize.X / 2f;
            float text2PositionLeft = (Main.screenWidth / 2) - textSize2.X / 2f;
            /*float alpha = 255;
			float alpha2 = 255;*/

            DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontDeathText, BossTitle, new Vector2(text2PositionLeft, (Main.screenHeight / 2 - 250)), titleColor, 0f, Vector2.Zero, 0.6f, 0, 0f);
            DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontDeathText, BossName, new Vector2(textPositionLeft, (Main.screenHeight / 2 - 300)), nameColor, 0f, Vector2.Zero, 1f, 0, 0f);
         }


		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<Charcoal>(), 3);
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(ItemID.Torch, 10); 
			recipe.AddRecipe();
		}
	}
}