using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Trinitarian.Items.Materials.Parts;
using Trinitarian.Projectiles.Magus;
using static Terraria.ModLoader.ModContent;

namespace Trinitarian.Items.Weapons.Magus.Hardmode
{
    public class ClanleaderClasher : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clanleader Clasher");
        }
        public override void SafeSetDefaults()
        {
            item.UseSound = SoundID.Item1;
            item.shootSpeed = 15;
            item.crit = 4;
            item.damage = 345;
            item.knockBack = 4f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 22;
            item.useTime = 22;
            item.width = 40;
            item.height = 36;
            item.rare = ItemRarityID.Red;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.maxStack = 1;
            item.autoReuse = true;
            item.value = Item.sellPrice(0, 59, 80, 0);
            item.shoot = ModContent.ProjectileType<Clasherproj>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<UlvkilSoul>(), 4);
            recipe.AddIngredient(ItemType<StormEnergy>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}