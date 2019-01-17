using Terraria.ID;
using Terraria.ModLoader;

namespace TestMod.Items.Blocks
{
	public class NewOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[item.type] = 58; //1 less than bar
		}
		
		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.width = 12;
			item.height = 12;
			item.value = 3000;
			item.createTile = mod.TileType("NewOre");
		}
	}
}