using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering.VirtualTexturing;
using static UnityEditor.PlayerSettings;


public class Ejercicios : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ej1Battle();
       //Debug.Log(ej12(ej12b(5)));

        ej11test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loops()
    {
        string[] enemigos = { "Slime", "Goblin", "Orco" };
        foreach (string enemigo in enemigos)
        {
            Debug.Log("Enemigo: " + enemigo);
        }

        List<string> items = new List<string>();
        items.Add("Espada");
        items.Add("Poción");
        

        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log("Item en mochila: " + items[i]);
        }
    }

    public void ej1()
    {
        //Ejercicio 1

        //Crear un bucle for que muestre los números del 1 al 20.


        for (int i = 1; i <= 20; i++)
        {
            Debug.Log(i);
        }
    }

    public void ej2()
    {
       // Ejercicio 2
       //
       // Crear un array con 5 nombres y recorrerlo con un foreach para mostrarlos.


        string[] names = { "Pedro", "Juan", "Maria", "Luis", "Ana" };
       

        foreach (string name in names)
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
        for (int i = 1; i <= 10; i++)
        {
            numbers.Add(i);
        }

        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                Debug.Log("Número par: " + number);
            }
        }
    }


    public void ej4()
    {
        // Ejercicio 4
        //
        //  Pedir(por código) que se guarden 3 notas de un alumno en un array.
        //  Calcular el promedio usando un for.

        int total = 0;
        int promedio = 0;
        int[] notes = { 4, 6, 10 };

        for (int i = 0; i < notes.Length; i++)
        {
            total += notes[i];
        }

        promedio = total / notes.Length;
        Debug.Log($"Promedio:{promedio}");

    }


    public void ej5()
    {
        // Ejercicio 5

        //Simular un inventario con una lista de strings(espada, escudo, poción).
        //Recorrer la lista e imprimir:
        //
        //“Equipado” si el ítem es espada o escudo.
        //
        //“Consumible” si es poción.

        List<string> inventory = new List<string> { "espada", "escudo", "pocion" };

        foreach (var item in inventory)
        {
            switch (item)
            {
                case "espada":
                case "escudo":
                    Debug.Log("Equipado");
                    break;
                case "pocion":
                    Debug.Log("Consumible");
                    break;
            }
        }
    }

    public void ej6()
    {
        // Ejercicio 6 – Contador simple
        //
        // Usar un while para mostrar los números del 1 al 10.

        int i = 0;

        while(i <= 10)
        {
            Debug.Log(i);
            i++;
        }
    }

    public void ej7()
    {
        //Ejercicio 7 – Sumar números hasta un límite

        //Crear un while que vaya sumando números empezando en 1 hasta llegar a un total mayor o igual a 100.
        //Imprimir el total y cuántos números sumaste.

        int suma = 0;
        int randomNumber;

        while(suma <= 100)
        {
            randomNumber = UnityEngine.Random.Range(1, 101);
            suma += randomNumber;
            Debug.Log($"sume el numero:{randomNumber}");
        }

        Debug.Log($"La suma total es de {suma}");
    }

    public void ej8()
    {
        // Ejercicio 8 – Buscar en un array
        //
        // Tener un array con varios nombres. Usar un while para buscar un nombre específico(por ejemplo, "Juan") y cortar el bucle cuando lo encuentre.

        string[] names = { "Juan", "Carlos", "Pepe", "Lucas" };

        int i = 0;

        while (names[i] != "Lucas")
        {
            i++;
        }

        Debug.Log($"Nombre encontrado en la posicion: {i}");
    }

    public void ej9()
    {
        //Ejercicio 9 – Restar vidas

        //Simular un jugador con 5 vidas.Mientras tenga vidas, mostrar "Te quedan X vidas".
        //Cuando llegue a 0, mostrar "Game Over".

        int lifes = 5;

        while(lifes > 0)
        {

            Debug.Log($"Te quedan {lifes} vidas");
            lifes--;
           
        }

        Debug.Log("Game Over");

    }

    public void ej10()
    {
        //Inventario con lista

        //Tener una lista de ítems("Espada", "Poción", "Escudo"). Usar un while para recorrer la lista y mostrar cada ítem.

        List<string> items = new List<string> { "Espada", "Pocion", "Escudo" };

        int i = 0;

        while(i < items.Count)
        {
            Debug.Log(items[i]);
            i++;
        }
    }

    public void ej11()
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
                else if(j == enemiesPerWave - 1)
                {
                    Debug.Log("Mini jefe de la oleada");
                }
            }

            Debug.Log("Oleada " + (i + 1) + " completada");
        }


        


    }

    public void ej11test()
    {
        int oleadas = 3; // cantidad de oleadas
        string[] enemies = { "E1", "E2", "E3", "E4", "E5" };
        int oleadaActual = 0;

        while (oleadaActual < oleadas) // 0,1,2 -> tres oleadas
        {
            int k = 0; // reset por oleada

            while (k < enemies.Length)
            {
                bool esUltimoEnemigo = (k == enemies.Length - 1);
                bool esUltimaOleada = (oleadaActual == oleadas - 1);

                if (esUltimoEnemigo && esUltimaOleada)
                {
                    Debug.Log("Jefe Final");
                }
                else if (esUltimoEnemigo)
                {
                    Debug.Log("Mini Jefe de la oleada");
                }
                else
                {
                    Debug.Log("Enemigo: " + enemies[k]);
                }

                k++;
            }

            Debug.Log("Oleada " + (oleadaActual + 1) + " completada");
            oleadaActual++;
        }
    }

    public int ej12(List<int> items)
    {
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


        int coins = UnityEngine.Random.Range(500, 1001);
        int itemsBought = 0;

        Debug.Log($"Tengo {coins} monedas");

        for (int i = 0; i < items.Count; i++)
        {
            if(coins >= items[i])
            {
                itemsBought++;
                coins -= items[i];
                

                Debug.Log($"Compre el item {items[i]}");
                Debug.Log($"Me quedaron {coins} monedas");
            }
            else
            {
                Debug.Log($"No alcanza para el item {items[i]}");
            }
        }

        if(itemsBought >= 2)
        {
            Debug.Log("Cliente satisfecho");
        }
        else
        {
            Debug.Log("Cliente decepcionado");
        }

        return itemsBought;

    }

    public List<int> ej12b(int itemQuantity)
    {
        List<int> items = new List<int>();
        for (int i = 0; i < itemQuantity; i++)
        {
            int randomItem = UnityEngine.Random.Range(100, 1001);
            items.Add(randomItem);
        }
        return items;
    }

    int playerLife = 100;
    int enemyLife = 50;

    int playerDamage = 10;
    int enemyDamage = 7;

    int turnos = 0;

    public void ej1Battle()
    {
        while(playerLife > 0 && enemyLife > 0)
        {
            enemyLife -= playerDamage;

            if(enemyLife <= 0)
            {
                Debug.Log("Ganaste");
                break;
            }

            playerLife -= enemyDamage;

            if(playerLife <= 0)
            {
                Debug.Log("Perdiste");
                break;
            }

            turnos++;

            Debug.Log("Turno: " + turnos);
            Debug.Log("Vida del jugador: " + playerLife);
            Debug.Log("Vida del enemigo: " + enemyLife);
        }
    }
}
