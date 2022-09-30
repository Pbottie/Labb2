namespace Labb2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Kitchen kitchen = new();


            MainMenu();




            //1. Välj köksapparat att använda
            //Skriv ut trasig om den är trasig
            //annars skriv ut att den används
            //tillbaka till huvudmeny

            SelectApplianceMenu(kitchen);

            //2. Typ, Märke, Skick "Electrolux","Våffeljärn", "j" j fungerar, n fungerar inte.
            //Lagra i lista och skriv ut att den lagts till
            //tillbaka till huvudmeny

            //3. Skriv ut lista på alla apparater
            //Typ, märke, skick
            //tillbaka till huvudmeny

            //4. Skriver ut numrerad lista över alla köksapparater
            //Tar bort apparaten från listan och skriver ut meddelande om att köksapparaten har tagits bort.
            //tillbaka till huvudmeny


            //5. Avslutar huvudmenyn


            //lägg till några köksapparater i lista från början
            //felhantera all inmatning

            //Variabler
            //Properties
            //Typkonvertering
            //Felhantering try,catch
            //Klasser*
            //Abstract class*
            //Interface, bifogad*
            //Inkapsling
            //Metoder
            //Iteration
            //Selektion















        }


        static void MainMenu()
        {
            Console.WriteLine("~~~~~~~~~~KÖKET~~~~~~~~~~");
            Console.WriteLine("1. Använd köksapparat");
            Console.WriteLine("2. Lägg till köksapparat");
            Console.WriteLine("3. Lista köksapparater");
            Console.WriteLine("4. Ta bort köksapparat");
            Console.WriteLine("5. Avsluta");
            //Console.WriteLine("Ange val: ");

            int mainMenuOptions = 5;
            int input = GetValidInput(mainMenuOptions);




        }

        static void SelectApplianceMenu(Kitchen kitchen)
        {




        }



        static int GetValidInput(int menuOptions)
        {
            bool inmatat = false;
            int output = 0;

            while (!inmatat)
            {
                Console.Write("Ange val: ");
                inmatat = int.TryParse(Console.ReadLine(), out output);
                if (!inmatat)
                    Console.WriteLine("Mata in ett heltal tack!");
                else if (output > menuOptions || output < 1)
                {
                    Console.WriteLine("Ogiltigt val");
                    inmatat = false;
                }
            }
            return output;
        }




        //Appliance implements interface as an abstract class? to have private methods?

















    }

    class Kitchen
    {
        List<Appliance> applianceList = new();
        public Kitchen()
        {
            applianceList.Add(new Appliance { Type = "Microwave Oven", Brand = "Whirpool", IsFunctioning = true });
            applianceList.Add(new Appliance { Type = "Blender", Brand = "OBH Nordica", IsFunctioning = true });
            applianceList.Add(new Appliance { Type = "Toaster", Brand = "Toastmaster", IsFunctioning = true });

        }




    }






}

class Appliance : IKitchenAppliance //TODO This seems odd for some reason
{
    public string Type { get; set; } //TODO Check for string
    public string Brand { get; set; }//TODO Check for string
    public bool IsFunctioning { get; set; }//TODO Check for bool

    public void Use()
    {
        Console.WriteLine($"Använder {this.Type}");
    }
}


}