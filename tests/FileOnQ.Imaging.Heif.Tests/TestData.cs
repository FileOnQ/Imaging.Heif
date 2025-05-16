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
			public static class PrimaryImageSave

			{
				public static IDictionary<string, string> HashCodes => BuildDictionary();

				static IDictionary<string, string> BuildDictionary() =>
					new Dictionary<string, string>
					{
						{ Image1, "357C170D04A5FD62D19E782FC05EBD717B656DADB1ABA4920E042D91A265F294" },
						{ Image2, "DBB83C7C34F11752644B42C8B5DA94D4397AF5C5C4E8051DA81DCCEC4DDC229C" },
						{ Image3, "5532E2143B056E2D125D83B4CCA55136C360F60F039831249F241DB42C6BD6B4" },
						{ Image4, "6A78A1511735BF2573B48AC23071FCE493E8A81F2A8A409C290D12EDA8553C83" },
						{ Image5, "14B45F3337FB5AC9C252F16E0E3A57A42D6A9BC124950B7F35DAE16B547C385D" }
					};
			}

			public static class ThuumbnailSave
			{
				public static IDictionary<string, string> HashCodes => BuildDictionary();

				static IDictionary<string, string> BuildDictionary() =>
					new Dictionary<string, string>
					{
						{ Image1, "357C170D04A5FD62D19E782FC05EBD717B656DADB1ABA4920E042D91A265F294" },
						{ Image2, "DBB83C7C34F11752644B42C8B5DA94D4397AF5C5C4E8051DA81DCCEC4DDC229C" },
						{ Image3, "5532E2143B056E2D125D83B4CCA55136C360F60F039831249F241DB42C6BD6B4" },
						{ Image4, "6A78A1511735BF2573B48AC23071FCE493E8A81F2A8A409C290D12EDA8553C83" },
						{ Image5, "C1F02AE3D0C9BD858FEBBA5B3B5492B128B220318D49E21741AB5A0567DB9E05" }
					};
			}
		}
	}
}
