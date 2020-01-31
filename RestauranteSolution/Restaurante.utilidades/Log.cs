using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.utilidades
{
    public class Log
    {
        public static void GeraLog(string message)
        {
            string caminho = ConfigurationManager.AppSettings.Get("auditoria.log");
            string arquivoCaminho = string.Format(@"{0}\{1}.txt", caminho, DateTime.Now.ToShortDateString().Replace("/", ""));

            DirectoryInfo diretorio = new DirectoryInfo(caminho);
            if (!diretorio.Exists)
                diretorio.Create();

            StreamWriter fluxo = new StreamWriter(arquivoCaminho, true);
            fluxo.WriteLine(string.Format("App : {0} - Horário : {1} ", System.AppDomain.CurrentDomain.FriendlyName, DateTime.Now.ToString("hh:mm:ss")));
            fluxo.WriteLine(message);
            fluxo.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            fluxo.Close();
        }
        public static void GeraLog(Exception e)
        {
            string caminho = ConfigurationManager.AppSettings.Get("auditoria.log");
            string arquivoCaminho = string.Format(@"{0}\{1}.txt", caminho, DateTime.Now.ToShortDateString().Replace("/", ""));

            DirectoryInfo diretorio = new DirectoryInfo(caminho);
            if (!diretorio.Exists)
                diretorio.Create();

            StreamWriter fluxo = new StreamWriter(arquivoCaminho, true);
            fluxo.WriteLine(string.Format("App : {0} - Horário : {1} ", System.AppDomain.CurrentDomain.FriendlyName, DateTime.Now.ToString("hh:mm:ss")));
            fluxo.WriteLine(e.Message);
            fluxo.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            fluxo.Close();
        }



    }
}
