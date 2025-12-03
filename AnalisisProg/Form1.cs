using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalisisProg
{

    public partial class Form1 : Form
    { // Se declaran las variables (crea la referencia) globales a nivel de clase para que todos las puedan utilizar.
        private const long Limite_Visualizacion = 1000000; // Límite para mostrar en lista
        long[] arregloNumeros; // Arreglo principal para guardar los números generados
        long[] arregloOrdenado; // Arreglo para guardar los números ordenados
        public Form1()
        {
            InitializeComponent();
        }

        // --- BOTÓN DE GENERACIÓN DE DATOS ---
        private void btnGenerarNumeros_Click(object sender, EventArgs e)
        {
            try
            {
                // Si no se puede convertir a un numero, se muestra un mensaje y se sale del método.
                // si se puede convertir, el valor se guarda en la variable cant.
                if (!long.TryParse(tbCantidad.Text, out long cant))
                {
                    MessageBox.Show("Por favor ingresa un número válido.");
                    return;
                }

                // Se construyen(instancian)`new` y se inicializan `=` los objetos necesarios para la generación de números aleatorios y la medición de tiempo.
                arregloNumeros = new long[cant];// objeto arreglo para guardar los numeros generados
                // Se declara, se instancia y se inicializa.
                Random rdn = new Random();// Objeto para números aleatorios
                Stopwatch sw = new Stopwatch(); // Objeto para medir el tiempo

                lblTiempoInicio.Text = "Inicio Gen: " + DateTime.Now.ToString("hh:mm:ss.fff"); // Convierte el tiempo a texto legible por el usuario
                sw.Start(); // Inicia la medición de tiempo
                // El flujo seria el siguiente: Se crea la variable i, se evalua la condicion, si es verdadero que i < cant, se ejecuta el bloque de codigo, luego se incrementa la posicion de i en 1 y se vuelve a evaluar la condicion.
                for (long i = 0; i < cant; i = i + 1) // Inicio i= 0, condicion i < cant, y incremento i++.
                { // El .Next es el accionador del rdn (random). Sin este el rdn no haria nada.
                    arregloNumeros[i] = rdn.Next(1, 1000000); // Si genera mas de un millón, puede repetirse
                }
                sw.Stop(); // Detiene la medición de tiempo

                lblTiempoFin.Text = "Fin Generacion: " + DateTime.Now.ToString("hh:mm:ss.fff"); // Convierte el tiempo a un formato legible por el usuario
                lblDuracion.Text = $"Duración: {sw.ElapsedMilliseconds} ms"; // Que es elapsedMilliseconds? Es la propiedad que devuelve el tiempo transcurrido en milisegundos.

                // Limpiamos la segunda lista para evitar confusiones
                lstDatos2.DataSource = null;

                // Aqui se crea una ventana emergente si la cantidad es muy grande y se le pregunta al usuario si desea mostrar los datos.
                if (cant <= Limite_Visualizacion)
                {
                    lstDatos.DataSource = null; // Limpiamos la lista antes de asignar nuevos datos
                    lstDatos.DataSource = arregloNumeros; // Asignamos el arreglo a la lista para mostrar los números
                }
                else
                {
                    // Si la cantidad es mayor al limite, preguntamos al usario.
                    DialogResult respuesta = MessageBox.Show(
                        $"Has generado {cant:N0} registros. Mostrarlos en la lista podría congelar la aplicación.\n\n¿Deseas mostrarlos?",
                        "Advertencia",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        lstDatos.DataSource = null; // Se limpia la lista.
                        lstDatos.DataSource = arregloNumeros; // Se asignan los datos a la lista.
                    }
                    else // Si el usuario dice que NO
                    {
                        lstDatos.DataSource = null; // Se limpia la lista.
                        MessageBox.Show("Datos generados en memoria, pero ocultos.");
                    }
                }
            }
            catch (Exception ex) // Captura cualquier error inesperado
            {
                MessageBox.Show("Error: " + ex.Message); // Muestra el mensaje de error
            }
        }
        




        // Método recursivo principal de QuickSort
        private void QuickSort(long[] arr, long low, long high) // arr: arreglo, low: índice bajo, high: índice alto
        {
            if (low < high)
            {
                // Primero se obtiene el índice de partición
                long pi = Partition(arr, low, high);
                // Despues se ordenan recursivamente los elementos antes y después de la partición
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        // Lógica de partición (Divide y Vencerás)
        private long Partition(long[] arr, long low, long high)
        {
            long pivot = arr[high]; // El pivote va a adquirir el valor del ultimo elemento del array
            long i = (low - 1);// La posicion de i es el indice mas pequeño iniciando en -1

            // El flujo seria el siguiente: Se crea la variable j, se evalua la condicion, si es verdadero que j < high, se ejecuta el bloque de codigo, luego se incrementa la posicion de j en 1 y se vuelve a evaluar la condicion.
            for (long j = low; j < high; j++)
            {

                // Si el elemento actual es menor que el pivote 
                if (arr[j] < pivot)
                {
                    i++;// Se incrementa el indice del elemento mas pequeño
                    Swap(arr, i, j);// Se realiza el (Swap)
                }
            }
            // Intercambio final para colocar el pivote en su lugar correcto
            Swap (arr, i + 1, high);
            return i + 1;
        }
        // Metood swap para intercambiar dos elementos en el arreglo
        private void Swap(long[] arr, long a, long b)
        {
            long temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        // --- QUICK SORT (O(n log n)) ---
        private async void btnQuickSort_Click_1(object sender, EventArgs e)
        {
            if (arregloNumeros == null || arregloNumeros.Length == 0) return;

            btnQuickSort.Enabled = false;
            lblTiempoInicio.Text = "Iniciando QuickSort...";

            // Copiamos los números al arreglo que usa la Búsqueda Binaria
            arregloOrdenado = (long[])arregloNumeros.Clone();
           
            Stopwatch sw = new Stopwatch();// Se declara, se instancia y se inicializa otro Stopwatch.
            sw.Start();

            // Procesamos en segundo plano para no congelar la pantalla
            await Task.Run(() =>
            {
                // Ordenamos LA COPIA (arregloOrdenado) en lugar del original
                // Se coloca el 0 para que el metodo QuickSort sepa desde donde ordenar y hasta donde que seria arregloOrdenado.Length -1 pq si el arrelgo tiene 5 elementos te dice la longitud del arreglo -1 pq siempre inicia en 0 hasta 4 osea la longitud del arreglo que es 5 -1 osea 4.
                QuickSort(arregloOrdenado, 0, arregloOrdenado.Length - 1);
            });

            sw.Stop();
            lblTiempoFin.Text = "Fin QuickSort";
            lblDuracion.Text = $"Duración: {sw.ElapsedMilliseconds} ms";
            btnQuickSort.Enabled = true;

            // Mostramos el resultado (solo si son pocos datos)
            if (arregloOrdenado.Length <= Limite_Visualizacion)
            {
                lstDatos2.DataSource = null;
                lstDatos2.DataSource = arregloOrdenado;
            }
            else
            {
                // Si la cantidad es mayor al limite, preguntamos al usario.
                DialogResult respuesta = MessageBox.Show(
                    $"Vas a ordenar los numeros. Mostrarlos en la lista podría congelar la aplicación.\n\n¿Deseas mostrarlos?",
                    "Advertencia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    lstDatos2.DataSource = null; // Se limpia la lista.
                    lstDatos2.DataSource = arregloOrdenado; // Se asignan los datos a la lista.
                }
                else // Si el usuario dice que NO
                {
                    lstDatos.DataSource = null; // Se limpia la lista.
                    MessageBox.Show("Datos generados en memoria, pero ocultos.");
                }
            }
        }




        // --- INSERTION SORT (O(n^2)) ---
        // Usamos 'async' para no bloquear la ventana principal mientras ordena
        private async void btnInsertionSort_Click_1(object sender, EventArgs e)
        {
            // Se hace una validacion de si el arregloNumeros esta vacio o si la longitud de este es 0 osea que esta vacio.
            if (arregloNumeros == null || arregloNumeros.Length == 0)
            { // Si no esta vacio entonces te dice que generes los numeros y te manda de regreso.
                MessageBox.Show("Primero genera los números.");
                return;
            }

            // Si el arreglo tiene 
            if (arregloNumeros.Length > 50000)
            {
                DialogResult respuesta = MessageBox.Show(
                    $"¡Atención! Vas a ordenar {arregloNumeros.Length:N0} datos con Insertion Sort.\n" +
                    "Este algoritmo es muy lento para esta cantidad y la aplicación podría congelarse varios minutos.\n\n" +
                    "¿Deseas proceder de todos modos?",
                    "Advertencia de Rendimiento",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Si el usuario dice que NO, nos salimos. Si dice SÍ, el código sigue abajo.
                if (respuesta == DialogResult.No) return;
            }

            btnInsertionSort.Enabled = false;
            lblTiempoInicio.Text = "Iniciando Insercion...";

            // CRUCIAL: Preparamos el arreglo para que la Búsqueda Binaria funcione después
            arregloOrdenado = (long[])arregloNumeros.Clone();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            await Task.Run(() =>
            {
                // Ordenamos LA COPIA
                for (long i = 1; i < arregloOrdenado.Length; i++)
                {
                    long key = arregloOrdenado[i];
                    long j = i - 1;

                    while (j >= 0 && arregloOrdenado[j] > key)
                    {
                        arregloOrdenado[j + 1] = arregloOrdenado[j];
                        j = j - 1;
                    }
                    arregloOrdenado[j + 1] = key;
                }
            });

            sw.Stop();
            lblTiempoFin.Text = "Fin Insercion";
            lblDuracion.Text = $"Duración: {sw.ElapsedMilliseconds} ms";
            btnInsertionSort.Enabled = true;

            // Mostrar resultados
            if (arregloOrdenado.Length <= Limite_Visualizacion)
            {
                lstDatos2.DataSource = null;
                lstDatos2.DataSource = arregloOrdenado;
            }
            else
            {
                MessageBox.Show("Ordenado completado en memoria. ");
            }
        }
        

        // --- BÚSQUEDA SECUENCIAL (Lineal - O(n)) ---
        private void btnBusquedaSecuencial_Click_1(object sender, EventArgs e)
        {
            if (arregloNumeros == null) return;

            long objetivo = 0;
            // Lectura segura del nuevo TextBox tbBuscar
            if (!long.TryParse(tbBuscar.Text, out objetivo))
                objetivo = 450; // Valor por defecto si el campo está vacío o es texto

            Stopwatch sw = new Stopwatch();
            sw.Start();

            bool encontrado = false;
            // Recorre uno por uno hasta encontrarlo
            for (int i = 0; i < arregloNumeros.Length; i++)
            {
                if (arregloNumeros[i] == objetivo)
                {
                    encontrado = true;
                    break; // Rompe el ciclo apenas lo encuentra para eficiencia
                }
            }

            sw.Stop();
            lblDuracion.Text = $"Secuencial: {sw.Elapsed.TotalMilliseconds} ms. Hallado: {encontrado}";
        }
        // --- BÚSQUEDA BINARIA (Logarítmica - O(log n)) ---
        // REQUISITO: El arreglo DEBE estar ordenado previamente (usar QuickSort primero)
        private void btnBusquedaBinaria_Click_1(object sender, EventArgs e)
        {
            if (arregloOrdenado == null)
            {
                MessageBox.Show("Primero Debes Ordenar la lista.");
                return;
            }

            long objetivo = 0;
            if (!long.TryParse(tbBuscar.Text, out objetivo)) objetivo = 450;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            long min = 0;
            long max = arregloOrdenado.Length - 1;
            bool encontrado = false;

            // Algoritmo de división sucesiva
            while (min <= max)
            {
                long mid = (min + max) / 2; // Calcula el punto medio
                if (objetivo == arregloOrdenado[mid])
                {
                    encontrado = true;
                    break;
                }
                else if (objetivo < arregloOrdenado[mid])
                {
                    max = mid - 1; // Descartar mitad derecha
                }
                else
                {
                    min = mid + 1; // Descartar mitad izquierda
                }
            }

            sw.Stop();
            lblDuracion.Text = $"Binaria: {sw.Elapsed.TotalMilliseconds} ms. Hallado: {encontrado}";
        }

        private void lblTiempoFin_Click(object sender, EventArgs e)
        {

        }
    }
}


