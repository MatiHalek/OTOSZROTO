﻿using api.Interfaces;
using System.Text;
using System;

namespace api.Helpers
{
    public static class Utils
    {
        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }

        public static async Task<string> UploadImages(List<IFormFile> files, string directory)
        {
            if (files == null || files.Count == 0)
                return "";

            string randomImageToken = GenerateRandomString(15);

            var uploads = Path.Combine(Directory.GetCurrentDirectory(), $"Uploads/{directory}/car_{randomImageToken}");

            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            for (int i = 0; i < files.Count; i++)
            {
                string fileName = $"{randomImageToken}_{i}{Path.GetExtension(files[i].FileName)}";

                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await files[i].CopyToAsync(stream);
                }

            }
            return randomImageToken;
        }

        public static byte[] CombineChunks(List<byte[]> chunks)
        {
            int totalLength = chunks.Sum(chunk => chunk.Length);
            byte[] combinedBytes = new byte[totalLength];

            int offset = 0;
            foreach (var chunk in chunks)
            {
                System.Buffer.BlockCopy(chunk, 0, combinedBytes, offset, chunk.Length);
                offset += chunk.Length;
            }

            return combinedBytes;
        }
    }
}
