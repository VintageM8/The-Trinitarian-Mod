﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Common
{
    public class TrinitarianLists
    {
        public static List<int> unholyEnemies; //you can change the name
        public static List<int> antiMagic;
        public static List<int> plantEnemies;

        public static void LoadLists() //new custom method (can be named whatever but I suggest this)
        {
            unholyEnemies = new List<int> //you can put any list of any integers in here, also you can make like lists of strings too
			{
                NPCID.EaterofSouls,
                NPCID.DevourerBody,
                NPCID.DevourerHead,
                NPCID.DevourerTail,
                NPCID.EaterofWorldsBody,
                NPCID.EaterofWorldsHead,
                NPCID.EaterofWorldsTail,
                NPCID.CorruptBunny,
                NPCID.CorruptGoldfish,
                NPCID.DarkMummy,
                NPCID.CorruptSlime,
                NPCID.Wraith,
                NPCID.Corruptor,
                NPCID.SeekerTail,
                NPCID.SeekerBody,
                NPCID.SeekerHead,
                NPCID.Clinger,
                NPCID.Slimer,
                NPCID.CorruptPenguin,
                NPCID.PigronCorruption,
                NPCID.Crimera,
                NPCID.Herpling,
                NPCID.CrimsonAxe,
                NPCID.CursedHammer,
                NPCID.PigronCrimson,
                NPCID.FaceMonster,
                NPCID.FloatyGross,
                NPCID.BloodCrawler,
                NPCID.BloodCrawlerWall,
                NPCID.BloodFeeder,
                NPCID.BloodJelly,
                NPCID.BrainofCthulhu,
                NPCID.Creeper,
                NPCID.IchorSticker,
                NPCID.CrimsonGoldfish,
                NPCID.CrimsonBunny,
                NPCID.CrimsonPenguin,
                NPCID.BigMimicCrimson,
                NPCID.BigMimicCorruption,
                NPCID.DesertGhoulCorruption,
                NPCID.DesertGhoulCrimson,
                NPCID.DesertLamiaDark,
                NPCID.SandsharkCorrupt,
                NPCID.SandsharkCrimson,
				//putting a comment here just to divide, the above is the dark enemies, the below is undead
				NPCID.Zombie,
                NPCID.Skeleton,
                NPCID.AngryBones,
                NPCID.DarkCaster,
                NPCID.CursedSkull,
                NPCID.SkeletronHead,
                NPCID.SkeletronHand,
                NPCID.BoneSerpentBody,
                NPCID.BoneSerpentHead,
                NPCID.BoneSerpentTail,
                NPCID.Tim,
                NPCID.DoctorBones,
                NPCID.TheGroom,
                NPCID.DungeonGuardian,
                NPCID.ArmoredSkeleton,
                NPCID.Mummy,
                NPCID.LightMummy,
                NPCID.DarkMummy,
                NPCID.SkeletonArcher,
                NPCID.BaldZombie,
                NPCID.Vampire,
                NPCID.VampireBat,
                NPCID.ZombieEskimo,
                NPCID.UndeadViking,
                NPCID.RuneWizard,
                NPCID.PincushionZombie,
                NPCID.SlimedZombie,
                NPCID.SwampZombie,
                NPCID.TwiggyZombie,
                NPCID.ArmoredViking,
                NPCID.FemaleZombie,
                NPCID.HeadacheSkeleton,
                NPCID.MisassembledSkeleton,
                NPCID.PantlessSkeleton,
                NPCID.ZombieRaincoat,
                NPCID.Eyezor,
                NPCID.ZombieMushroom,
                NPCID.ZombieMushroomHat,
                NPCID.RustyArmoredBonesAxe,
                NPCID.RustyArmoredBonesFlail,
                NPCID.RustyArmoredBonesSword,
                NPCID.RustyArmoredBonesSwordNoArmor,
                NPCID.BlueArmoredBones,
                NPCID.BlueArmoredBonesMace,
                NPCID.BlueArmoredBonesNoPants,
                NPCID.BlueArmoredBonesSword,
                NPCID.HellArmoredBones,
                NPCID.HellArmoredBonesMace,
                NPCID.HellArmoredBonesSpikeShield,
                NPCID.HellArmoredBonesSword,
                NPCID.RaggedCaster,
                NPCID.RaggedCasterOpenCoat,
                NPCID.Necromancer,
                NPCID.NecromancerArmored,
                NPCID.DiabolistRed,
                NPCID.DiabolistWhite,
                NPCID.BoneLee,
                NPCID.GiantCursedSkull,
                NPCID.SkeletonSniper,
                NPCID.SkeletonCommando,
                NPCID.TacticalSkeleton,
                NPCID.AngryBonesBig,
                NPCID.AngryBonesBigHelmet,
                NPCID.AngryBonesBigMuscle,
                NPCID.HeadlessHorseman,
                NPCID.ZombieDoctor,
                NPCID.ZombieSuperman,
                NPCID.ZombiePixie,
                NPCID.SkeletonTopHat,
                NPCID.SkeletonAlien,
                NPCID.SkeletonAstonaut,
                NPCID.ZombieXmas,
                NPCID.ZombieSweater,
                NPCID.ZombieElf,
                NPCID.ZombieElfBeard,
                NPCID.ZombieElfGirl,
                NPCID.ArmedZombie,
                NPCID.ArmedZombieCenx,
                NPCID.ArmedZombieEskimo,
                NPCID.ArmedZombiePincussion,
                NPCID.ArmedZombieSlimed,
                NPCID.ArmedZombieSwamp,
                NPCID.ArmedZombieTwiggy,
                NPCID.BoneThrowingSkeleton,
                NPCID.BoneThrowingSkeleton2,
                NPCID.BoneThrowingSkeleton3,
                NPCID.BoneThrowingSkeleton4,
                NPCID.SkeletonMerchant,
                NPCID.GreekSkeleton,
                NPCID.BloodZombie,
                NPCID.DesertGhoul,
                NPCID.DesertGhoulCorruption,
                NPCID.DesertGhoulCrimson,
                NPCID.DesertGhoulHallow,
                NPCID.TheBride,
            };

            antiMagic = new List<int> 
			{
                NPCID.Golem,          
                NPCID.GolemHead,
                NPCID.GolemFistLeft,
                NPCID.GolemFistRight,
                NPCID.CultistBoss,
                NPCID.LunarTowerNebula,
            };

            plantEnemies = new List<int> 
			{
                NPCID.Plantera,
                NPCID.PlanterasHook,
                NPCID.PlanterasTentacle,
                NPCID.ManEater,
                NPCID.AngryTrapper,
                NPCID.Snatcher,
                NPCID.FlyingSnake,
                NPCID.GiantFlyingFox,
            };
        }
        public static void UnloadLists()
        {
            unholyEnemies = null; //unload list
            antiMagic = null;
            plantEnemies = null;
        }
    }
}