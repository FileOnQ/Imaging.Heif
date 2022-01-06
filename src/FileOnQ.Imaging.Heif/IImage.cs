using System;
using System.IO;

namespace FileOnQ.Imaging.Heif
{
	public interface IImage : IDisposable
	{
		/// <summary>
		/// Saves the current image to a specified path.
		/// </summary>
		/// <param name="filename">
		/// The file path to save the image to.
		/// </param>
		/// <param name="quality">
		/// The quailty of the image.
		/// </param>
		/// <exception cref="HeifException">
		/// Thrown if a general exception happens during save.
		/// </exception>
		void Write(string filename, int quality = 90);

		/// <summary>
		/// Get the byte[] of the current image.
		/// </summary>
		/// <param name="quality">
		/// The quailty of the image.
		/// </param>
		/// <returns>
		/// The bytes of the image.
		/// </returns>
		/// <exception cref="HeifException">
		/// Thrown if a general exception happens during save.
		/// </exception>
		byte[] ToArray(int quality = 90);

		/// <summary>
		/// Get a readyonly byte span of the current image.
		/// </summary>
		/// <param name="quality">
		/// The quailty of the image.
		/// </param>
		/// <returns>
		/// The readonly byte span of the image.
		/// </returns>
		ReadOnlySpan<byte> ToSpan(int quality = 90);

		/// <summary>
		/// Get the stream of the current image.
		/// </summary>
		/// <param name="quality">
		/// The quailty of the image.
		/// </param>
		/// <returns>
		/// The stream of the image.
		/// </returns>
		Stream ToStream(int quality = 90);
	}
}
