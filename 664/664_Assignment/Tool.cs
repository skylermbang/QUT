using System;
namespace _664_Assignment
{
    public class Tool
    {

        public string[] categories = { "Gardening", "Flooring", "Fencing", "Measuring", "Cleaning", "Painting", "Electronic", "Electricity", "Automotive" };
        
        public string category;
        public string[] GardeningTypes = { "Line Trimmers", "Lawn Mowers", "Hand Tools", "Wheelbarrows", "Garden Power Tools" };
        public string[] FlooringTypes = { "Scrapers", "Floor Lasers", "Floor Levelling Tools", "Floor Levelling Materials", "Floor Hand Tools", "Tiling Tools" };
        public string[] FencingTypes = { "Hand Tools", "Electric Fencing", "Stell Fencing Tools", "Power Tools", "Fencing Accessories" };
        public string[] MeasuringTypes = { "Distance Tools", "Laser Measurer", "Measuring Jugs", "Tmeprature & Humanity Tools", "Levelling Tools","Markers" };
        public string[] CleaningTypes = { "Draining", "Car Cleaning", "Vacuum", "Pressure Cleaners", "Pool Cleaning","Floor Cleaning" };
        public string[] PaintingTypes = { "Sanding Tools", "Brushes", "Rollers", "Paint Removal Tools", "Paint Scrapers" };
        public string[] ElectronicTypes = { "Voltage Tester", "Oscilloscopes", "Thermal Imaging", "Data Test Tool", "Insulation Testers" };
        public string[] ElectricityTypes = { "Test Equipment", "Safety Equipment", "Basic hand Tools", "Circuit Protection", "Cable Tools" };
        public string[] AutomotiveTypes = { "Jacks", "Air Compressors", "Battery Chargers", "Socket Tools", "Braking","Drivetrain" };

   

        public string type;
        public int BurrowNum;
        public string name;
        public Boolean availbility;
        public Boolean current;
        public int Qnt;
        public int currentQnt;

        public Tool(string category, string type,int Qnt, string name)
        {
            var check = SearchCat(category);
            if(check == true)
            {
                var typeCheck = SearchType(type, category);
                if(typeCheck == true)
                {
                    this.category = category;
                    this.type = type;
                    this.Qnt = Qnt;
                    this.currentQnt = Qnt;
                    this.name = name;
                    this.current = false;
                    Console.WriteLine(" adding new tool  {0}", name);


                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(" wrong types");
                }
            }
              
            else
            {
                Console.WriteLine(" wrong category");
            }
        }

        public Boolean SearchCat(string category)

            //check categories
        {

            var target = category;
            for (int i=0; i<categories.Length; i++)
            {
                if(categories[i] == target)
                {
                    return true;
                    
                }
                
            }
            return false;
        }

        public Boolean SearchType(string type, string category)
            //check types
        {

            if (category == "Gardening")
            {
                for (int i = 0; i < GardeningTypes.Length; i++)
                {
                    if (GardeningTypes[i] == type)
                    {
                        return true;

                    }

                }
            }
            else if (category == "Flooring")
            {
                for (int i = 0; i < FlooringTypes.Length; i++)
                {
                    if (FlooringTypes[i] == type)
                    {
                        return true;

                    }

                }
            }
            else if (category == "Fencing")
            {
                for (int i = 0; i < FencingTypes.Length; i++)
                {
                    if (FencingTypes[i] == type)
                    {
                        return true;

                    }

                }
            }
            else if (category == "Measuring")
            {
                for (int i = 0; i < MeasuringTypes.Length; i++)
                {
                    if (MeasuringTypes[i] == type)
                    {
                        return true;

                    }

                }
            }
            else if (category == "Cleaning")
            {
                for (int i = 0; i < CleaningTypes.Length; i++)
                {
                    if (CleaningTypes[i] == type)
                    {
                        return true;

                    }

                }
            }
            else if (category == "Painting")
            {
                for (int i = 0; i < PaintingTypes.Length; i++)
                {
                    if (PaintingTypes[i] == type)
                    {
                        return true;

                    }

                }
            }
            else if (category == "Electronic")
            {
                for (int i = 0; i < ElectronicTypes.Length; i++)
                {
                    if (ElectronicTypes[i] == type)
                    {
                        return true;

                    }

                }
            }
            else if (category == "Electricity")
            {
                for (int i = 0; i < ElectricityTypes.Length; i++)
                {
                    if (ElectricityTypes[i] == type)
                    {
                        return true;

                    }

                }
            }
            else if (category == "Automotive")
            {
                for (int i = 0; i < AutomotiveTypes.Length; i++)
                {
                    if (AutomotiveTypes[i] == type)
                    {
                        return true;

                    }

                }
            }




            return false;
        }



        //public string getAvail(string name)
        //{

        //}

        //public static Boolean Add()
        //{
        //    return true;
        //}


        //public static Boolean BorrowTool()
        //{
        //    return true;
        //}

        //public static Boolean ReturnTool()
        //{
        //    return true;
        //}

        //public static Tool Top()
        //{
        //    return Tool;
        //}




    }



}
