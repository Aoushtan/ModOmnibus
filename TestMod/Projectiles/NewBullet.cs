using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Projectiles
{
	public class NewBullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("New Bullet");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5; //The length of old position
			ProjectileID.Sets.TrailingMode[projectile.type] = 0; //recording mode
		}
		
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1; //Default projectile Ai
			projectile.friendly = true; //can hurt enemies
			projectile.hostile = false; //cant hurt player
			projectile.ranged = true; //comes from ranged weapon
			projectile.penetrate = 10; //how many entities it can penetrate
			projectile.timeLeft = 600; //Time the bullet exists (60 = 1 second)
			projectile.alpha = 255; //fully transparent (ai style 1 fades it in)
			projectile.light = 0.5f; //emits a little light
			projectile.ignoreWater = true; //speed is not influenced by water
			projectile.tileCollide = true; //collides with tiles
			projectile.extraUpdates = 1; //doesn't update multiple times per frame
			aiType = ProjectileID.Bullet; //Acts like default bullet
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			//If bullet collides with a tile, reduce the penetration
			projectile.penetrate--;
			//Kill the projectile if it bounces too many times
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				//Hit tiles within path of bullet
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(SoundID.Item10, projectile.position);
				//Make the bullet bounce off of tiles in the opposite velocity
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y) 
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}
		//Draw the projectile so it isn't influenced by light
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int i = 0; i < projectile.oldPos.Length; i++)
			{
				Vector2 drawPos = projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - i) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
		//Plays sound from where the bullet dies
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
		}
	}
}