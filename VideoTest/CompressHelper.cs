using System;
using System.IO;
using SevenZipNET;

namespace VideoTest
{
    class CompressHelper
    {
        /// <summary>
        /// Compress folder.
        /// </summary>
        /// <param name="sourceFolderPath">Source folder path</param>
        /// <param name="saveFilePath">sava file path</param>
        /// <param name="compressionLevel">compress level</param>
        public static void CompressFolder(string sourceFolderPath, string saveFilePath,
            CompressionLevel compressionLevel)
        {
            var zipCompressor = new SevenZipCompressor(saveFilePath);
            zipCompressor.CompressDirectory(sourceFolderPath, compressionLevel);
        }

        /// <summary>
        /// Decompress.
        /// </summary>
        /// <param name="sourcePath">decompress source path.</param>
        /// <param name="destinionPath">destinion path</param>
        public static void DeCompress(string sourcePath, string destinionPath)
        {
            if (!File.Exists(sourcePath))
            {
                throw new ArgumentException($"Can't find decompress source path {sourcePath}");
            }

            var ext = new SevenZipExtractor(sourcePath);
            ext.ExtractAll(destinionPath, true);
        }
    }
}
