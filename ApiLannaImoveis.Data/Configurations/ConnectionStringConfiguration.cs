using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApiLannaImoveis.Data.Configurations
{
    public static class ConnectionStringConfiguration
    {
        private static readonly string AppNome = "LannaImoveis.Application";
        private static readonly string AppCaminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppNome);

        public static string ObterConnectionString()
        {
            EnsureFolderExists(AppCaminho);
            return $"Data Source={AppCaminho}\\lanna_imoveis_db.sqlite";
        }

        private static string EnsureFolderExists(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }
    }
}
