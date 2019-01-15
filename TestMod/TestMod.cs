using Terraria.ModLoader;

namespace TestMod
{
	class TestMod : Mod
	{
		public TestMod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadBackgrounds = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
