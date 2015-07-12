namespace CohesionAndCoupling
{
    using System;

    internal static class FileUtils
    {
        public static string GetFileExtension(string fullFileName)
        {
            if (string.IsNullOrEmpty(fullFileName))
            {
                throw new ArgumentNullException("File name is null or empty!");
            }

            int indexOfLastDot = fullFileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return "";
            }

            string extension = fullFileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fullFileName)
        {
            if (string.IsNullOrEmpty(fullFileName))
            {
                throw new ArgumentNullException("File name is null or empty!");
            }

            int indexOfLastDot = fullFileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fullFileName;
            }

            string extension = fullFileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
