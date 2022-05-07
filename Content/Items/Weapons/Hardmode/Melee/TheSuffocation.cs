using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Weapon.Melee;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee
{
    public class TheSuffocation : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Suffocation");
        }

        public override void SetDefaults()
        {
            Item.damage = 44;
            Item.crit = 8;
            Item.knockBack = 4f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.width = 22;
            Item.height = 22;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Yellow;
            Item.consumable = false;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<Suffocationproj>();
            Item.shootSpeed = 14;

        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.CursedFlame, 5)
                .AddIngredient(ItemID.WormTooth, 2)
                .AddIngredient(ItemID.DemoniteBar, 25)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
    }
}