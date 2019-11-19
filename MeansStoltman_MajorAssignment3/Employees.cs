// Andrew Means & Lucas Stoltman
// 18 Nov 2019
// Macrohard Employee
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

            // TODO populate the data structures to traverse

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
            Console.WriteLine("Welcome to Macrohard Employee Database" +
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
                root.insertData(ref root, d);
            }

            count++;
        }

        public bool search(int s)
        {
            return root.search(root, s);
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