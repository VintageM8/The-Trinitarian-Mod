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
		private bool npcDashing = false;
		private float DashTime;
		private Vector2 tempPos;
		private Vector2 IntSpeed;
		float TimerStart = 0;
		double angle = 0;

		private const int npcVelocity = 11;
		private const int DashSpeed = 20;
		private const int LightningStrikeSpeed = 16;
		private const int FollowTime = 45;
		private const int ShootingDelay = 45;
		private const int ExplosionTime = 390;
		private const int LightningDMG = 60;
		private const float LightningKB = 1;
		private const float ExplosionDelay = 30;
		private const float OverDashFactor = 1.5f;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("VikingAss");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = -1;
			npc.width = 50;
			npc.height = 50;
			npc.damage = 90;
			npc.defense = 8;
			npc.lifeMax = 15000;
			npc.value = 60f;
			npc.knockBackResist = 0;
			npc.scale = 1f;
			npc.stepSpeed = 0f;
			npc.noGravity = true;
			npc.boss = true;
			npc.noTileCollide = true;
		}
		public override bool PreAI()
		{
			Player target = Main.player[npc.target];
			TrinitarianPlayer globaltarget = target.GetModPlayer<TrinitarianPlayer>();
			int Frames = 20;
			globaltarget.PreviousVelocity[0] = target.velocity;
			for (int i = 0; i < Frames; i++)
			{
				IntSpeed = Vector2.Lerp(IntSpeed, globaltarget.PreviousVelocity[Frames - 1 - i], 0.14f);
			}

			return true;
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
			if (Owner.life <= 0)
            {
				Owner.checkDead();
            }
		}
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
			NPC Owner = Main.npc[(int)AI_Owner];
			Owner.life -= (int)(damage * 0.5);
			if (Owner.life <= 0)
			{
				Owner.checkDead();
			}
		}

        private void Moving()
		{
			NPC Owner = Main.npc[(int)AI_Owner];
			TrinitarianGlobalNPC globalOwner = Owner.GetGlobalNPC<TrinitarianGlobalNPC>();
			int AddNumber = (int)Owner.ai[3]; //this is the number of Adds currently
			Vector2 WantedPosition = globalOwner.AddPositions[AddNumber - (int)AddID - 1];
			npc.velocity = Owner.velocity;
			if (npc.DistanceSQ(WantedPosition) < 13 * 13)
			{
				AI_State = State_Circling;
				npc.Center = WantedPosition;
				TimerStart = 0;
				//npc.velocity = Vector2.Zero;
			}
			else if (AI_State == State_Moving)
			{
				Vector2 npcVel = WantedPosition - npc.Center;
				if (npcVel != Vector2.Zero)
				{
					npcVel.Normalize();
				}
				npcVel *= npcVelocity;
				npc.velocity += npcVel;
			}
			else
            {
				if (TimerStart == 0)
				{
					angle = Math.Atan2(npc.Center.Y - Owner.Center.Y, npc.Center.X - Owner.Center.X);
					TimerStart = Owner.localAI[0];
				}

				double period = 2 * Math.PI / 150f;
				npc.Center = Owner.Center + new Vector2(300 * (float)Math.Cos(period * (Owner.localAI[0] - TimerStart) + angle), 300 * (float)Math.Sin(period * (Owner.localAI[0] - TimerStart) + angle));
			}
		}
		private void Dash()
        {
			Player target = Main.player[npc.target];
			if (AI_Timer == 0) {
				float time = 0;
				Vector2 npcVel = ModTargeting.LinearAdvancedTargeting(npc.Center, target.Center, IntSpeed, DashSpeed, ref time);
				ModTargeting.FallingTargeting(npc, target, new Vector2(0, -28), (int)DashSpeed, ref time, ref npcVel);
				if (time > 15) DashTime = time * OverDashFactor;
				else DashTime = 15 * OverDashFactor;
				//if (npcVel != Vector2.Zero)
				//{
				//    npcVel.Normalize();
				//}
				//npcVel *= DashSpeed;
				npc.velocity = npcVel;
				npcDashing = true;
			}

			if (AI_Timer >= DashTime || AI_Timer >= 120)
            {
				AI_State = State_Moving;
				AI_Timer = -1;
				npcDashing = false;
			}
        }
		private void LightningStrike()
		{
			Player target = Main.player[npc.target];
			if (MoveTo(target.Center + new Vector2(0, -300), LightningStrikeSpeed, false, true))
			{
				if (AI_Timer % 20 == 0)
				{
					Vector2 projVel = target.Center - npc.Center;
					if (projVel != Vector2.Zero)
					{
						projVel.Normalize();
					}
					projVel *= 7;
					int rand = Main.rand.Next(80);					
					Projectile.NewProjectile(npc.Center, projVel, ProjectileID.CultistBossLightningOrbArc, LightningDMG, LightningKB, Main.myPlayer, projVel.ToRotation(), rand);
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
			npc.damage = 0;
			int AddNumber = (int)Owner.ai[3]; //this is the number of Adds currently
											  			
			if (AI_Timer <= AddNumber * FollowTime + 240)
            {
				Vector2 WantedPosition = target.Center + new Vector2(450 * (float)Math.Cos(Math.PI * 2 * AddID / AddNumber), 450 * (float)Math.Sin(Math.PI * 2 * AddID / AddNumber));
				MoveTo(WantedPosition, 14, true, true);
				if ((AI_Timer - 120) == AddID * FollowTime && (AI_Timer - 120) > 0)
				{
					float time = 0;
					Vector2 projVel = ModTargeting.LinearAdvancedTargeting(npc.Center, target.Center, IntSpeed, 7 * 4, ref time);
					ModTargeting.FallingTargeting(npc, target, new Vector2(0, -28), 7 * 4, ref time, ref projVel);
					int rand = Main.rand.Next(80);
					Projectile.NewProjectile(npc.Center, projVel / 4, ProjectileID.CultistBossLightningOrbArc, LightningDMG, LightningKB, Main.myPlayer, projVel.ToRotation(), rand);
				}

			}
			if (AI_Timer == AddNumber * FollowTime + 240 + 1)
            {
				MoveTo(target.Center, 6, false, false, AddNumber * FollowTime + 240 + 1);
            }
				//if (AI_Timer == FollowTime + ShootingDelay)
				//{
				//	Vector2 projVel = target.Center - npc.Center;
				//	if (projVel != Vector2.Zero)
				//	{
				//		projVel.Normalize();
				//	}
				//	projVel *= 7;
				//	Projectile.NewProjectile(npc.Center, projVel, ProjectileID.CultistBossLightningOrbArc, LightningDMG, LightningKB, Main.myPlayer, projVel.ToRotation(), AI_Timer); //TODO randomise the lightning seed
				//}
			if (AI_Timer == AddNumber * FollowTime + 240 + 1 + 75 && AddID == 0)
			{
				for (int i = 0; i < 4; i++)
				{
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8 * (float)Math.Cos(2 * Math.PI * i / 4), 8 * (float)Math.Sin(2 * Math.PI * i / 4), ProjectileID.CultistBossIceMist, 40, 1, target.whoAmI);
				}
			}
			if (AI_Timer >= AddNumber * FollowTime + 240 + 1 + 75 + ExplosionDelay)
			{
				npc.damage = 90;
				AI_State = State_Moving;
				AI_Timer = -1;
			}

		}
		private bool MoveTo(Vector2 WantedPosition, float TravelSpeed, bool follow, bool relative = false, int delay = 0)
		{
			Player player = Main.player[npc.target];
			if (AI_Timer == delay || follow)
			{
				if (relative) npc.velocity = player.velocity;
				tempPos = WantedPosition;
				Vector2 npcVel = tempPos - npc.Center;
				if (npcVel != Vector2.Zero)
				{
					npcVel.Normalize();
				}
				npcVel *= TravelSpeed;
				npc.velocity += npcVel;
			}
			if (npc.DistanceSQ(tempPos) <= 14 * 14)
			{
				npc.Center = tempPos;
				npc.velocity = Vector2.Zero;
				return true;
			}
			return false;
		}
		private void GenerateAddPositions()
		{
			NPC Owner = Main.npc[(int)AI_Owner];			
			TrinitarianGlobalNPC globalOwner = Owner.GetGlobalNPC<TrinitarianGlobalNPC>();
			int AddNumber = (int)Owner.ai[3]; //this is the number of Adds currently
			double period = 2f * Math.PI / 300f;
			for (int i = 0; i < AddNumber; i++)
			{
				globalOwner.AddPositions[i] = npc.Center + new Vector2(300 * (float)Math.Cos(period * (Owner.localAI[0] + (300 / AddNumber * i))), 300 * (float)Math.Sin(period * (Owner.localAI[0] + (300 / AddNumber * i))));
			}
		}
		public override void FindFrame(int frameHeight)
		{
			int factor = (int)((Main.player[npc.target].Center.X - npc.Center.X) / Math.Abs(Main.player[npc.target].Center.X - npc.Center.X));
			npc.frameCounter++;

			if (npc.frameCounter % 6f == 5f)
			{
				npc.frame.Y += frameHeight;
			}
			if (npc.frame.Y >= frameHeight * 4) // 10 is max # of frames
			{
				npc.frame.Y = 0; // Reset back to default
			}
			npc.spriteDirection = factor;
		}
		
		public override bool CheckDead()
		{
			NPC Owner = Main.npc[(int)AI_Owner];
			TrinitarianGlobalNPC globalOwner = Owner.GetGlobalNPC<TrinitarianGlobalNPC>();
			Owner.ai[3]--; //reduce the Addnumber by 1
			int AddNumber = (int)Owner.ai[3];
			npc.boss = false;
            if (AddNumber > 0 && AddID != 0)
            {
                for (int i = (int)AddID; i < AddNumber; i++)
                {
                    globalOwner.Add[i] = globalOwner.Add[i + 1];
                }               
				globalOwner.Add[AddNumber] = globalOwner.Add[0];
			}
			if (AddID == 0 || true)
			{
				for (int j = 0; j < AddNumber; j++)
				{
					globalOwner.Add[j] = globalOwner.Add[j + 1];
				}
			}
            for (int k = 0; k < AddNumber; k++)
			{
				Main.npc[globalOwner.Add[k]].ai[3] = k;
			}
			globalOwner.Add[AddNumber] = 0;
			globalOwner.Add[AddNumber] = 0;
			GenerateAddPositions();
			return true;
		}
	}
}
