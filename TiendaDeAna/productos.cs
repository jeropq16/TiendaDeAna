namespace TiendaDeAna;

public class productos
{
    static List<string> nombres = new List<string> { "Alfajores", "Papitas", "Revolcones", "Bombones", "Galletas", "Gomitas", "Platanitos" };
    static List<double> precios = new List<double> { 2500, 2000, 300, 500, 400, 500, 2000 };
    static List<int> stock = new List<int> { 20, 15, 30, 12, 5, 9, 0};

    static List<string> historial = new List<string>();
    static double total = 0;
    
    public static void MostrarProductos()
    {
        Console.WriteLine("Bienvenido a la tienda de Ana");
        Console.WriteLine("Productos disponibles:");

        for (int i = 0; i < nombres.Count; i++)
        {
            
            
            Console.WriteLine($"{i + 1}. {nombres[i]}");
            Console.WriteLine($"Precio: {precios[i]}");
            Console.WriteLine($"Stock disponible: {stock[i]}");
        }
    }

    public static void ComprarProductos()
    {
        bool seguir = true;

        while (seguir)
        {
            MostrarProductos();
            Console.Write("Escriba el nombre del producto que quiere comprar: ");
            string producto = Console.ReadLine();

            int indice = -1;
            for (int i = 0; i < nombres.Count; i++)
            {
                if (nombres[i].ToLower() == producto.ToLower())
                {
                    indice = i;
                    break;
                }
            }

            if (indice != -1)
            {
                Console.Write("Ingrese la cantidad: ");
                int cantidad = int.Parse(Console.ReadLine());

                if (cantidad <= stock[indice])
                {
                    stock[indice] -= cantidad;
                    double subtotal = cantidad * precios[indice];
                    total += subtotal;
                    historial.Add($"{cantidad} x {nombres[indice]} = {subtotal}");
                    Console.WriteLine("Producto agregado");
                }
                else
                {
                    Console.WriteLine("Se le acabó el stock a Ana");
                }
            }
            else
            {
                Console.WriteLine("Ana todavia no vende eso");
            }

            Console.Write("Quiere seguir comprando si/no: ");
            string opcion = Console.ReadLine().ToLower();
            if (opcion == "no")
            {
                seguir = false;
            }
        }
    }

    public static void MostrarTicket()
    {
        Console.WriteLine("Resumen de la compra");
        foreach (string linea in historial)
        {
            Console.WriteLine(linea);
        }

        double descuento = 0;
        if (total > 20000)
        {
            descuento = total * 0.20;
        }
        else if (total > 10000)
        {
            descuento = total * 0.10;
        }

        double totalFinal = total - descuento;

        Console.WriteLine($"\nTotal: {total}");
        if (descuento > 0)
        {
            Console.WriteLine($"Descuento: -{descuento}");
            Console.WriteLine($"Total: {totalFinal}");
        }
        else
        {
            Console.WriteLine($"Total: {total}");
        }

        Console.WriteLine("Gracias por comprar en la tienda de Ana");
    } 
}
