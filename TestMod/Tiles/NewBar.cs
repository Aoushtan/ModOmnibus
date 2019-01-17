using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;

namespace TestMod.Tiles
{
	public class NewBar : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileShine[Type] = 1100; //The shiny effect
			Main.tileSolid[Type] = true; //fully solid tile
			Main.tileSolidTop[Type] = true; //can be stood on
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1); //The tile's size is 1x1
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("New Bar"); //Translatable name for map
			AddMapEntry(new Color(200, 200, 200), name); //how it looks on map
		}
		
		//Custom drop stuff?
		public override bool Drop(int i, int j)
		{
			Tile t = Main.tile[i, j];
			int style = t.frameX / 10;
			if (style == 0)
			{
				Item.NewItem(i * 16, j * 16, 16, 16, mod.ItemType("NewBar"));
			}
			return base.Drop(i, j);
		}
	}
}