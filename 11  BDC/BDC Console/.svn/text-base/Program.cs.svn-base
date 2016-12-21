using System;
using System.Data;
using Microsoft.Office.Server.ApplicationRegistry.Infrastructure;
using Microsoft.Office.Server.ApplicationRegistry.MetadataModel;
using Microsoft.Office.Server.ApplicationRegistry.Runtime;
using Microsoft.Office.Server.ApplicationRegistry.SystemSpecific.Db;
using WSSAdmin = Microsoft.SharePoint.Administration;
using OSSAdmin = Microsoft.Office.Server.Administration;

namespace BDC_Console
{
    internal class Program
    {
        private const string SSP = "SharedServices1";

        private static void Main(string[] args)
        {
            ConnectToSSP();
            IterateLOBSystems();
            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }

        private static void ConnectToSSP()
        {
            SqlSessionProvider.Instance().SetSharedResourceProviderToUse(SSP);
        }

        private static void IterateLOBSystems()
        {
            NamedLobSystemInstanceDictionary sysInstances = ApplicationRegistry.GetLobSystemInstances();

            Console.WriteLine("Listing system instances...");
            foreach (String name in sysInstances.Keys)
            {
                Console.WriteLine(name);
            }

            NamedLobSystemDictionary lobSystems = ApplicationRegistry.GetLobSystems();
            foreach (LobSystem lobSystem in lobSystems.Values)
            {
                Console.WriteLine("Application: " + lobSystem.Name);
                NamedDataClassDictionary lobClasses = lobSystem.GetDataClasses();
                foreach (DataClass dataClass in lobClasses.Values)
                {
                    Console.WriteLine(" Entities: " + dataClass.Name);
                }


                if (lobSystem.Name == "AdventureWorksSample")
                {
                    // work on a specific class
                    DataClass customers = lobClasses["Customer"];
                    NamedMethodDictionary methods = customers.GetMethods();
                    foreach (Method meth in methods.Values)
                    {
                        Console.WriteLine(" Method: " + meth.Name);
                    }
                }

                if (lobSystem.Name == "AdventureWorksLOBSystem")
                {
                    // filter all femalce Employees

                    Entity employees = lobSystem.GetEntities()["HumanResources.Employee"];

                    FilterCollection filtered = employees.GetFinderFilters();
                    (filtered[0] as ComparisonFilter).Value = 10;

                    IEntityInstanceEnumerator empEnum = employees.FindFiltered(filtered,
                                                                               ApplicationRegistry.GetLobSystemInstances
                                                                                   ()["AdventureWorksInstance"]);

                    while (empEnum.MoveNext())
                    {
                        DataTable dt = (empEnum.Current as DbEntityInstance).EntityAsDataTable;
                        PrintDataRow(dt.Rows[0]);
                    }
                }
            }
        }

        private static void PrintDataRow(DataRow dr)
        {
            foreach (DataColumn dataColumn in dr.Table.Columns)
            {
                Console.Write(dr[dataColumn] + "\t");
            }
            Console.WriteLine();
        }
    }
}

