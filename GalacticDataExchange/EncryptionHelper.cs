using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace GalacticDataExchange
{
    internal class EncryptionHelper
    {
        /// <summary>
        /// Computes the SHA256 hash of a given string input.
        /// </summary>
        /// <param name="input">the string input</param>
        /// <returns>a hexadecimal string</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ComputeSHA256Hash(string input)
        {
            // Check if input is null or empty
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input));

            // Create a new instance of the SHA256 class
            using SHA256 sha256 = SHA256.Create();

            // Convert the input string to a byte array
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Compute the hash of the input byte array
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            // Convert the hash byte array to a hexadecimal string
            return Convert.ToHexStringLower(hashBytes);

        }

        /// <summary>
        /// Generates an encryption key for the DataArtifactInputModel based on its name and timestamp.
        /// </summary>
        /// <param name="dataArtifactInputModel">The InputModel that requires an EncryptionKey</param>
        /// <returns>The InputModel</returns>
        public static DataArtifactInputModel EncryptionKeyToDataArtifact(DataArtifactInputModel dataArtifactInputModel)
        {
            // Assign string to be hashed
            string dataToHash = $"{dataArtifactInputModel.Name}-{dataArtifactInputModel.TimeStamp}";

            // Compute the SHA256 hash of the string
            dataArtifactInputModel.EncryptionKey = ComputeSHA256Hash(dataToHash);

            // Return the DataArtifactInputModel with the generated EncryptionKey
            return dataArtifactInputModel;

        }
    }
}
