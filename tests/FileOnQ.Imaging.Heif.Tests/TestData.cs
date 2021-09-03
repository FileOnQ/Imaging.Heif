using System.Collections.Generic;

namespace FileOnQ.Imaging.Heif.Tests
{
	public static class TestData
    {
		public const string Image1 = "Images\\20210224_023830752_iOS.heic";
		public const string Image2 = "Images\\20210224_024608242_iOS.heic";
		public const string Image3 = "Images\\20210224_024634111_iOS.heic";
		public const string Image4 = "Images\\20210224_032806886_iOS.heic";
		public const string Image5 = "Images\\20210821_095129.heic";

		public static class Integration
		{
			public static class PrimaryImageWrite
			{
				public static IDictionary<string, string> HashCodes => BuildDictionary();

				static IDictionary<string, string> BuildDictionary() =>
					new Dictionary<string, string>
					{
						{ Image1, "FFEA4484A3DE2DBE3D85321EF5ABDFF2C5D4367F6D77F2899CB0D62B270A9388" },
						{ Image2, "AA9A7640A97AA5824ECBD84C3CDCB23117A7E01BC7A313C6390B0702559579A7" },
						{ Image3, "D544E3BA40215AE671DE0D4474489F596AA6AFB27F9774E6C3B322242B17634F" },
						{ Image4, "51BF8E1F356A618E3D86E13560B557B91CB6C6269F0C6298BEBDC447675A4250" },
						{ Image5, "0B223CCEE9712EAD50F51E0AE96DA5276DE98D0ED48B60D958B354B228B88B01" }
					};
			}
		}
	}
}
