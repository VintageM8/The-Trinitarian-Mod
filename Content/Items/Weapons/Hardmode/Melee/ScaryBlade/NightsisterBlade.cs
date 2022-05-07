using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Content.Projectiles.Misc.Orbiting;
using Trinitarian.Content.Items.Weapons.Hardmode.Melee.ScaryBlade;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Content.Items.Weapons.Hardmode.Melee.ScaryBlade
{
    public class NightsisterBlade : ModItem
    {
        public override string Texture => "Trinitarian/Content/Items/Weapons/Hardmode/Melee/ScaryBlade/NightsisterBlade";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightsister's Blade");
            Tooltip.SetDefault("Summons blades that orbit around you and inflict venom\nForged from the fury of the night.");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 34;
            Item.width = 66;
            Item.height = 66;
            Item.useTime = 20;
            Item.DamageType = DamageClass.Melee;
            Item.useAnimation = 20; 
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 12, 0, 0);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item117;
            Item.shoot = ModContent.ProjectileType<NightsisterMagicMain>();
            Item.shootSpeed = 1f;
            Item.channel = true;
            Item.noUseGraphic = true;
        }
        //public override string Texture => "Trinitarian/Projectiles/Mage/Test";
        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.ChlorophyteBar, 12)
                .AddIngredient(ItemID.DarkShard, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
        //public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<NightsisterMagicMain>()] <= 0;
    }
}