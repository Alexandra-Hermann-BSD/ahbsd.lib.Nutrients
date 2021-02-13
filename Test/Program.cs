using System;
using ahbsd.lib.Nutrients.Data;
using ahbsd.lib.Nutrients.Measurement;
using System.Data;
using System.Data.SQLite;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ahbsd.lib.Nutrients.Nutrient;
using ahbsd.lib.Nutrients.Producer;
using ahbsd.lib.Tools;

namespace ahbsd.lib.Nutrients.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteErrorCode liteErrorCode;
            NutrientsDataSet dsNutrients;

            NutrientTable NutrientTable;
            UnitTable UnitTable;
            ProducerTable ProducerTable;
            FoodTable FoodTable;
            VersionTable VersionTable;

            CultureInfo culture = new CultureInfo("de-DE");

            Console.WriteLine("Test");
            Console.WriteLine("====");

            NutritionData data = new NutritionData();

            data.Connection.StateChange += Connection_StateChange;

            data.Connection.Open();

            if (data.FillAll() > 0)
            {
                IList<INutrient> nutrients;
                IList<IUnit> units;
                IList<IProducer> producers;
                IList<IFood> foods;
                IList<IVersion> versions;

                double g, oz;

                dsNutrients = (NutrientsDataSet)data.DSNutrients;

                NutrientTable = (NutrientTable)dsNutrients.Tables["nutrient"];
                UnitTable = (UnitTable)dsNutrients.Tables["unit"];
                ProducerTable = (ProducerTable)dsNutrients.Tables["producer"];
                FoodTable = (FoodTable)dsNutrients.Tables["food"];
                VersionTable = (VersionTable)dsNutrients.Tables["Version"];

                units = UnitTable.GetUnits();
                nutrients = NutrientTable.GetNutrients();
                producers = ProducerTable.GetProducer();
                foods = FoodTable.GetFoods();
                versions = VersionTable.GetVersions();

                foreach (INutrient nutrient in nutrients)
                {
                    nutrient.CurrentCulture = culture;
                }

                IOptionalUnit ou = new OptionalUnitOz(units[0]);
                g = 5.0;
                oz = ou.FormulaOptional(g);
                g = ou.FormularSI(oz);

                ConsolePrintTable.Print(UnitTable);
                ConsolePrintTable.Print(NutrientTable);
                ConsolePrintTable.Print(ProducerTable);
                ConsolePrintTable.Print(FoodTable);
                ConsolePrintTable.Print(VersionTable);
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
