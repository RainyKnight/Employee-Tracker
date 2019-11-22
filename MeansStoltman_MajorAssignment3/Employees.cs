// Andrew Means & Lucas Stoltman
// 18 Nov 2019
// Macrohard Employee
// Purpose: Create an application to be used by a company to keep track of 
// and organize employees by their salaries, hierarchy, and order of promotion.
using System;
using System.Collections.Generic;

namespace MeansStoltman_MajorAssignment3
{
    class Employees
    {
        static void Main(string[] args)
        {
            // Setup
            bool moreUserIteractions = true;

            // Create initial employees
            Employee adam = new Employee("Adam", 110000, null, null);
            Employee sarah = new Employee("Sarah", 115000, null, null);
            Employee raj = new Employee("Raj", 90000, sarah, null);
            Employee marcus = new Employee("Marcus", 80000, sarah, raj);
            Employee anna = new Employee("Anna", 95000, adam, null);
            Employee lucas = new Employee("Lucas", 100000, adam, anna);

            adam.SetNext(lucas);
            sarah.SetNext(marcus);

            // Initialize a promotion queue
            Queue promotionQueue = new Queue();

            List<Employee> emps = new List<Employee>{ sarah, adam, lucas, anna, raj, marcus };

            // Add employees to queue in order to be promoted
            foreach (Employee emp in emps)
            {
                promotionQueue.Enqueue(raj);
            }       

            // Greet the user
            Intro();

            // Control loop
            while (moreUserIteractions)
            {
                // Prompt user for input
                string userInput = Input();

                if (userInput == "FIND")
                {
                    // TODO: Binary Search for salary
                }
                else if (userInput == "VIEW")
                {
                    Console.WriteLine("Here is the list of employees:");
                    for (int i = 0; i < emps.Count; i++)
                    {
                        if (i == emps.Count - 1)
                        {
                            Console.Write(emps[i].GetName());
                        }
                        else
                        {
                            Console.Write($"{emps[i].GetName()}, ");
                        }
                    }
                    Console.WriteLine();
                }
                else if (userInput == "PROMOTE")
                {
                    // TODO: Leverage Employee.Promote()
                }
                else if (userInput == "HIERARCHY")
                {
                    Console.WriteLine("Which manager should I show the hierarchy for?");

                    string managerName = Console.ReadLine();

                    foreach (Employee emp in emps)
                    {
                        if (managerName == emp.GetName())
                        {
                            Employee temp = emp;
                            List<Employee> managedEmployees = new List<Employee>();

                            while (temp.GetNext() != null)
                            {
                                managedEmployees.Add(temp.GetNext());
                                temp = temp.GetNext();
                            }

                            Console.Write($"The employees managed by {emp.GetName()} include ");
                            for (int i = 0; i < managedEmployees.Count; i++)
                            {
                                if (i < managedEmployees.Count - 1)
                                {
                                    Console.Write($"{managedEmployees[i].GetName()}, ");
                                }
                                else
                                {
                                    Console.Write($"{managedEmployees[i].GetName()}.");
                                }
                            }
                        }
                    }

                }
                else if (userInput == "MANAGER")
                {
                    Console.WriteLine("Which employee should I show the manager of?");

                    string employeeName = Console.ReadLine();

                    foreach (Employee emp in emps)
                    {
                        if (emp.GetName() == employeeName)
                        {
                            Console.WriteLine($"The manager of {employeeName} " +
                                $"is {emp.GetManager().GetName()}");
                        }
                    }
                }
                else if (userInput == "HIRE")
                {
                    Console.WriteLine("What is the new employee's name?");

                    string empName = Console.ReadLine();

                    Console.WriteLine("What is the employee's starting salary?");

                    double empSalary = double.Parse(Console.ReadLine());

                    Console.Write("Who is the employee's manager? Options are: ");
                    foreach (Employee emp in emps)
                    {
                        if (emp.GetManager() == null)
                        {
                            Console.Write($"{emp.GetName()} ");
                        }
                    }
                    string managerName = Console.ReadLine();

                    Employee empManager = null;

                    foreach (Employee emp in emps)
                    {
                        if (emp.GetName() == managerName)
                        {
                            empManager = emp;
                        }
                        else
                        {
                            Console.WriteLine("Could not locate manager, employee has no manager");
                        }
                    }

                    // Create new employee
                    Employee newEmployee = new Employee(empName, empSalary, empManager, null);

                    Employee temp = empManager;
                    
                    List<Employee> managedEmployees = new List<Employee>();

                    while (temp.GetNext() != null)
                    {
                        managedEmployees.Add(temp.GetNext());
                        temp = temp.GetNext();
                    }

                    // Add pointer from the last employee under the same manager
                    // To the new employee so they are still discoverable
                    if (managedEmployees.Count > 0)
                    {
                        Employee lastEmployee = managedEmployees[managedEmployees.Count - 1];

                        for (int i = 0; i < emps.Count; i++)
                        {
                            if (emps[i].GetName() == lastEmployee.GetName())
                            {
                                emps[i].SetNext(newEmployee);
                            }
                        }
                    }

                    // Add new employee to roster, will be locatable via FIND
                    emps.Add(newEmployee);

                    // New employee will be promoted last
                    promotionQueue.Enqueue(newEmployee);

                }
                else
                {
                    Console.WriteLine("Please enter \"FIND\",  \"VIEW\", \"PROMOTE\", \"HIERARCHY\", \"HIRE\", or \"MANAGER\".");
                }
            }

        }

        static string Input()
        {
            string userInput = Console.ReadLine();

            return userInput;
        }

        static void Intro()
        {
            Console.WriteLine("Welcome to Macrohard Employee Database" +
                " \nWhat would you like to do?\n");
        }
    }

    // Employee class acts as linkedlist of employees
    class Employee
    {
        string name;
        double salary;
        Employee manager;
        Employee next;

        public Employee(string name, double salary, Employee manager, Employee next)
        {
            this.name = name;
            this.salary = salary;
            this.manager = manager;
            this.next = next;
        }

        public void Promote()
        {
            // Promotions are a set 5% raise

            this.salary = salary * 1.05;
        }

        public double GetSalary()
        {
            return this.salary;
        }

        public string GetName()
        {
            return this.name;
        }

        public Employee GetNext()
        {
            return this.next;
        }

        public void SetNext(Employee next)
        {
            this.next = next;
        }

        public Employee GetManager()
        {
            return this.manager;
        }
    }

    // node for the BST to use
    class Node
    {
        public int number;
        public Node left;
        public Node right;

        public Node(int value)
        {
            number = value;
            right = null;
            left = null;
        }
    }

    class BinarySearchTree
    {
        private Node root;
        private int count;

        // The Binary Search Tree is an efficient way to store
        // and filter the salaries
        public void BinaryTree()
        {
            root = null;
            count = 0;
        }

        public bool isEmpty()
        {
            return root == null;
        }

        public void insert(int d)
        {
            if (isEmpty())
            {
                root = new Node(d);
            }
            else
            {
                Console.WriteLine();
                // root.insertData(ref root, d);
            }

            count++;
        }

        public bool search(int s)
        {
            return false;
            //return root.search(root, s);
        }

        // TODO: Add methods to rearrange the BST if an employee is promoted
    }

    class Queue
    {
        List<Employee> employeeList;
        int size;
        public Queue()
        {
            employeeList = new List<Employee>();
            size = 0;
        }

        public void Enqueue(Employee emp)
        {
            employeeList.Add(emp);
            size++;

        }

        public Employee Dequeue()
        {
            Employee temp = employeeList[0];
            employeeList.RemoveAt(0);
            size--;
            return temp;
        }

        public int GetSize()
        {
            return size;
        }
    }
}