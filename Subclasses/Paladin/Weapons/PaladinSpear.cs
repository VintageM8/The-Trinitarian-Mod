using Trinitarian.Projectiles.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Trinitarian.Subclasses.Paladin.Weapons
{
    public class PaladinSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paladin's Spear");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.damage = 17;
            item.scale = 1.1f;
            item.useAnimation = 20;
            item.useTime = 20;
            item.width = 58;
            item.height = 58;
            item.shoot = ModContent.ProjectileType<PaladinSpearProj>();
            item.shootSpeed = 4f;
            item.knockBack = 3.9f;
            item.melee = true;
            item.value = Item.sellPrice(gold: 1);
            item.noUseGraphic = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
    }
}