using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HypercosmMod.Buffs
{
	public class BabyDroneBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Baby Drone");
			Description.SetDefault("Loyal and adorable");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<HypercosmPlayer>().babyDrone = true;
			player.buffTime[buffIndex] = 18000;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("BabyDronePet")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("BabyDronePet"), 0, 0f, player.whoAmI, 0f, 0f);
			}
			if ((player.controlDown && player.releaseDown))
			{
				if (player.doubleTapCardinalTimer[0] > 0 && player.doubleTapCardinalTimer[0] != 15)
				{
					for (int j = 0; j < 1000; j++)
					{
						if (Main.projectile[j].active && Main.projectile[j].type == mod.ProjectileType("BabyDronePet") && Main.projectile[j].owner == player.whoAmI)
						{
							Projectile lightpet = Main.projectile[j];
							Vector2 vectorToMouse = Main.MouseWorld - lightpet.Center;
							lightpet.velocity += 5f * Vector2.Normalize(vectorToMouse);
						}
					}
				}
			}
		}
	}
}