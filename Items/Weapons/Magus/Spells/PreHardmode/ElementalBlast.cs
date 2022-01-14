using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Trinitarian.Projectiles.Magus.Spells;

namespace Trinitarian.Items.Weapons.Magus.Spells.PreHardmode
{
    public class ElementalBlast : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Blast");
            Tooltip.SetDefault("Mythic Spell\nSummons devistating blast.");
        }
        public override void SafeSetDefaults()
        {
            item.UseSound = SoundID.Item1;
            item.crit = 8;
            item.damage = 25;
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
            item.shoot = ModContent.ProjectileType<EnergyBurst>();
            item.shootSpeed = 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ItemID.DemoniteBar, 22);
            recipe.AddIngredient(ItemID.ShadowScale, 12);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddTile(TileID.Anvils);
            recipe2.AddIngredient(ItemID.CrimtaneBar, 22);
            recipe2.AddIngredient(ItemID.TissueSample, 12);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}