using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Projectiles.Magus.Spells;
using Trinitarian.Items.Weapons.Magus.Spells.PreHardmode;

namespace Trinitarian.Items.Weapons.Magus.Spells.Hardmode
{
    public class CrimsonDust : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Dust");
            Tooltip.SetDefault("Mythic Spell\nSummons a dark, devistating blast.");
        }
        public override void SetDefaults()
        {
            item.UseSound = SoundID.Item1;
            item.crit = 8;
            item.damage = 58;
            item.knockBack = 8f;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 35;
            item.useTime = 35;
            item.width = 40;
            item.height = 36;
            item.rare = ItemRarityID.Green;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.maxStack = 1;
            item.autoReuse = true;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.shoot = ModContent.ProjectileType<CrimsonBurst>();
            item.shootSpeed = 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ModContent.ItemType<ElementalBlast>(), 1);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}