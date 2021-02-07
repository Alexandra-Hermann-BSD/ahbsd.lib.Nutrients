using System;
using ahbsd.lib.Nutrients.Data;
using System.Data;
using System.Data.SQLite;

namespace ahbsd.lib.Nutrients.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteErrorCode liteErrorCode;
            NutrientsDataSet dsNutrients;
            Console.WriteLine("Test");
            Console.WriteLine("====");

            NutritionData data = new NutritionData();

            data.Connection.StateChange += Connection_StateChange;

            data.Connection.Open();

            if (data.FillNutrients() > 0)
            {
                dsNutrients = (NutrientsDataSet)data.Components["DSNutrients"];

                foreach (var item in dsNutrients.Tables["nutrient"].Rows)
                {
                    
                }
            }

            data.Connection.Close();

            try
            {
                liteErrorCode = data.Connection.Shutdown();

                Console.WriteLine($"Shutdown: {liteErrorCode}");
            }
            catch (Exception)
            { }

            data.Dispose();

        }

        private static void Connection_StateChange(object sender, StateChangeEventArgs e)
        {
            Console.WriteLine($"{sender}: Connection changed from '{e.OriginalState}' to '{e.CurrentState}'.");
        }
    }
}
