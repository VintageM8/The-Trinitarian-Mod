using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Projectiles.Magus;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Magus.Spells.Hardmode
{
    public class NightsisterBlade : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightsister's Blade");
            Tooltip.SetDefault("Orbiting Spell\nSummons blades that orbit around you and inflict venom\nForged from the fury of the night.");
            Item.staff[item.type] = true;
        }

        public override void SafeSetDefaults()
        {
            item.damage = 58;
            item.width = 66;
            item.height = 66;
            item.useTime = 20;
            item.noMelee = true;
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