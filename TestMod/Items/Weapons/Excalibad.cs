using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Items.Weapons
{
	//For armor to auto equip
	//[AutoloadEquip(EquipType.Head)]
	public class Excalibad : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Excalibad");
			Tooltip.SetDefault("An awful pun but decent sword.");
		}
		public override void SetDefaults()
		{
			item.damage = 50; //damage int
			item.crit = 2; //Critical multiplyer
			item.melee = true; //Used for swords and such
			item.width = 40; //hitbox width
			item.height = 40; //hitbox height
			item.useTime = 20; //Frames to use item
			item.useAnimation = 20; //Frames for the animation
			item.useStyle = 1; //Type of use (1 swing, drink 2, etc. find on wiki)
			item.knockBack = 6; //Float value for knockback (max 20)
			item.value = 10000; //Purchase price (value)
			item.rare = 12; //Rarity
			item.UseSound = SoundID.Item1;
			item.autoReuse = true; //Continuous use of item
			//item.maxStack = 1 (sets the items max stack amount)
			//item.useTurn = true (allows you to turn while using)
			//item.mana = 20 Mana use for magic items
			
			//item.magic = true  Used for staffs and other magic weapons
			//item.ranged = true Used for bows, guns, and such
			//item.thrown = true Used for throwing weapons
			//item.summon = true Used for summoning items (minions)
			
			//--------For ranged weapons (find ids)------------
			//item.shoot = ProjectileID.HellfireArrow;
			//item.shootSpeed = 4f;
			//item.useAmmo = AmmoID.Arrow; //Type of ammo
			//item.noMelee = true if item itself does not deal damage
			
			//item.noUseGraphic = true Item doesnt render when used
			//item.channel = true Item has special effect when held (yoyo)
			
			//--------Armor defense-------------
			//item.defense = 5; 
			
			//For accessories
			//item.accessory = true;
		}
		//Adds the recipe for the item to the game
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("NewBar"));
			recipe.AddTile(mod.TileType("ModBench"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		/*--------------ARMOR SET METHODS------------\
		//Checks if the player is using an armor set
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ExampleBody")
			&& legs.type == mod.ItemType("ExampleLegs");
		}
		
		//Applies a bonus to the player if they are using the armor set
		public override void UpdateArmorSet(Player player)
		{
			//Example effect
			player.meleeDamage *= 1.2f;
		}
		
		//Change other variables when armor is equiped
		public override void UpdateEquip(Player player)
		{
			//makes the player faster while equipped
			player.moveSpeed *= 1.2f;
		}
		
		//-----------Accessory Methods-----------
		//Adds effect to accessory
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed *= 1.2f;
		}*/
	}
}
