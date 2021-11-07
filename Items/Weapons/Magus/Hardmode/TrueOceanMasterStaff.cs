using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Trinitarian.Projectiles.Magus;
using Trinitarian.Items.Materials.RadiatedSubclass;

namespace Trinitarian.Items.Weapons.Magus.Hardmode
{
    public class TrueOceanMasterStaff : MagusDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Ocean Master Qaurterstaff");
            Tooltip.SetDefault("Deals Venom, Drowning, Oiled, and OnFire!\nShoots a  projectile that gives an extra boost if you are in the Ocean Biome.");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 89;
            item.crit = 12;
            item.knockBack = 10f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 9;
            item.useTime = 9;
            item.width = 22;
            item.height = 22;
            item.maxStack = 1;
            item.rare = ItemRarityID.Cyan;
            item.consumable = false;
            item.noUseGraphic = true;
            item.melee = false;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<TrueOceanMasterProj>();
            item.shootSpeed = 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeetleHusk, 2);
            recipe.AddIngredient(ModContent.ItemType<OceanMasterStaff>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 3;
        }
    }
}