using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.OrbitingProjectileExamples;


namespace Trinitarian.Projectiles.OrbitingProjectileExamples
{
    public class ExampleOrbitingPrjectileStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Example Orbiting Staff");
            Tooltip.SetDefault("Example usecase for the orbitingprojectile class.");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 52;
            item.magic = true;
            item.mana = 18;
            item.width = 42;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item43;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<ExampleOrbitingBall>();
            item.shootSpeed = 7f;
        }
        public override bool AltFunctionUse(Player player)
        {
            TrinitarianPlayer modplayer = player.GetModPlayer<TrinitarianPlayer>();
            if (modplayer.OrbitingProjectileCount[1] > 0) return true;
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
                    if (Main.projectile[i].active && Main.projectile[i].type == ModContent.ProjectileType<ExampleOrbitingBall>() && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].localAI[1] != 5)
                    {
                        Main.projectile[i].localAI[1] = 4;
                    }
                }
            }
            else
            {
                item.shoot = ModContent.ProjectileType<ExampleOrbitingBall>();
                if (modplayer.OrbitingProjectileCount[0] >= 15)
                {
                    return false;
                }
            }
            return true;
        }
    }
}