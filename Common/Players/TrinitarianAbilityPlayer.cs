using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Trinitarian.Content.Buffs.Damage;
using Terraria.ModLoader.IO;
using Terraria.ID;
using Terraria.Localization;
using Trinitarian.Content.Projectiles.Abilltys.Paladin;
using Trinitarian.Content.Projectiles.Abilltys.Wizard;
using Terraria.Audio;

namespace Trinitarian.Common.Players
{
    public class TrinitarianAbilityPlayer : ModPlayer
    {
        public AbiltyID CurrentA;

        public enum AbiltyID : int
        {
            None,//0
            Paladin,//1
            Elf,//2
            Necromancer,//3
            Wizard//4
        }
        /*public override void TagCompound SaveData()
        {
            return new TagCompound 
            {
				{"CurrentA", (int)CurrentA},
            };
        }
        public override void Load(TagCompound tag)
        {
            CurrentA = (AbiltyID)tag.GetInt("CurrentA");        
        }*/

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            Player p = Main.player[Main.myPlayer];
            if (Trinitarian.UseAbilty.JustPressed && !p.HasBuff(ModContent.BuffType<Cooldown>()))
            {
                switch (CurrentA)
                {//Add stuff for the abiltys here, if you want to make more, add more IDs
                    case (int)AbiltyID.None:
                        // Main.NewText("No Abilty");
                        // p.AddBuff(ModContent.BuffType<Cooldown>(), 120);
                        break;
                    case AbiltyID.Elf:
                        // Main.NewText("Elf");
                        ModAbilitys.ElfAbility(Player);
                        p.AddBuff(ModContent.BuffType<Cooldown>(), 3600);
                        Projectile.NewProjectile(p.GetSource_Misc("Elf"), Main.MouseWorld + new Vector2(0, -50), new Vector2(0, 0), ModContent.ProjectileType<ElfAbilityMirror>(), 10, 0f, p.whoAmI);
                        break;
                    case AbiltyID.Paladin:
                        //Main.NewText("Paladin");
                        p.AddBuff(ModContent.BuffType<Cooldown>(), 3600);
                        Projectile.NewProjectile(p.GetSource_Misc("Paladin"), Main.MouseWorld + new Vector2(0, -50), new Vector2(0, 0), ModContent.ProjectileType<LightSpawner>(), 10, 0f, p.whoAmI);
                        break;
                    case AbiltyID.Necromancer:
                        //Main.NewText("Necromancer");
                        p.AddBuff(ModContent.BuffType<Cooldown>(), 3600);
                        break;
                    case AbiltyID.Wizard:
                        //Main.NewText("Wizard");
                        p.AddBuff(ModContent.BuffType<Cooldown>(), 3600);
                        Projectile.NewProjectile(p.GetSource_Misc("Wizard"), Main.MouseWorld + new Vector2(0, -50), new Vector2(0, 0), ModContent.ProjectileType<ElementalStormBottom>(), 10, 0f, p.whoAmI);
                        break;
                    default:
                        Mod.Logger.InfoFormat("Unknown Ability ID: {0}", CurrentA);
                        break;
                }
            }
        }
    }
}
