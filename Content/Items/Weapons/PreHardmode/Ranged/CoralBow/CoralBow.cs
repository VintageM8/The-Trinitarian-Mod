using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Content.Items.Weapons.PreHardmode.Ranged.CoralBow
{
    public class CoralBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coral Bow");
            Tooltip.SetDefault("Launches Seashells that speeds up over time\nThe Seashell will also break into smaller shards when hit");
        }

        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item67;
            Item.crit = 4;
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 60;
            Item.height = 32;
            Item.useTime = 65;
            Item.useAnimation = 65;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = ItemRarityID.Blue;
            Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("CoralBowProj").Type;
            Item.shootSpeed = 11f;
        }
    }
}