using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Content.Projectiles.Boss.Ocean;
using Trinitarian.Content.NPCs.Bosses.Ocean;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Common.Players;
using Trinitarian.Common;

namespace Trinitarian.Content.NPCs.Bosses.Ocean
{
    [AutoloadBossHead]
    public class OceanGhost : ModNPC
    { 
        bool expert = Main.expertMode;
        NPC[] hands;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Fallen Captian");
        }
        public override void SetDefaults()
        {
            npc.width = 120;
            npc.height = 120;
            npc.damage = 60;
            npc.defense = 24;
            npc.lifeMax = 40500;
            npc.HitSound = SoundID.NPCHit57;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 3f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.aiStyle = -1;
            npc.netAlways = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = (int)(npc.damage * 0.5f);
            npc.lifeMax = (int)(npc.lifeMax * 0.5f * bossLifeScale);
            npc.defense += 3 * numPlayers;
        }
        int amountoftimes = 0;
        bool DrawLinearDash = false;
        Vector2 playeroldcenter;
        Vector2 npcoldcenter;
        Vector2 maxvelocity;
        int progress = 0;
        int[] AttackArray;
        float[] phasepercentages;
        int[] DashArray;
        Vector2[] PositionsList;
        bool Dash = true;
        int difficulty;
        float dashproj = 0f;
        public override void AI()
        {
            Player player = Main.player[npc.target];

            //Despawning stuff
            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = npc.velocity.Y - 0.1f;
                Main.NewText("Bye");
                if (npc.timeLeft > 20)
                {
                    npc.timeLeft = 20;
                    return;
                }
            }


            if (npc.active)
                
            if (npc.ai[0] != 0)
            {
                difficulty = CalculateDifficulty(phasepercentages, 5);
            }
            switch (npc.ai[0])
            {
                //first tick
                case 0:
                    {
                        Main.PlaySound(SoundID.Roar, npc.Center, 0);
                        AttackArray = InitialAttackArray();
                        phasepercentages = InitalPercentageArray();
                        DashArray = InitialDashArray();
                        if (++npc.ai[1] > 60)
                        {
                            npc.ai[1] = 0;
                            npc.ai[0] = GetAttack();
                            CombatText.NewText(npc.getRect(), Color.Gray, GetDialoug((int)npc.ai[0]));
                        }
                    }
                    break;
                // randomly offset spikes
                case 1:
                    {
                        bool expertMode = Main.expertMode;
                        if (npc.ai[1] == 0)
                            npc.velocity = Vector2.Zero;

                        if (++npc.ai[1] == 10)
                        {
                            Main.PlaySound(SoundID.Item5);
                            for (int i = 0; i < (difficulty > 4 ? 10 : 7); i++)
                            {
                                int dmg = expertMode ? 32 : 48;
                                Vector2 place = npc.Center + MethodHelper.GetRandomVector(250, 250, 350, 350, -350, -350);
                                Projectile.NewProjectile(place, MethodHelper.DirectionTo(player.Center, place).RotatedByRandom(0.3f) * 10, ModContent.ProjectileType<Bubble>(), npc.damage, 0.5f, Main.myPlayer);
                            }
                        }
                        if (npc.ai[1] > 60)
                        {
                            npc.ai[1] = 0;
                            if (++amountoftimes >= 1)
                            {
                                amountoftimes = 0;
                                npc.ai[0] = GetAttack();
                                CombatText.NewText(npc.getRect(), Color.Gray, GetDialoug((int)npc.ai[0]));
                            }
                        }
                    }
                    break;
                //move in circle around player and fire spikes
                case 2:
                    {
                        bool expertMode = Main.expertMode;
                        int pointmax = 36;
                        PositionsList = CalculatePointsInAcircle(player.Center, 300, pointmax);
                        if (npc.ai[1] == 0)
                            progress = FindClosesPoint(PositionsList);
                        maxvelocity = npc.velocity = FollowPoints(PositionsList, out var newprogress, progress, npc.Center, 10);
                        progress = newprogress;
                        if (++npc.ai[1] > 8)
                        {
                            npc.ai[1] = 1;
                            npc.ai[2] += (difficulty > 3 ? 0.1f : 0.2f);
                        }
                        if (npc.ai[2] >= (difficulty > 3 ? 0.1 : 1))
                        {
                           int dmg = expertMode ? 32 : 48;
						   Projectile.NewProjectile(npc.Center, npc.DirectionTo(player.Center) * 9, ModContent.ProjectileType<OceanSpike>(), npc.damage, 0.5f, Main.myPlayer);
                            npc.ai[2] = 0;
                        }
                        if (progress >= pointmax)
                        {
                            progress = 0;
                            if (amountoftimes++ >= 1)
                            {
                                npc.ai[0]++;
                            }
                        }

                    }
                    break;
                //decelarate after spin
                case 3:
                    {
                        npc.velocity = Decelerate(npc.ai[2], maxvelocity);
                        npc.ai[2] += 0.06f;
                        if (npc.ai[2] >= 1)
                        {
                            PositionsList = null;
                            maxvelocity = Vector2.Zero;
                            npc.velocity = Vector2.Zero;
                            amountoftimes = 0;
                            ResetAllAis();
                            npc.ai[0] = GetAttack();
                            CombatText.NewText(npc.getRect(), Color.Gray, GetDialoug((int)npc.ai[0]));
                        }
                    }
                    break;
                //dash 3 times
                case 4:
                    {
                        bool expertMode = Main.expertMode;
                        if (npc.ai[1] == 0)
                        {
                            DrawLinearDash = true;
                            playeroldcenter = player.Center;
                            npcoldcenter = npc.Center;
                            Main.PlaySound(SoundID.Roar, npc.Center, 0);   
                            player.GetModPlayer<TrinitarianPlayer>().ScreenShake = 10;
                        }
                        npc.ai[2] += 0.03f;
                        dashproj += 0.01f;
                        if (difficulty > 2 && dashproj > 0.06f)
                        {
                            dashproj = 0;
                            int dmg = expertMode ? 32 : 48;
                            Projectile.NewProjectile(npc.Center, -MethodHelper.Normalized(npc.velocity).RotatedBy(-0.15) * 5, ModContent.ProjectileType<Bubble>(), npc.damage, 0.5f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, -MethodHelper.Normalized(npc.velocity).RotatedBy(0.15) * 5, ModContent.ProjectileType<OceanSpike2>(), npc.damage, 0.5f, Main.myPlayer);
                        }
                        if (++npc.ai[1] == 30)
                        {
                            maxvelocity = npc.velocity = LinearDashVelocity(40f, npc.Center, playeroldcenter);
                        }
                        if (npc.ai[1] > 30f)
                        {
                            npc.ai[3] += 0.4f / MathHelper.Clamp(npc.Distance(playeroldcenter), 0, 10);
                            npc.velocity = Decelerate(npc.ai[3], maxvelocity);
                        }
                        if (npc.ai[3] >= 1f)
                        {
                            ResetAllAis();
                            playeroldcenter = Vector2.Zero;
                            npcoldcenter = Vector2.Zero;
                            maxvelocity = Vector2.Zero;
                            npc.velocity = Vector2.Zero;
                            DrawLinearDash = false;
                            progress = 3;
                            if (++amountoftimes > 3)
                            {
                                amountoftimes = 0;
                                npc.ai[0] = GetAttack();
                                npc.ai[1] = 0;
                                CombatText.NewText(npc.getRect(), Color.Gray, GetDialoug((int)npc.ai[0]));
                            }
                        }
                    }
                    break;
                //shotgun blast
                case 5:
                    {
                        if (npc.ai[2] > 0)
                        {
                            int projamount = 4;
                            if (++npc.ai[1] == 15)
                            {
                                Main.PlaySound(SoundID.Item5);
                                for (int i = 0; i < projamount; i++)
                                    Projectile.NewProjectile(npc.Center, MethodHelper.DirectionTo(player.Center, npc.Center).RotatedBy(i == 0 ? 0 : IsEven(i) ? 0.05 * i : -0.05 * i) * (difficulty > 4 ? 12 : 7), ModContent.ProjectileType<OceanSpike3>(), npc.damage, 0.5f, Main.myPlayer);
                            }
                            if (npc.ai[1] > 15)
                            {
                                npc.ai[1] = 0;
                                if (++amountoftimes >= 3)
                                {
                                    ResetAllAis();
                                    amountoftimes = 0;
                                    npc.ai[0] = GetAttack();
                                    CombatText.NewText(npc.getRect(), Color.Gray, GetDialoug((int)npc.ai[0]));
                                }
                            }
                        }
                        else
                        {
                            npc.velocity = npc.DirectionTo(player.Center) * 10;
                            if (npc.Distance(player.Center) < 100)
                            {
                                npc.velocity = Vector2.Zero;
                                npc.ai[2]++;
                            }
                        }
                    }
                    break;
                // cone dash
                case 6:
                    {
                        bool expertMode = Main.expertMode;
                        if (npc.ai[1] == 0)
                        {
                            int dmg = expertMode ? 32 : 48;
                            for (float i = -0.3f; i < 0.3f; i += 0.1f)
                                Projectile.NewProjectile(npc.Center + Vector2.UnitX * (i < 0 ? 40 : -40), npc.DirectionFrom(npc.Center).RotatedBy(i) * 5, ModContent.ProjectileType<OceanSpike>(), npc.damage, 0.5f, Main.myPlayer);
                            DrawLinearDash = true;
                            playeroldcenter = player.Center;
                            npcoldcenter = npc.Center;
                            Main.PlaySound(SoundID.Roar, npc.Center, 0);
                        }
                        npc.ai[2] += 0.01f;
                        if (++npc.ai[1] == 17)
                        {
                            maxvelocity = npc.velocity = LinearDashVelocity(60f, npc.Center, playeroldcenter);
                        }
                        if (npc.ai[1] > 17f)
                        {
                            npc.ai[3] += 0.4f / MathHelper.Clamp(npc.Distance(playeroldcenter), 0, 10);
                            npc.velocity = Decelerate(npc.ai[3], maxvelocity);
                        }
                        if (npc.ai[3] >= 1f)
                        {
                            ResetAllAis();
                            playeroldcenter = Vector2.Zero;
                            npcoldcenter = Vector2.Zero;
                            maxvelocity = Vector2.Zero;
                            npc.velocity = Vector2.Zero;
                            DrawLinearDash = false;
                            npc.ai[0] = GetAttack();
                            CombatText.NewText(npc.getRect(), Color.Gray, GetDialoug((int)npc.ai[0]));
                        }
                    }
                    break;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if (DrawLinearDash)
                DrawDashLinear(spriteBatch, npcoldcenter, playeroldcenter, Color.Lerp(Color.White, Color.Red, npc.ai[2]));
            return base.PreDraw(spriteBatch, drawColor);
        }
        private bool AnyProjectiles(int type)
        {
            bool any = false;
            for (int i = 0; i < Main.maxProjectiles; i++)
                if (Main.projectile[i].type == type)
                    any = true;
            return any;
        }
        private int GetAttack()
        {
            return AttackArray[Main.rand.Next(0, AttackArray.Length - 1)];
        }
        private void ChangeAttacks()
        {
            int Difficulty = CalculateDifficulty(phasepercentages, 5);
            if (Difficulty < 2 && ContainsNumber(6))
                RemoveNumberFromArray(6, 2);
            if (Difficulty >= 2 && !ContainsNumber(6))
                AddAtRandom(6, 3);
            if (Difficulty < 3 && ContainsNumber(5))
                RemoveNumberFromArray(5, GetRandom1());
            if (Difficulty >= 3 && !ContainsNumber(5))
                AddAtRandom(5, 2);

        }
        private string GetDialoug(int num)
        {
            string text = "null";
            switch (num)
            {
                case 1:
                    text = "Earth Path: Gaia's Web"; // this is an attack in which projectiles appear all around the boss and fire towards the player with a slight offset
                    break;
                case 2:
                    text = "Mixed Path: Wind And Earth: Cycling Cascade"; // the boss circles the player and fires projectiles at them
                    break;
                case 4:
                    text = "Wind Path: 3 Winds Dash"; // the boss dashes 3 times
                    break;
                case 5:
                    text = "Earth Path: Avalanche"; // the boss fires a spread of projectiles towards the player
                    break;
                case 6:
                    text = "Wind Path: Storm With No Eye"; // two lasers spawn on either side of the player, the player must escape this cone before the boss dashes through it
                    break;
                    // wind path is for movement attacks, earth path is for projectile attacks
            }
            return text;
        }
        private int[] InitialAttackArray()
        {
            int[] array = new int[10];
            array[0] = 1;
            array[1] = 1;
            array[2] = 2;
            array[3] = 1;
            array[4] = 2;
            array[5] = 2;
            array[6] = 4;
            array[7] = 4;
            array[8] = 4;
            array[9] = 2;
            return array;
        }
        private int[] InitialDashArray()
        {
            int[] array = new int[6];
            array[0] = 4;
            array[1] = 4;
            array[2] = 4;
            array[3] = 4;
            array[4] = 4;
            array[5] = 4;
            return array;
        }
        private float[] InitalPercentageArray()
        {
            float[] array = new float[4];
            array[0] = 15f;
            array[1] = 45f;
            array[2] = 75f;
            array[3] = 90f;
            return array;
        }
        private int GetRandom1()
        {
            int num = -1;
            switch (Main.rand.Next(1, 2))
            {
                case 1:
                    num = 1;
                    break;
                case 2:
                    num = 2;
                    break;
            }
            return num;
        }
        private void AddAtRandom(int num, int amount)
        {
            for (int i = 0; i < amount; i++)
                AttackArray[Main.rand.Next(0, AttackArray.Length - 1)] = num;
        }
        private void AddAtRandomDash(int num, int amount)
        {
            for (int i = 0; i < amount; i++)
                DashArray[Main.rand.Next(0, DashArray.Length - 1)] = num;
        }
        private void RemoveNumberFromArray(int remove, int replace)
        {
            for (int i = 0; i < AttackArray.Length - 1; i++)
                if (AttackArray[i] == remove)
                    AttackArray[i] = replace;
        }
        private void RemoveNumberFromDashArray(int remove, int replace)
        {
            for (int i = 0; i < DashArray.Length - 1; i++)
                if (DashArray[i] == remove)
                    DashArray[i] = replace;
        }
        private bool ContainsNumber(int number)
        {
            bool contains = false;
            for (int i = 0; i < AttackArray.Length - 1; i++)
                if (AttackArray[i] == number)
                    contains = true;
            return contains;
        }
        private bool ContainsNumberDash(int number)
        {
            bool contains = false;
            for (int i = 0; i < DashArray.Length - 1; i++)
                if (DashArray[i] == number)
                    contains = true;
            return contains;
        }
        private int CalculateDifficulty(float[] percentages, int MaxDifficulty)
        {
            int difficulty = 1;
            if (npc.life < npc.lifeMax * 0.75f)
                difficulty += 1;
            if (npc.life < npc.lifeMax * 0.5f)
                difficulty += 1;
            if (npc.life < npc.lifeMax * 0.25f)
                difficulty += 1;
            return (int)MathHelper.Clamp(difficulty, 1, MaxDifficulty);
        }
        /*
        private int CalculateDifficulty(float[] phasepercentages, int maxdifficutly)
        {
            float difficulty;
            //the minimum value should be based on the health, so that things dont get too easy
            float num1 = npc.life / npc.lifeMax;
            num1 *= 100;
            float num2 = 0;
            while (num2 < phasepercentages.Length - 1)
            {
                num2++;
                if (num1 < phasepercentages[(int)num2])
                    break;
            }
            difficulty = (maxdifficutly - 1) - num2;
            // now we account for how much damage in comparison to the max health the players are doing
            float partydamage = 0;
            foreach (Player player in Main.player)
                partydamage += player.dpsDamage;
            float num4 = partydamage / npc.lifeMax;
            num4 *= 10;
            difficulty += num4;
            //party health
            float partyhealth = 0;
            float partymaxhealth = 0;
            foreach (Player player in Main.player)
            {
                partyhealth += player.statLife;
                partymaxhealth += player.statLifeMax;
            }
            float num5 = partyhealth / partymaxhealth;
            num5 *= 100;
            difficulty += (int)Math.Round(0.5 - num5);
            if (Main.expertMode)
                difficulty += 0.5f;
            if (difficulty < 1)
                difficulty = 1;
            return (int)Math.Round(difficulty);
        }
        */
        private Vector2[] CalculatePointsInAcircle(Vector2 origin, float radius, int numLocations)
        {
            Vector2[] list = new Vector2[numLocations + 1];
            for (int i = 0; i < numLocations; i++)
            {
                list[i] = origin + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / numLocations * i)) * radius;
            }
            return list;
        }
        private Vector2 FollowPoints(Vector2[] points, out int newprogress, int progress, Vector2 start, float speed = 1)
        {
            newprogress = progress;
            Vector2 velocity = MethodHelper.DirectionTo(points[progress], start) * speed;
            if (Vector2.Distance(points[progress], start + velocity) < 200)
            {

                newprogress++;
            }
            return velocity;
        }
        private int FindClosesPoint(Vector2[] points)
        {
            int closest = 0;
            for (int i = 0; i < points.Length - 1; i++)
                if (npc.Distance(points[i]) < npc.Distance(points[closest]))
                    closest = i;
            return closest;
        }
        private void ResetAllAis(bool excludezero = true)
        {
            for (int i = excludezero ? 1 : 0; i < npc.ai.Length; i++)
                npc.ai[i] = 0;
        }
        private bool IsEven(int num)
        {
            return num % 2 == 0;
        }
        private Vector2 LinearDashVelocity(float speed, Vector2 start, Vector2 end)
        {
            Vector2 velocity = MethodHelper.DirectionTo(end, start);
            velocity *= speed;
            return velocity;
        }
        private Vector2 Decelerate(float progress, Vector2 maxvelocity)
        {
            Vector2 velocity = Vector2.Lerp(maxvelocity, Vector2.Zero, progress);
            return velocity;
        }
        private void DrawDashLinear(SpriteBatch spriteBatch, Vector2 start, Vector2 end, Color color)
        {
            Vector2 unit = end - start;
            unit.Normalize();
            DrawLine(start, end + unit * 4000, color, spriteBatch);
        }
        private void DrawLine(Vector2 start, Vector2 end, Color color, SpriteBatch spriteBatch, float scale = 1)
        {
            Vector2 unit = end - start;
            float length = unit.Length();
            unit.Normalize();
            for (int i = 0; i < length; i++)
            {
                Vector2 drawpos = start + unit * i - Main.screenPosition;
                spriteBatch.Draw(ModContent.GetTexture("Trinitarian/Assets/Textures/Pixel"), drawpos, null, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }
        
    }
}