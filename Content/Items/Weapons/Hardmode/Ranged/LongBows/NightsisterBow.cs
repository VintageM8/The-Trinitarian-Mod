using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Trinitarian.Common.Projectiles;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Ranged.LongBows
{
    public class NightsisterBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("NightSister's Bow");
            Tooltip.SetDefault("Holding left click summons arrows around you, which can damage enemys. \n Realsing click launch all of them at your cursor  \n converts certain arrows to wooden ones");
        }
        
        public override void SetDefaults()
        {
            Item.damage = 48;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 32;
            Item.height = 161;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.crit = 8;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 0, 60, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 20f;
            Item.channel = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.ChlorophyteBar, 25)
                .AddIngredient(ItemID.DarkShard, 3)
                .AddIngredient(ItemID.SoulofNight, 14)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
        private readonly int[] BrokenOnes =
        {
            ProjectileID.JestersArrow,
            ProjectileID.PhantasmArrow
        };
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            foreach(int j in BrokenOnes)
            {
                type = (type == j ? ProjectileID.WoodenArrowFriendly : type);
            }
           int i = Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI);
            TrinitarianGlobalProjectile.NightBowArrows.Add(i);
            return false;
        }
    }
}