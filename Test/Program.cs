using System;
using ahbsd.lib.Nutrients.Data;
using ahbsd.lib.Nutrients.Measurement;
using System.Data;
using System.Data.SQLite;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            IDictionary<string, int> lengthPerCol;
            Console.WriteLine("Test");
            Console.WriteLine("====");

            int maxCols, currentCol, maxlines;

            NutritionData data = new NutritionData();

            data.Connection.StateChange += Connection_StateChange;

            data.Connection.Open();

            if (data.FillNutrients() > 0)
            {
                string nID, name, unit, alternativ;

                dsNutrients = (NutrientsDataSet)data.DSNutrients;

                NutrientTable = (NutrientTable)dsNutrients.Tables["nutrient"];

                maxCols = NutrientTable.Columns.Count;
                currentCol = 0;

                lengthPerCol = GetSize(NutrientTable);

                maxlines = 0;
                foreach (var item in lengthPerCol)
                {
                    maxlines += item.Value + 1;
                }
                maxlines++;

                Console.WriteLine();
                Console.WriteLine("".PadLeft(maxlines, '–'));

                foreach (DataColumn item in NutrientTable.Columns)
                {
                    if (currentCol < maxCols - 1)
                    {
                        Console.Write(GetPart(item.Caption, false, lengthPerCol[item.ColumnName]));
                    }
                    else
                    {
                        Console.Write(GetPart(item.Caption, true, lengthPerCol[item.ColumnName]));
                        Console.WriteLine();
                    }
                    currentCol++;
                }

                Console.WriteLine("".PadLeft(maxlines, '='));

                foreach (DataRow item in NutrientTable.Rows)
                {
                    nID = GetPart(item["nid"].ToString(), false, lengthPerCol["nID"]);
                    name = GetPart(item["name"].ToString(), false, lengthPerCol["name"]);
                    unit = GetPart(item["unit"].ToString(), false, lengthPerCol["unit"]);
                    alternativ = GetPart(item["Alternative"].ToString(), true, lengthPerCol["Alternative"]);

                    Console.WriteLine($"{nID}{name}{unit}{alternativ}");
                }

                Console.WriteLine("".PadLeft(maxlines, '–'));
                Console.WriteLine();
            }


            if (data.FillUnits() > 0)
            {
                IList<IUnit> units;
                string uID, name;
                double g, oz;

                dsNutrients = (NutrientsDataSet)data.DSNutrients;

                UnitTable = (UnitTable)dsNutrients.Tables["unit"];

                units = UnitTable.GetUnits();

                IOptionalUnit ou = new OptionalUnitOz(units[0]);

                g = 5.0;
                oz = ou.FormulaOptional(g);
                g = ou.FormularSI(oz);

                maxCols = UnitTable.Columns.Count;
                currentCol = 0;

                lengthPerCol = GetSize(UnitTable);

                maxlines = 0;
                foreach (var item in lengthPerCol)
                {
                    maxlines += item.Value + 1;
                }
                maxlines++;

                Console.WriteLine();
                Console.WriteLine("".PadLeft(maxlines, '–'));

                foreach (DataColumn item in UnitTable.Columns)
                {
                    if (currentCol < maxCols - 1)
                    {
                        Console.Write(GetPart(item.Caption, false, lengthPerCol[item.ColumnName]));
                    }
                    else
                    {
                        Console.Write(GetPart(item.Caption, true, lengthPerCol[item.ColumnName]));
                        Console.WriteLine();
                    }
                    currentCol++;
                }

                Console.WriteLine("".PadLeft(maxlines, '='));

                foreach (DataRow item in UnitTable.Rows)
                {
                    uID = GetPart(item["uid"].ToString(), false, lengthPerCol["uID"]);
                    name = GetPart(item["name"].ToString(), true, lengthPerCol["name"]);

                    Console.WriteLine($"{uID}{name}");
                }

                Console.WriteLine("".PadLeft(maxlines, '–'));
                Console.WriteLine();
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

        private static string GetPart(string val, bool last, int length)
        {
            string result = $"{val}";

            if (length > val.Length)
            {
                result = val.PadLeft(length);
            }

            if (!last)
            {
                result = $"|{result}";
            }
            else
            {
                result = $"|{result}|";
            }

            return result;
        }

        private static IDictionary<string, int> GetSize(DataTable table)
        {
            IDictionary<string, int> result = new Dictionary<string, int>(table.Columns.Count);
            ICollection<string> keys;
            IDictionary<string, int> minLength = new Dictionary<string, int>(table.Columns.Count);
            int length;
            bool maxSet;

            foreach (DataColumn column in table.Columns)
            {
                result.Add(column.ColumnName, column.MaxLength);
                minLength.Add(column.ColumnName, column.Caption.Length);
            }

            keys = new Collection<string>();

            foreach (string key in result.Keys)
            {
                keys.Add(key);
            }

            foreach (DataRow row in table.Rows)
            {
                foreach (string key in keys)
                {
                    length = 0;
                    maxSet = result[key] != -1;

                    if (maxSet)
                    {
                        length = minLength[key];

                        if (row[key].ToString().Length > length)
                        {
                            minLength[key] = row[key].ToString().Length;
                        }
                    }
                    else // the first time to set over -1
                    {
                        length = result[key];

                        if (row[key].ToString().Length > length)
                        {
                            result[key] = row[key].ToString().Length;
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, int> item in minLength)
            {
                result[item.Key] = minLength[item.Key];
            }

            return result;
        }
    }
}
