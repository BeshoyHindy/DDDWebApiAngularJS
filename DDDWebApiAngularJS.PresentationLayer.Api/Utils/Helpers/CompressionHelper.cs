﻿using Ionic.Zlib;
using System.IO;

namespace DDDWebApiAngularJS.PresentationLayer.Api.Utils.Helpers
{
    public class CompressionHelper
    {
        public static byte[] DeflateByte(byte[] str)
        {
            if (str == null)
                return null;

            using (var output = new MemoryStream())
            {
                using (var compressor = new DeflateStream(
                    output, CompressionMode.Compress,
                    CompressionLevel.BestSpeed))
                {
                    compressor.Write(str, 0, str.Length);
                }

                return output.ToArray();
            }
        }
    }
}
