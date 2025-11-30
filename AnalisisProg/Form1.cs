using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalisisProg
{

    public partial class Form1 : Form
    {

        long[] arregloNumeros;
        public Form1()
        {
            InitializeComponent();
        }

        // --- BOTÓN DE GENERACIÓN DE DATOS ---
        private void btnGenerarNumeros_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lectura del TextBox renombrado a tbCantidad
                long cant = long.Parse(tbCantidad.Text);

                // Inicializamos el array con el tamaño fijo exacto
                arregloNumeros = new long[cant];
                Random rdn = new Random();

                // Stopwatch es mucho más preciso que DateTime.Now para medir rendimiento
                Stopwatch sw = new Stopwatch();
                lblTiempoInicio.Text = "Inicio Gen: " + DateTime.Now.ToString("hh:mm:ss.fff");

                sw.Start();
                // Bucle optimizado para llenado rápido
                for (long i = 0; i < cant; i++)
                {
                    // Generamos números aleatorios entre 1 y 1 millón
                    arregloNumeros[i] = rdn.Next(1, 1000000);
                }
                sw.Stop();

                lblTiempoFin.Text = "Fin Gen: " + DateTime.Now.ToString("hh:mm:ss.fff");
                lblDuracion.Text = $"Duración: {sw.ElapsedMilliseconds} ms";

                // PROTECCIÓN DE INTERFAZ:
                // Intentar renderizar 5,000,000 de filas en un ListBox congelaría la UI.
                // Solo mostramos los datos si la cantidad es manejable (<= 10,000).
                if (cant <= 10000)
                {
                    lstDatos.DataSource = null;
                    lstDatos.DataSource = arregloNumeros;
                }
                else
                {
                    lstDatos.DataSource = null;
                    MessageBox.Show("Datos generados en memoria. Ocultos por rendimiento.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Método recursivo principal de QuickSort
        private void QuickSort(long[] arr, long low, long high)
        {
            if (low < high)
            {
                // Obtiene el índice de partición
                long pi = Partition(arr, low, high);

                // Ordena recursivamente los elementos antes y después de la partición
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        // Lógica de partición (Divide y Vencerás)
        private long Partition(long[] arr, long low, long high)
        {
            long pivot = arr[high]; // Tomamos el último elemento como pivote
            long i = (low - 1);

            for (long j = low; j < high; j++)
            {
                // Si el elemento actual es menor que el pivote
                if (arr[j] < pivot)
                {
                    i++;
                    // Intercambio (Swap)
                    long temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            // Intercambio final para colocar el pivote en su lugar correcto
            long temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;
            return i + 1;
        }

        // --- QUICK SORT (O(n log n)) ---
        private async void btnQuickSort_Click_1(object sender, EventArgs e)
        {
            if (arregloNumeros == null || arregloNumeros.Length == 0) return;

            btnQuickSort.Enabled = false;
            lblTiempoInicio.Text = "Iniciando QuickSort...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Ejecución en segundo plano
            await Task.Run(() =>
            {
                QuickSort(arregloNumeros, 0, arregloNumeros.Length - 1);
            });

            sw.Stop();
            lblTiempoFin.Text = "Fin QuickSort";
            lblDuracion.Text = $"Duración: {sw.ElapsedMilliseconds} ms";
            btnQuickSort.Enabled = true;

            if (arregloNumeros.Length <= 10000)
            {
                lstDatos.DataSource = null;
                lstDatos.DataSource = arregloNumeros;
            }
        }

        // --- INSERTION SORT (O(n^2)) ---
        // Usamos 'async' para no bloquear la ventana principal mientras ordena
        private async void btnInsertionSort_Click_1(object sender, EventArgs e)
        {
            if (arregloNumeros == null || arregloNumeros.Length == 0) return;

            btnInsertionSort.Enabled = false; // Desactivar botón para evitar doble clic
            lblTiempoInicio.Text = "Iniciando Insertion...";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Task.Run envía el proceso pesado a un hilo secundario del procesador.
            // Esto permite que la barra de título se pueda mover y no salga "No Responde".
            await Task.Run(() =>
            {
                // Lógica pura de Insertion Sort
                for (long i = 1; i < arregloNumeros.Length; i++)
                {
                    long key = arregloNumeros[i];
                    long j = i - 1;

                    // Desplaza los elementos mayores hacia la derecha
                    while (j >= 0 && arregloNumeros[j] > key)
                    {
                        arregloNumeros[j + 1] = arregloNumeros[j];
                        j = j - 1;
                    }
                    arregloNumeros[j + 1] = key;
                }
            });

            sw.Stop();
            lblTiempoFin.Text = "Fin Insertion";
            lblDuracion.Text = $"Duración: {sw.ElapsedMilliseconds} ms";
            btnInsertionSort.Enabled = true;

            // Actualizar visualización solo si son pocos datos
            if (arregloNumeros.Length <= 10000)
            {
                lstDatos.DataSource = null;
                lstDatos.DataSource = arregloNumeros;
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
            if (arregloNumeros == null) return;

            long objetivo = 0;
            if (!long.TryParse(tbBuscar.Text, out objetivo)) objetivo = 450;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            long min = 0;
            long max = arregloNumeros.Length - 1;
            bool encontrado = false;

            // Algoritmo de división sucesiva
            while (min <= max)
            {
                long mid = (min + max) / 2; // Calcula el punto medio
                if (objetivo == arregloNumeros[mid])
                {
                    encontrado = true;
                    break;
                }
                else if (objetivo < arregloNumeros[mid])
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


