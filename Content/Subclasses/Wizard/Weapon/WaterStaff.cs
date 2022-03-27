using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Trinitarian.Content.Projectiles.Subclass.Wizard;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Trinitarian.Content.Subclasses.Wizard.Weapon
{
    public class WaterStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Staff");
            Tooltip.SetDefault("Summons a water frenzy around your cursor");
        }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.magic = true;
            item.mana = 12;
            item.width = 54;
            item.height = 54;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3f;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<WaterStaffCentral>();
            item.shootSpeed = 22f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, -6);
        }
    }
}