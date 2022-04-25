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
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 34;
            item.width = 66;
            item.height = 66;
            item.useTime = 20;
            item.melee = true;
            item.useAnimation = 20; 
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 12, 0, 0);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item117;
            item.shoot = ModContent.ProjectileType<NightsisterMagicMain>();
            item.shootSpeed = 1f;
            item.channel = true;
            item.noUseGraphic = true;
        }
        //public override string Texture => "Trinitarian/Projectiles/Mage/Test";
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddIngredient(ItemID.DarkShard, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        //public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<NightsisterMagicMain>()] <= 0;
    }
}