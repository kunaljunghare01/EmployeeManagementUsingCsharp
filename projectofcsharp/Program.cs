using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectofcsharp
{
    public class AbcCmpany
    {
        public int emp_Id { get; set; }
        public string emp_Name { get; set; }
        public string emp_Address { get; set; }
        public string emp_Designation { get; set; }

    }
    class EmployeeManagement
    {
        static void Main(string[] args)
        {
            EmployeeManagement obj_Company = new EmployeeManagement();
            List<AbcCmpany> employeeList = new List<AbcCmpany>();
         /*   obj_Company.Display_Employee( employeeList, "csc.txt");*/
          /*  string sometext = "some text";
            File.WriteAllText(@"C:\Users\Dell\OneDrive\Documents\csc.txt", sometext);
            string readtext = File.ReadAllText(@"C:\Users\Dell\OneDrive\Documents\csc.txt");
            Console.WriteLine(readtext);
            Console.ReadLine(); */

             char ans;
            int search_Id;
            do
            {
                Console.Clear();
                Console.WriteLine("**************************EMPLOYEE MANAGEMENT SYSTEM MENU******************************");
                Console.WriteLine("1. Add an Employee");
                Console.WriteLine("2. View Employee details");
                Console.WriteLine("3. Search Employee details");
                Console.WriteLine("4. Modify Employee details");
                Console.WriteLine("5. Remove Employee details");
                Console.WriteLine("6. Exit");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.Write("Enter Your Choise Here:-");
                int choose_number = Convert.ToInt32(Console.ReadLine());

                switch (choose_number)
                {
                    case 1:
                        obj_Company.Add_Employee(employeeList);
                        obj_Company.Display_Employee( employeeList,"csc.txt");
                        break;
                    case 2:
                        obj_Company.Display_Employee(employeeList, "csc.txt");
                        break;
                    case 3:
                        Console.WriteLine("Enter Employee Id Which You Want To Search:");
                        search_Id = Convert.ToInt32(Console.ReadLine());
                        AbcCmpany obj_search = obj_Company.Search(employeeList, search_Id);
                        if (obj_search != null)
                        {
                            Console.WriteLine("Employee ID \t{0}", obj_search.emp_Id);
                            Console.WriteLine("Employee Name \t{0}", obj_search.emp_Name);
                            Console.WriteLine("Employee Address \t{0}", obj_search.emp_Address);
                            Console.WriteLine("Designation \t{0}\n", obj_search.emp_Designation);
                        }
                        else
                        {
                            Console.WriteLine("Record Not Found...!!!");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Employee Id Which You Want To Search:");
                        search_Id = Convert.ToInt32(Console.ReadLine());
                        AbcCmpany obj_Modify = obj_Company.Search(employeeList, search_Id);
                        if (obj_Modify != null)
                        {
                            Console.WriteLine("Employee ID :" + obj_Modify.emp_Id);
                            Console.WriteLine("Employee Name :" + obj_Modify.emp_Name);
                            Console.WriteLine("Employee Address :" + obj_Modify.emp_Address);
                            Console.WriteLine("Designation :" + obj_Modify.emp_Designation);
                            obj_Company.Modify_Employee(employeeList, obj_Modify);
                            obj_Company.Display_Employee(employeeList, "csc.txt");
                        }
                        else
                        {
                            Console.WriteLine("Record Not Found...!!!");
                        }

                        break;
                    case 5:
                        Console.WriteLine("Enter Employee Id Which You Want To Search:");
                        search_Id = Convert.ToInt32(Console.ReadLine());
                        AbcCmpany obj_Delete = obj_Company.Search(employeeList, search_Id);
                        if (obj_Delete != null)
                        {
                            Console.WriteLine("Employee ID :" + obj_Delete.emp_Id);
                            Console.WriteLine("Employee Name :" + obj_Delete.emp_Name);
                            Console.WriteLine("Employee Address :" + obj_Delete.emp_Address);
                            Console.WriteLine("Designation :" + obj_Delete.emp_Designation);
                            obj_Company.Remove(employeeList, obj_Delete);
                            obj_Company.Display_Employee(employeeList,"csc.txt");
                        }
                        else
                        {
                            Console.WriteLine("Record Not Found...!!!");
                        }
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalide Choise....!!! Please Enter Correct Choice...!!!");
                        break;
                }
                Console.Write("Would You Like To Continue(Y/N):");
                ans = Convert.ToChar(Console.ReadLine());
            } while (ans == 'y' || ans == 'Y');
        }


        public void Add_Employee(List<AbcCmpany> employeeList)
        {
            AbcCmpany obj_Comapny1 = new AbcCmpany();
            Console.Write("Enter Employee Id:");
            obj_Comapny1.emp_Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Employee Name:");
            obj_Comapny1.emp_Name = Console.ReadLine();
            Console.Write("Enter Employee Addess:");
            obj_Comapny1.emp_Address = Console.ReadLine();
            Console.Write("Enter Employee Designation:");
            obj_Comapny1.emp_Designation = Console.ReadLine();

            employeeList.Add(obj_Comapny1);
            Console.WriteLine("Employee Deatil Added Successfully...!!!!:");
        }

         public void Display_Employee(List<AbcCmpany> employeeList,string filepath)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
            {
                Console.WriteLine("****************************Employee Details****************************************");
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine("Employee Id\tEmployee Name\tEmployee Addess\tEmployee Designation");
                Console.WriteLine("------------------------------------------------------------------------------------");
                foreach (AbcCmpany i in employeeList)
                {
                    Console.WriteLine(i.emp_Id + " \t| " + i.emp_Name + " \t| " + i.emp_Address + " \t| " + i.emp_Designation);
                }
               
                file.WriteLine("------------------------------------------------------------------------------------");
                file.WriteLine("****************************Employee Details****************************************");
                file.WriteLine("------------------------------------------------------------------------------------");
                file.WriteLine("Employee Id\tEmployee Name\tEmployee Addess\tEmployee Designation");
                file.WriteLine("------------------------------------------------------------------------------------");
                foreach (AbcCmpany i in employeeList)
                {
                    file.WriteLine(i.emp_Id + " \t| " + i.emp_Name + " \t| " + i.emp_Address + " \t| " + i.emp_Designation);
                }

                Console.WriteLine("---------------------------------------------------------------------------------");

            }


        }

        public AbcCmpany Search(List<AbcCmpany> employeeList, int search_Id)
        {
            return employeeList.Find(emp => emp.emp_Id == search_Id);
        }


        public void Modify_Employee(List<AbcCmpany> employeeList, AbcCmpany obj_Modify)
        {
            Console.WriteLine("Chose Option for Modify Employee Detail:");
            Console.WriteLine("1.Id 2.Name 3.Address 4.Designation");
            int modify_number = Convert.ToInt32(Console.ReadLine());
            switch (modify_number)
            {
                case 1:
                    Console.WriteLine("Enter New Employee Id:");
                    int new_Id = Convert.ToInt32(Console.ReadLine());
                    obj_Modify.emp_Id = new_Id;
                    break;
                case 2:
                    Console.WriteLine("Enter New Employee Name:");
                    string new_Name = Console.ReadLine();
                    obj_Modify.emp_Name = new_Name;
                    break;
                case 3:
                    Console.WriteLine("Enter New Employee Address:");
                    string new_Address = Console.ReadLine();
                    obj_Modify.emp_Address = new_Address;
                    break;
                case 4:
                    Console.WriteLine("Enter New Employee Designation:");
                    string new_Designation = Console.ReadLine();
                    obj_Modify.emp_Designation = new_Designation;
                    break;
                default:
                    Console.WriteLine("Invalide Choise....");
                    break;
            }
            // employeeList.Add(obj_Modify);
        }

        public void Remove(List<AbcCmpany> employeeList, AbcCmpany obj_Modify)
        {
            employeeList.Remove(obj_Modify);
            Console.WriteLine("1 Record Removed SuccessFully....!!!");
        }


    }
   
}
   
