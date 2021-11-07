using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Mage;
using Trinitarian.Items.Materials.Bars;
using Trinitarian.Items.Materials.Parts;

namespace Trinitarian.Items.Weapons.Mage
{
    public class OrbitingBallStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orbiting Ball Staff");
            Tooltip.SetDefault("A prehardmode Sky Fracture");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 17;
            item.magic = true;
            item.mana = 14;
            item.width = 42;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item43;
            item.shoot = ModContent.ProjectileType<OrbitingBall>();
            item.autoReuse = true;
            item.shootSpeed = 8;
        }
        public override bool AltFunctionUse(Player player)
        {
            TrinitarianPlayer modplayer = player.GetModPlayer<TrinitarianPlayer>();
            if (modplayer.OrbitingProjectileCount[0] > 0) return true;
            return false;
        }
        public override bool CanUseItem(Player player)
        {
            TrinitarianPlayer modplayer = player.GetModPlayer<TrinitarianPlayer>();

            if (player.altFunctionUse == 2)
            {
                item.shoot = ProjectileID.None;
                for (int i = 0; i < Main.projectile.Length; i++)
                {
                    if (Main.projectile[i].active && Main.projectile[i].type == ModContent.ProjectileType<OrbitingBall>() && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].ai[1] != 2)
                    {
                        Main.projectile[i].ai[1] = 1;
                    }
                }
            }
            else
            {
                item.shoot = ModContent.ProjectileType<OrbitingBall>();
                if (modplayer.OrbitingProjectileCount[0] >= 15)
                {
                    return false;
                }
            }
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //important to update the count and array whenever we spawn a new ball.
            TrinitarianPlayer modplayer = player.GetModPlayer<TrinitarianPlayer>();
            //In the second to last argument we assign the ID to the current projectile.
            int temp = Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<OrbitingBall>(), damage, knockBack, player.whoAmI, modplayer.OrbitingProjectileCount[0], 0);
            modplayer.OrbitingProjectile[0, modplayer.OrbitingProjectileCount[0]] = Main.projectile[temp];
            modplayer.OrbitingProjectileCount[0]++;
            modplayer.GenerateProjectilePositions();
            return false;
        }

    }
}