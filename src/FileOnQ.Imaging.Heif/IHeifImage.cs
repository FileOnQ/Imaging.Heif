using System;

namespace FileOnQ.Imaging.Heif
{
	/// <summary>
	/// A High Efficiency Image Format (HEIF) image.
	/// </summary>
	public interface IHeifImage : IDisposable
	{
		/// <summary>
		/// Gets the embedded thumbnail if exists.
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IImage"/> which
		/// contains the embedded thumbnail.
		/// </returns>
		/// <exception cref="HeifException">
		/// If an error occurs during retrieving the embedded thumbnail, an exception will be
		/// thrown which contains a <see cref="HeifException.Error" /> explaining the problem.
		/// </exception>
		IImage Thumbnail();
		
		/// <summary>
		/// Gets the primary image.
		/// </summary>
		/// <returns>
		/// An instance of <see cref="IImage"/> which
		/// contains the primary image.
		/// </returns>
		/// <exception cref="HeifException">
		/// If an error occurs during retrieving the image, an exception will be
		/// thrown which contains a <see cref="HeifException.Error" /> explaining the problem.
		/// </exception>
		IImage PrimaryImage();
	}
}
