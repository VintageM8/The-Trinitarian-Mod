using Microsoft.Xna.Framework;
using Trinitarian.Content.Projectiles.Subclass.Wizard;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Trinitarian.Content.Subclasses.Wizard.Weapon
{
	public class RuneStaff : ModItem
	{
        public static readonly Color LightColor = new(188, 101, 191);
        public static readonly Vector2 HeldItemRotateVector = new(1, -2);
        public static readonly Vector2 HeldItemOffsetVector = new(4, 24);

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Runic Wand");
			Tooltip.SetDefault("Shoots clumps of horrific runes\nKilling enemies with these runes releases homing shadow souls");
            Item.staff[Item.type] = true;
		}


		public override void SetDefaults()
		{
			Item.width = 56;
            Item.height = 62;

            Item.DamageType = DamageClass.Magic;
            Item.damage = 50;
            Item.crit = 0;
            Item.knockBack = 4f;
            Item.mana = 10;
            Item.rare = ItemRarityID.Quest;
            Item.value = Item.sellPrice(0, 1, 0, 0);

            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.useStyle = ItemUseStyleID.Thrust;
            //Item.UseSound = SoundID.Item45;

            Item.noMelee = true;
            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<RuneProjectile>();
            Item.shootSpeed = 22f;
		}
		 public override bool AltFunctionUse(Player player) => true;

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                type = ModContent.ProjectileType<RuneStaffProjectile>();
                position = Main.MouseWorld;
                velocity = Vector2.Zero;

                SoundEngine.PlaySound(new SoundStyle($"{nameof(Trinitarian)}/Sounds/Custom/MagicShot")
                {
                    Volume = 0.9f,
                    PitchVariance = 0.2f,
                    MaxInstances = 3,
                }, player.position);
            }

            

            position += Vector2.Normalize(new Vector2(HeldItemRotateVector.X * player.direction, HeldItemRotateVector.Y * player.gravDir)) * 50;
            velocity = Vector2.Normalize(Main.MouseWorld - position) * velocity.Length();
            SoundEngine.PlaySound(SoundID.Item43, position);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2) return true;

            var hasClock = player.ownedProjectileCounts[ModContent.ProjectileType<RuneStaffProjectile>()] > 0;
            if (!hasClock)
            {
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0, velocity.Length());
                return false;
            }

            for (int i = 0; i < 2; i++)
            {
                Projectile.NewProjectile(source, position, velocity.RotatedBy(0.2f - 0.4f * i), type, damage, knockback, player.whoAmI, 0, velocity.Length());
            }
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                var mousePos = Main.MouseWorld.ToTileCoordinates();
                return !WorldGen.SolidTile(Main.tile[mousePos.X, mousePos.Y]) && player.ownedProjectileCounts[ModContent.ProjectileType<RuneStaffProjectile>()] == 0;
            }
            return true;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation = (player.MountedCenter + new Vector2(player.direction * HeldItemOffsetVector.X, player.gravDir * HeldItemOffsetVector.Y)).Floor();
            player.itemRotation = player.direction * player.gravDir * new Vector2(-HeldItemRotateVector.Y, -HeldItemRotateVector.X).ToRotation();
        }
	}
}