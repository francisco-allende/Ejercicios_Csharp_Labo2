using System;
using System.Collections.Generic;
using System.IO;

namespace Biblio
{
    public class Archivo
    {
        static string rutaArchivo;

        //Esto esta buenisimo. Atributo con la ruta. Al ser statico, es lo 1ero q obtengo
        static Archivo()
        {
            rutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        
        public static void EscribirConExplicacion()
        {
            //Utilizo el poderso método GetFolderPath para tener una ruta absoluta y no una relativa.
            string rutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //Con esto se para en la ruta donde se guarda mi .exe, donde hago esto
            string rutaProyecto = AppDomain.CurrentDomain.BaseDirectory;

            //el / es un caracter especial que indica path. Uso el @ para escapar de que me lo tome como una bara normal
            string nombreArchivo = @"/Labo_Files.txt";

            string fileData = rutaArchivo + nombreArchivo;

            //Dos formas de instanciar este file
            //StreamWriter sw = new StreamWriter(rutaArchivo + nombreArchivo);
            StreamWriter sw = new StreamWriter(fileData);

            sw.WriteLine("Hola mundo");
            sw.WriteLine("Mi primer file en C#!!!");
            sw.Close();
        }

        //Con using. Uso este ya que me permite librerar memoria olvidandome del close, cierra solo!!
        public static void Escribir()
        {
            string rutaArchivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreArchivo = @"/Labo_Files.txt";
            string filePathAndName = rutaArchivo + nombreArchivo;

            try
            {
                using (StreamWriter sw = new StreamWriter(filePathAndName))
                {
                    sw.WriteLine("Creo archivo que se cierra solo");
                    sw.WriteLine("Gracias using!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error para abrir el archivo");
            }
        }

        public static void EscribirEnUnArchivoYaExistenteSinPisarlo()
        {
            string rutaArchivo = Archivo.rutaArchivo;
            rutaArchivo += @"/Labo_Files.txt";
            bool append = false; //le digo que si, que ya existe. No me lo pises, escribi a continuacion

            try
            {
                using (StreamWriter sw = new StreamWriter(rutaArchivo, append))
                {
                    sw.WriteLine("Escribo sin pisar el file exsitente");
                    sw.WriteLine("Con bool append");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error para abrir el archivo " + ex);
            }
        }

        public static string Leer()
        {
            string rutaArchivo = Archivo.rutaArchivo;
            rutaArchivo += @"/Labo_Files.txt";
            string retorno = "";

            try
            {
                using(StreamReader sr = new StreamReader(rutaArchivo))
                {
                    retorno = $"{sr.ReadToEnd()}\n";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error para abrir el archivo " + ex);
            }

            return retorno;
        }

        //Ejemplo de C#corner.com de las properties mas comunes de esta clase Environment.
        public static void UsandoPropertiesDelSistema()
        {
            List<string> ar = new List<string>();

            ar.Add("OSVersion: " + Environment.OSVersion.ToString()); //Operating system Details  
            ar.Add("OSVersion Platform: " + Environment.OSVersion.Platform.ToString()); //Operating system Platform Details  
            ar.Add("OS Version: " + Environment.OSVersion.Version.ToString()); //Operating system version Details  
            ar.Add("NewLine :" + Environment.NewLine.ToString()); //string will spilt into New line   
            ar.Add("MachineName :" + Environment.MachineName.ToString());//Machine Name of the current computer  
            ar.Add("Is64BitProcess : " + Environment.Is64BitProcess.ToString());//Checks whether the OS has 64 bit process  
            ar.Add("UserDomainName: " + Environment.UserDomainName.ToString());//gets the network domain name which is currently associated with current User Computer  
            ar.Add("UserName :  " + Environment.UserName.ToString());//gets the username of person who currenlty logged on  the windows operating Sytem system  
            ar.Add("WorkingSet :" + Environment.WorkingSet.ToString());//gets the Amount of physical memory mapped to the process contex   
            ar.Add("CurrentDirectory: " + Environment.CurrentDirectory.ToString());//gets the full path of current working directory.  
            ar.Add("HasShutdownStarted:" + Environment.HasShutdownStarted.ToString());//Gets the Value whether  CLR is shutting down  
            ar.Add("SystemPageSize:" + Environment.SystemPageSize.ToString());//gets the Amount of memory for an operating system's Page file.   


            Console.WriteLine(Environment.NewLine + "Environment Class Details" + Environment.NewLine + "---------------------------");
            foreach (var item in ar)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
