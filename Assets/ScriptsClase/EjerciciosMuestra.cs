using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EjerciciosMuestra : MonoBehaviour
{
  // string[] enemigos = { "Slime", "Goblin", "Orco" };
  //
  // List<string> items = new List<string> { "Espada", "Pocion", "Escudo" };
  //
  // int i = 0;

    private void Start()
    {

        //  items.Add("Arco");
        //  items.Insert(1, "Daga");
        //  items.Remove("Pocion");
        //
        //  foreach (string enemigo in enemigos)
        //  {
        //      Debug.Log("Enemigo: " + enemigo);
        //  }
        //
        //
        //  while(i < enemigos.Length)
        //  {
        //      Debug.Log("Enemigo: " + enemigos[i]);
        //      i++;
        //  }
        //
        //  do
        //  {
        //      Debug.Log("Enemigo: " + enemigos[i]);
        //      i++;
        //  } while (i < enemigos.Length);
        //
        //
        //  for (int j = 0; j < enemigos.Length; j++)
        //  {
        //      Debug.Log("Enemigo: " + enemigos[j]);
        //  }

        //  ej1();
        //ej2();

        //ej3();

        //ej4();

       // Debug.Log(ej12B(ej12(5)));
    }
    
       public void ej1()
       {
        //Ejercicio 1

        //Crear un bucle for que muestre los números del 1 al 20.

        

        for (int i = 0; i < 20; i++)
        {
            Debug.Log(i + 1);
        }

       }


    public void ej2()
    {
        // Ejercicio 2
        //
        // Crear un array con 5 nombres y recorrerlo con un foreach para mostrarlos.

        string[] names = { "Pedro", "Juan", "Maria", "Luis", "Ana" };

        foreach(var name in names)
        {
            Debug.Log("Nombre: " + name);
        }

    }


    public void ej3()
    {
        //  Ejercicio 3
        //
        //  Crear una lista de enteros.Agregarle los números del 1 al 10 con Add().
        //  Luego usar un bucle para mostrar solo los pares.

        List<int> numbers = new List<int>();
        int j = 0;
        while(j <= 10)
        {
            numbers.Add(j);         
            j++;
        }

        foreach (var number in numbers)
        {
        
            if (number % 2 == 0)
                
            {
               Debug.Log("Numero par: " + number);
            }
        }


    }


    public void ej4()
    {
        // Ejercicio 4
        //
        //  Pedir(por código) que se guarden 3 notas de un alumno en un array.
        //  Calcular el promedio usando un for.

        int[] notas = { 8, 9, 10 };
        int total = 0;
        float promedio = 0;

        for (int i = 0; i < notas.Length; i++)
        {
            total += notas[i];
        }

        promedio = total / notas.Length;

       // Debug.Log(promedio);
    }


    //Recuerden poner el script en un objeto vacío en la escena.
    public void ej5()
    {
        // Ejercicio 5

        //Simular un inventario con una lista de strings(espada, escudo, poción).
        //Recorrer la lista e imprimir:
        //
        //“Equipado” si el ítem es espada o escudo.
        //
        //“Consumible” si es poción.

        List<string> inventario = new List<string> { "Espada", "Escudo", "Pocion" };
        foreach (var item in inventario)
        {
            switch (item)
            {
                case "Espada":
                case "Escudo":
                    Debug.Log("Equipado");
                    break;
                case "Pocion":
                    Debug.Log("Consumible");
                    break;
            }
        }
    }

    public void ej6()
    {
        //Ejercicio 6 – Sumar números hasta un límite

        //Crear un while que vaya sumando números random empezando en 1 hasta llegar a un total mayor o igual a 100.
        //Imprimir el total y cuántos números sumaste.
    }

    public void ej7()
    {
        // Ejercicio 7 – Buscar en un array
        //
        // Tener un array con varios nombres. Usar un while para buscar un nombre específico(por ejemplo, "Juan") y cortar el bucle cuando lo encuentre.

        string[] names = { "Juan", "Carlos", "Pepe", "Lucas" };

        int i = 0;

        while(names[i] != "Lucas")
        {
            i++;
        }
    }


    public void ej8()
    {
        //Ejercicio 8 – Restar vidas

        //Simular un jugador con 5 vidas.Mientras tenga vidas, mostrar "Te quedan X vidas".
        //Cuando llegue a 0, mostrar "Game Over".
    }

    public void ej9()
    {
        //Inventario con lista

        //Tener una lista de ítems("Espada", "Poción", "Escudo"). Usar un while para recorrer la lista y mostrar cada ítem.
    }

    public void ej10()
    {
        // Ejercicio 11 – Oleadas de enemigos
        //
        // Enunciado:
        // Un nivel tiene 3 oleadas de enemigos.
        // 
        // Cada oleada trae 5 enemigos.
        // 
        // Si el enemigo es el número 5 de la oleada → "Mini jefe de la oleada".
        // 
        // Si es la última oleada y el último enemigo → "¡Jefe final!".
        // 
        // Al terminar cada oleada → "Oleada X completada".


        int oleadas = 3;
        int enemiesPerWave = 5;

        for (int i = 0; i < oleadas; i++)
        {
            for (int j = 0; j < enemiesPerWave; j++)
            {
                if(j == enemiesPerWave - 1 && i == oleadas - 1)
                {
                    Debug.Log("¡Jefe final!");
                }
                else if (j == enemiesPerWave - 1)
                {
                    Debug.Log("Mini jefe de la oleada");
                }
               
            }

            Debug.Log("Oleada " + i + " completada");
        }
    }


    //ejercicio Bonus - recuerden siempre crear el metodo, lean bien el enunciado.

    // Ejercicio 12 – Sistema de tienda con compra múltiple
    //
    // Enunciado:
    // Un jugador quiere comprar varios ítems de una tienda.
    //
    // Tiene monedas = entre 500 y 1000 , mostrar cantidad de monedas al inicio.
    //
    // Generar un metodo que reciba por parametro el numero de items y devuelva la lista llena de items con valores entre 100 y 1000.
    // Generar un metodo que reciba por parametro la lista de items y devuelva el numero de items que el jugador ha comprado.
    // 
    // Usar un for para recorrer cada ítem.
    //
    // Si el jugador tiene suficiente dinero, compra el ítem y se descuentan monedas.
    //
    // Si no, mostrar "No alcanza para el ítem X".
    //
    // Si al final el jugador compró al menos 2 ítems → "Cliente satisfecho".
    //
    // Si no → "Cliente decepcionado".


   // int coins = Random.Range(500, 1001);
   // 
   //
   //
   // public int ej12B(List<int> items)
   // {
   //
   //     int itembought = 0;
   //
   //     Debug.Log(coins);
   //
   //     for (int i = 0; i < items.Count; i++)
   //     {
   //         if (coins >= items[i])
   //         {
   //             coins -= items[i];
   //             itembought++;
   //         }
   //         else
   //         {
   //             Debug.Log("No alcanza para el item " + items[i]);
   //         }
   //     }
   //
   //
   //     if(itembought >= 2)
   //     {
   //         Debug.Log("Cliente satisfecho");
   //     }
   //     else
   //     {
   //         Debug.Log("Cliente decepcionado");
   //     }
   //     
   //
   //     return itembought;
   // }
   //
   // public List<int> ej12(int items)
   // {
   //     List<int> itemPrices = new List<int>();
   //     for (int i = 0; i < items; i++)
   //     {
   //         itemPrices.Add(Random.Range(100, 1001));
   //     }
   //     return itemPrices;
   // }
}
