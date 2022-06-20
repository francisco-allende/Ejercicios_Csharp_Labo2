using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Esta bien que falte el 7, estaba duplicado
namespace Task_07
{
    internal class GestorDatos
    {

        public static string TraerRegistros()
        {
            return "La cantidad de registros es 2000";
        }


        /* Gracias al async await puedo mover este form auxiliar, interactuar con el
        * mientras me trae los datos sin que cuelgue. Si yo no uso esto, cuelga el form
        * hasta que carga la BBDD y se queda medio en gris sin posibilidad de interactuar
        * El async va a esperar al await, pero a la vez permite que lo demas funcione sin colgar
        * "Te banco a que termines pero mientras te dejo hacer cosas que no te involucren"
        * 
        * El resultado de una task viene como "Task<TipoDato>" por eso la retorno asi
        */
        public static async Task<string> TraerRegistros2Async() // HILO 1 ESPERAME AL 2 PERO NO CUELGUES
        {
            /*Simulo que voy a buscar datos a una BBDD, por ende, lo hago en otro hilo
            * El await nos dice que NO vamos a seguir adelante hasta que esta tarea no termine
            * Hasta no leer todos los datos de la BBDD, esta tarea no se termina. Await.
            * Por ende, informacion se termina de cargar cuando termine la task
            * La diferencia con el wait, es que este metodo es esperado por otro. En wait no, era en el main
            * Lo espero en el sentido de que no cuelgue nada.
            */

                    //Info es de HILO 1, por eso es clave este await 
            string informacion = await Task.Run(() => //HILO 2
                                            {
                                                Thread.Sleep(10000); // SIMULO QUE VA A LA BASE
                                            return "La cantidad de registros es 2000";
                                            });
             
            //La validacion y el retorno lo hare luego de haber terminado mi task, gracias al await.
            if(informacion.Length < 0)
            {
                throw new Exception("info vacia");
            }

            //Retorno un Task<string>
            return informacion;
        }

    }
}
