using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Ammo;

namespace Trinitarian.Items.Weapons.Ranged
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
            item.damage = 48;
            item.ranged = true;
            item.width = 32;
            item.height = 161;
            item.useTime = 16;
            item.useAnimation = 16;
            item.crit = 8;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.knockBack = 2;
            item.value = Item.sellPrice(0, 0, 60, 0);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 20f;
            item.channel = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
            recipe.AddIngredient(ItemID.DarkShard, 3);
            recipe.AddIngredient(ItemID.SoulofNight, 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
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