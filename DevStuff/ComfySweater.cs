using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HypercosmMod.DevStuff
{
	[AutoloadEquip(EquipType.Body)]
	public class ComfySweater : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Comfy Sweater");

		}
		public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
			item.value = 10000;
			item.rare = 7;
                        item.vanity = true;
		}
	}
}