using System.IO;

namespace CJia.MobileMedicalDoctor.Serialization
{
	/// <summary>
	/// Interface to implement on a compressor class which can be used to compress/decompress the resulting byte array of the Fast serializer. 
	/// </summary>
    public interface IByteCompressor
	{
		/// <summary>
		/// Compresses the specified serialized data.
		/// </summary>
		/// <param name="serializedData">The serialized data.</param>
		/// <returns>The  passed in serialized data in compressed form</returns>
		byte[] Compress(byte[] serializedData);

		/// <summary>
		/// Decompresses the specified compressed data.
		/// </summary>
		/// <param name="compressedData">The compressed data.</param>
		/// <returns>The  passed in de-serialized data in compressed form</returns>
		byte[] Decompress(byte[] compressedData);
	}

    /// <summary>
    /// Interface to implement on specialized compressor classes to compress a passed-in memory stream
    /// </summary>
    public interface IMemoryStreamByteCompressor : IByteCompressor
    {
        /// <summary>
        /// Compresses the specified memory stream.
        /// </summary>
        /// <param name="memoryStream">The memory stream.</param>
        /// <returns>the data in the memory stream in compressed format.</returns>
        byte[] Compress(MemoryStream memoryStream);
    }
}