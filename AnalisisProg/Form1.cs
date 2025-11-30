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
    {
        private const int Limite_Visualizacion = 1000000;
        long[] arregloNumeros;
        long[] arregloOrdenado;
        public Form1()
        {
            InitializeComponent();
        }

        // --- BOTÓN DE GENERACIÓN DE DATOS ---
        private void btnGenerarNumeros_Click(object sender, EventArgs e)
        {
            try
            {
                // MEJORA: Usar TryParse para evitar que el programa se cierre si escriben letras
                if (!long.TryParse(tbCantidad.Text, out long cant))
                {
                    MessageBox.Show("Por favor ingresa un número válido.");
                    return;
                }

                // Generación (tu código actual)
                arregloNumeros = new long[cant];
                Random rdn = new Random();
                Stopwatch sw = new Stopwatch();

                lblTiempoInicio.Text = "Inicio Gen: " + DateTime.Now.ToString("hh:mm:ss.fff");
                sw.Start();
                for (long i = 0; i < cant; i++)
                {
                    arregloNumeros[i] = rdn.Next(1, 1000000);
                }
                sw.Stop();

                lblTiempoFin.Text = "Fin Gen: " + DateTime.Now.ToString("hh:mm:ss.fff");
                lblDuracion.Text = $"Duración: {sw.ElapsedMilliseconds} ms";

                // Limpiamos la segunda lista para evitar confusiones
                lstDatos2.DataSource = null;

                // --- AQUÍ ESTÁ LA VENTANA EMERGENTE QUE PEDISTE ---
                if (cant <= Limite_Visualizacion)
                {
                    lstDatos.DataSource = null;
                    lstDatos.DataSource = arregloNumeros;
                }
                else
                {
                    // Preguntamos al usuario
                    DialogResult respuesta = MessageBox.Show(
                        $"Has generado {cant:N0} registros. Mostrarlos en la lista podría congelar la aplicación.\n\n¿Deseas mostrarlos de todos modos?",
                        "Advertencia de Rendimiento",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (respuesta == DialogResult.Yes)
                    {
                        lstDatos.DataSource = null;
                        lstDatos.DataSource = arregloNumeros;
                    }
                    else
                    {
                        lstDatos.DataSource = null;
                        MessageBox.Show("Datos generados en memoria, pero ocultos.");
                    }
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

            // --- ESTA ES LA LÍNEA MÁGICA QUE TE FALTA ---
            // Copiamos los números al arreglo que usa la Búsqueda Binaria
            arregloOrdenado = (long[])arregloNumeros.Clone();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Procesamos en segundo plano para no congelar la pantalla
            await Task.Run(() =>
            {
                // Ordenamos LA COPIA (arregloOrdenado) en lugar del original
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
                MessageBox.Show("Ordenado completado en memoria. ¡Ahora ya funciona la Búsqueda Binaria!");
            }
        }

        // --- INSERTION SORT (O(n^2)) ---
        // Usamos 'async' para no bloquear la ventana principal mientras ordena
        private async void btnInsertionSort_Click_1(object sender, EventArgs e)
        {
            // Validación básica
            if (arregloNumeros == null || arregloNumeros.Length == 0)
            {
                MessageBox.Show("Primero genera los números.");
                return;
            }

            // --- CAMBIO SOLICITADO: PREGUNTAR EN LUGAR DE BLOQUEAR ---
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
                MessageBox.Show("Ordenado completado en memoria. Ahora puedes usar Búsqueda Binaria.");
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


