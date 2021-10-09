using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Trinitarian.Projectiles;

namespace Trinitarian.NPCs.Bosses.Zolzar
{
    class VikingBossAdd : ModNPC
    {

		private const int State_Moving = 1;
		private const int State_Attacking = 2;
		private const int State_Circling = 3;

		public float AI_State
		{
			get => npc.ai[0];
			set => npc.ai[0] = value;
		}
		public float AI_Owner
		{
			get => npc.ai[1];
			set => npc.ai[1] = value;
		}
		public float AI_Timer
		{
			get => npc.ai[2];
			set => npc.ai[2] = value;
		}
		public float AddID
		{
			get => npc.ai[3];
			set => npc.ai[3] = value;
		}
		public float Attack_State
		{
			get => npc.localAI[0];
			set => npc.localAI[0] = value;
		}

		private float DashTime;
		private Vector2 tempPos;

		private const int npcVelocity = 8;
		private const int DashSpeed = 18;
		private const int LightningStrikeSpeed = 18;
		private const int FollowTime = 180;
		private const int ShootingDelay = 5;
		private const int ExplosionTime = 360;
		private const int LightningDMG = 1;
		private const float LightningKB = 1;
		private const float ExplosionDelay = 30;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("VikingAss");
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.width = 100;
			npc.height = 100;
			npc.damage = 0;
			npc.defense = 8;
			npc.lifeMax = 10000;
			npc.value = 60f;
			npc.knockBackResist = 0;
			npc.scale = 1f;
			npc.stepSpeed = 0f;
			npc.noGravity = true;
			npc.boss = false;
			npc.noTileCollide = true;
		}

		public override void AI()
		{
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			if (AI_State == State_Moving || AI_State == State_Circling)
			{
				Moving();
			}
			if (AI_State == State_Attacking)
			{
				if (AI_Timer == 0)
				{
					npc.netUpdate = true;
				}
				switch (Attack_State)
				{
					case 0:
						LightningStrike();
						break;
					case 1:
						Dash();
						break;
					case 2:
						LightningCircle();
						break;
				}
			}
			AI_Timer++;
		}
        public override void OnHitByItem(Player player, Item item, int damage, float knockback, bool crit)
        {
			NPC Owner = Main.npc[(int)AI_Owner];
			Owner.life -= (int)(damage * 0.3);
		}
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
			NPC Owner = Main.npc[(int)AI_Owner];
			Owner.life -= (int)(damage * 0.5);
		}

        private void Moving()
		{
			NPC Owner = Main.npc[(int)AI_Owner];
			TrinitarianGlobalNPC globalOwner = Owner.GetGlobalNPC<TrinitarianGlobalNPC>();
			int AddNumber = (int)Owner.ai[3]; //this is the number of Adds currently
			Vector2 WantedPosition = globalOwner.AddPositions[AddNumber - (int)AddID - 1];
			if (npc.DistanceSQ(WantedPosition) < 13 * 13)
			{
				AI_State = State_Circling;
				npc.Center = WantedPosition;
				npc.velocity = Vector2.Zero;
			}
			else
			{
				Vector2 npcVel = WantedPosition - npc.Center;
				if (npcVel != Vector2.Zero)
				{
					npcVel.Normalize();
				}
				npcVel *= npcVelocity;
				npc.velocity = npcVel;
			}
		}
		private void Dash()
        {
			Player target = Main.player[npc.target];
			if (AI_Timer == 0) {
				Vector2 npcVel = target.Center - npc.Center;
				DashTime = 1.7f* npcVel.Length() / DashSpeed;
				if (npcVel != Vector2.Zero)
                {
					npcVel.Normalize();
                }
				npcVel *= DashSpeed;
				npc.velocity = npcVel;
			}

			if (AI_Timer >= DashTime && AI_Timer > 60)
            {
				AI_State = State_Moving;
				AI_Timer = -1;
            }
        }
		private void LightningStrike()
		{
			Player target = Main.player[npc.target];
			if (MoveTo(target.Center + new Vector2(0, -300), LightningStrikeSpeed, false))
			{
				if (AI_Timer % 20 == 0)
				{
					Vector2 projVel = target.Center - npc.Center;
					if (projVel != Vector2.Zero)
					{
						projVel.Normalize();
					}
					projVel *= 7;
					Projectile.NewProjectile(npc.Center, projVel, ProjectileID.CultistBossLightningOrbArc, 1, 1, Main.myPlayer, projVel.ToRotation(), AI_Timer);
				}
			}
			else
			{
				AI_Timer--;
			}
			if (AI_Timer >= 40)
            {
				AI_State = State_Moving;
				AI_Timer = -1;
            }
		}
		private void LightningCircle()
		{
			NPC Owner = Main.npc[(int)AI_Owner];
			Player target = Main.player[npc.target];
			TrinitarianGlobalNPC globalOwner = Owner.GetGlobalNPC<TrinitarianGlobalNPC>();
			int AddNumber = (int)Owner.ai[3]; //this is the number of Adds currently
											  			
			if (AI_Timer < FollowTime)
            {
				Vector2 WantedPosition = target.Center + new Vector2(300 * (float)Math.Cos(Math.PI * 2 * AddID / AddNumber), 300 * (float)Math.Sin(Math.PI * 2 * AddID / AddNumber));
				MoveTo(WantedPosition, 14, true);
			}
			if (AI_Timer == FollowTime + ShootingDelay)
			{
				Vector2 projVel = target.Center - npc.Center;
				if (projVel != Vector2.Zero)
				{
					projVel.Normalize();
				}
				projVel *= 7;
				Projectile.NewProjectile(npc.Center, projVel, ProjectileID.CultistBossLightningOrbArc, LightningDMG, LightningKB, Main.myPlayer, projVel.ToRotation(), AI_Timer); //TODO randomise the lightning seed
			}
			if (AI_Timer == ExplosionTime)
			{
				for (int i = 0; i < 2; i++)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8 * (float)Math.Cos(2 * Math.PI * i / 2), 8 * (float)Math.Sin(2 * Math.PI * i / 2), ProjectileID.CultistBossIceMist, 1, 1, target.whoAmI);
				}
			}
			if (AI_Timer >= ExplosionTime + ExplosionDelay)
			{
				AI_State = State_Moving;
				AI_Timer = -1;
			}

		}
		private bool MoveTo(Vector2 WantedPosition, float TravelSpeed, bool follow)
		{ 
			if (AI_Timer == 0 || follow)
			{
				tempPos = WantedPosition;
				Vector2 npcVel = tempPos - npc.Center;
				if (npcVel != Vector2.Zero)
				{
					npcVel.Normalize();
				}
				npcVel *= TravelSpeed;
				npc.velocity = npcVel;
			}
			if (npc.DistanceSQ(tempPos) <= 14 * 14)
			{
				npc.Center = tempPos;
				npc.velocity = Vector2.Zero;
				return true;
			}
			return false;
		}

		//this is probably really scuffed. Id handles the the reordering of the adds once one of them dies. I wrote the algorythm for reordering them but forgot that the way the spots are assigned is such that AddID 0 goes to the last spot on the circle.
		//that lead to them rotating against the spinning direction which looked ugly. So i just fixed it by shifting the array to the left by one and then just overriding the AddIDs. The shifting makes it so the try to align with the previous point instead of the next one wich fixes it. 
		//This logic can probably be reworked but it's important that the direction the adds move in after they get reassigned is in the direction of the spin. Because it looks really bad if thats not the case. So carefull !!!!
		public override bool CheckDead()
		{
			NPC Owner = Main.npc[(int)AI_Owner];
			TrinitarianGlobalNPC globalOwner = Owner.GetGlobalNPC<TrinitarianGlobalNPC>();
			Owner.ai[3]--; //reduce the Addnumber by 1
			int AddNumber = (int)Owner.ai[3];
            if (AddID != AddNumber && AddNumber > 0)
            {
                for (int i = (int)AddID; i > 0; i--)
                {
                    globalOwner.Add[i] = globalOwner.Add[i - 1];    														        			
                }
                globalOwner.Add[0] = globalOwner.Add[AddNumber];
				globalOwner.Add[AddNumber] = 0;
			}
			globalOwner.Add[AddNumber] = globalOwner.Add[0];
			for (int j = 0; j < AddNumber; j++)
			{
				globalOwner.Add[j] = globalOwner.Add[j + 1];    																		
			}

			for (int k = 0; k < AddNumber; k++)
			{
				Main.npc[globalOwner.Add[k]].ai[3] = k;
			}
			return true;
		}
	}
}
