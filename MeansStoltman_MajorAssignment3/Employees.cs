// Andrew Means & Lucas Stoltman
// 18 Nov 2019
// Macrosoft Employee
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
                Input();
            }

        }

        static void Intro()
        {
            Console.WriteLine("Welcome to Macrosoft Employee Database" +
                " \nWhat would you like to do?");
        }

        static void Input()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                // FIND
                // Recursively traverse the binary search tree for the employee
                // with a matching salary
                case "FIND":
                    //stuff
                    break;

                // VIEW
                // Traverse the linkedlist and print out the employees
                case "VIEW":
                    //stuff
                    break;

                // For promotions, the employees are promoted based on merit
                // and the order of promotion is reflected in a queue
                // after a promotion we add the promotee to the end of the queue
                // for promotion next cycle
                case "PROMOTE":
                    //stuff
                    break;

                case "HIERARCHY":
                    //stuff
                    break;

                case "MANAGER":
                    //stuff
                    break;

                default:
                    Console.WriteLine("Please enter \"FIND\",  \"VIEW\", \"PROMOTE\", \"HIERARCHY\", or \"MANAGER\".");
                    Input();
                    break;
            }
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

    // nodes for the BST to use
    class Node
    {
        public int value;
        public Node left;
        public Node right;
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
