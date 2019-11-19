// Andrew Means & Lucas Stoltman
// 18 Nov 2019
// _Organization_ Employee
// Purpose: Create an application to be used by a company to keep track of 
// and organize employees by their salaries, hierarchy, and order of promotion.
using System;

namespace MeansStoltman_MajorAssignment3
{
    class Employees
    {
        static void Main(string[] args)
        {
            bool moreUserIteractions = true;

            // Greet the user
            Intro();

            // Control loop
            while (moreUserIteractions)
            {
                // Prompt user for input
                string userInput = Console.ReadLine();

                // TODO: Add the following user input options

                // FIND / VIEW / PROMOTE / HIERARCHY / MANAGER

                // FIND
                // Recursively traverse the binary search tree for the employee
                // with a matching salary

                // VIEW
                // Traverse the linkedlist and print out the employees

                // For promotions, the employees are promoted based on merit
                // and the order of promotion is reflected in a queue
                // after a promotion we add the promotee to the end of the queue
                // for promotion next cycle



            }

        }

        static void Intro()
        {
            // TODO: Decide on an organization name
            Console.WriteLine("Welcome to _Organization_ Employee Database");
        }

    }

    class Employee
    {
        string name;
        double salary;
        Employee manager;
        LinkedList employees;

        public Employee(string name, double salary, Employee manager, LinkedList employees)
        {
            this.name = name;
            this.salary = salary;
            this.manager = manager;
            this.employees = employees;
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
    }

    class BinarySearchTree
    {
        // The Binary Search Tree is an efficient way to store
        // and filter the salaries
        public BinarySearchTree()
        {
            // TODO: fill in constructor
        }

        // TODO: Add methods to rearrange the BST if an employee is promoted
    }

    // We may be able to use the .NET built-in Queue & LinkedList classes
    class LinkedList
    {
        // TODO: add variables

        public LinkedList()
        {
            // TODO: fill in constructor
        }

        // TODO: add first/last methods
        // TODO: add addLast methods
    }
}
