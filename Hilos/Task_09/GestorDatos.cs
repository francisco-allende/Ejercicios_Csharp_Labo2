using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_09
{
    internal class GestorDatos
    {
        public static string TraerRegistros()
        {

            Thread.Sleep(10000);
            return "La cantidad de registros es 2000";
        }

        //Recibe el cancelation token en caso de ser cancelada la operacion
        public static async Task<string> TraerRegistros2(CancellationToken cancelToken)
        {
            //Este run lleva async dentro por el delay que lleva await, ya que siempre que tenga un
            //await si o si tengo un async. Usando sleep no es necesario.
            //No quiero que cuelge esta task, sino que espere posta los 3 segundos
            string informacion = await Task.Run(async () =>
                                     { 
                                         await Task.Delay(3000); //igual q sleep pero task, por eso usa await

                                         //Tira una excepcion y corta todo
                                         cancelToken.ThrowIfCancellationRequested();

                                         //Esto es lo mismo a lo del throw if cancellation requested
                                         //if (cancelToken.IsCancellationRequested)
                                         //{

                                         //    throw new TaskCanceledException("Proceso cancelador por usuario");
                                         //}

                                         await Task.Delay(2000);

                                         return "La cantidad de registros es 2000";

                                     });

            return informacion;
        }

    }
}
