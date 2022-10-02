using Labb2;
using System.Runtime.CompilerServices;

namespace Labb2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MyKitchen kitchen = new();
            int mainMenuChoice = 0;

            do
            {
                mainMenuChoice = MainMenu();


                switch (mainMenuChoice)
                {
                    case 1:
                        kitchen.SelectAppliance();
                        //SelectApplianceMenu(kitchen);
                        break;
                    case 2:
                        kitchen.AddAppliance();
                        break;
                    case 3:
                        kitchen.ListAppliances();
                        break;
                    case 4:
                        kitchen.RemoveAppliance();
                        break;
                    case 5:
                        Console.WriteLine("Avslutar...");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val!");
                        break;
                }               

            }
            while (mainMenuChoice != 5);



        }


        static int MainMenu()
        {
            Console.WriteLine("~~~~~~~~~~KÖKET~~~~~~~~~~");
            Console.WriteLine("1. Använd köksapparat");
            Console.WriteLine("2. Lägg till köksapparat");
            Console.WriteLine("3. Lista köksapparater");
            Console.WriteLine("4. Ta bort köksapparat");
            Console.WriteLine("5. Avsluta");

            int mainMenuOptions = 5;
            int input = GetValidInput(mainMenuOptions);

            return input;


        }

       

        public static int GetValidInput(int menuOptions)
        {
            bool inmatat = false;
            int output = 0;

            while (!inmatat)
            {
                try
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
                catch (Exception ex)
                {

                    Console.WriteLine("Readline failed with message: " + ex.Message);
                }

            }
            return output;
        }

        public static bool GetValidBool()
        {
            char answer = 'c';

            while (answer != 'j' && answer != 'n')
            {
                Console.WriteLine("Ange om den fungerar (j/n): ");
                try
                {

                    answer = (char)Console.Read();
                    Console.ReadLine();//Gets rid of pesky "". Don't want to do Console.ReadLine().Trim()[0]

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Read failed with message: " + ex.Message);
                }
            }

            if (answer == 'j')
                return true;
            return false;


        }


    }

    abstract class Kitchen{
        protected List<Appliance> applianceList = new();
        protected public int ApplianceCount { get { return this.applianceList.Count; } }
                
        protected void PrintApplianceList()
        {
            int applianceNumber = 0;
            foreach (Appliance appliance in this.applianceList)
            {
                Console.WriteLine($"{applianceNumber + 1}. {appliance.Type}");
                applianceNumber++;
            }
        }
        public abstract void SelectAppliance();  
        public abstract void AddAppliance();
        public abstract void ListAppliances();
        public abstract void RemoveAppliance();

    }


    class MyKitchen : Kitchen
    {

        public MyKitchen()
        {
            applianceList.Add(new Appliance { Type = "Microwave Oven", Brand = "Whirpool", IsFunctioning = true });
            applianceList.Add(new Appliance { Type = "Blender", Brand = "OBH Nordica", IsFunctioning = true });
            applianceList.Add(new Appliance { Type = "Toaster", Brand = "Toastmaster", IsFunctioning = true });

        }

        public override void SelectAppliance()
        {

            Console.WriteLine("Välj Köksapparat:");
            PrintApplianceList();
            int input = Program.GetValidInput(this.ApplianceCount) - 1;


            this.applianceList[input].Use();


        }
        
        public override void AddAppliance()
        {
            Appliance newAppliance = new Appliance();
            try
            {
                Console.WriteLine("Ange typ: ");
                newAppliance.Type = Console.ReadLine();

                Console.WriteLine("Ange märke: ");
                newAppliance.Brand = Console.ReadLine();

                newAppliance.IsFunctioning = Program.GetValidBool();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Readline failed with message: " + ex.Message);
            }

            this.applianceList.Add(newAppliance);
            Console.WriteLine("Tillagd!");


        }

        public override void ListAppliances()
        {
            int applianceNumber = 1;
            foreach (Appliance appliance in applianceList)
            {
                Console.WriteLine($"{applianceNumber}. {appliance.Type,-15} av märke {appliance.Brand,-15} {(appliance.IsFunctioning ? "fungerar" : "fungerar inte")}"); //Yes ternary operator I like it for this...
                applianceNumber++;
            }

        }

        public override void RemoveAppliance()
        {
            PrintApplianceList();
            int removeIndex = Program.GetValidInput(this.ApplianceCount)-1;

            this.applianceList.RemoveAt(removeIndex);

        }

    }



    class Appliance : IKitchenAppliance
    {

        string _type;
        string _brand;

        public string Type
        {
            get { return this._type; }
            set
            {
                if (value != "")
                    this._type = value;
                else
                {
                    Console.WriteLine("Du måste skriva in en typ:");
                    this.Type = Console.ReadLine();
                }

            }
        }
        public string Brand
        {
            get { return this._brand; }
            set
            {
                if (value != "")
                    this._brand = value;
                else
                {
                    Console.WriteLine("Du måste skriva in ett märke:");
                    this.Brand = Console.ReadLine();
                }
            }
        }
        public bool IsFunctioning { get; set; }

        public void Use()
        {
            if (this.IsFunctioning)
                Console.WriteLine($"Använder {this.Type}...");
            else
                Console.WriteLine($"{this.Type} är trasig!");

        }
    }


}