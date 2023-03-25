
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repoConsoleApp
{
    public class ProgramUI
    {
        private readonly DeliveryRepo _DelRepo = new DeliveryRepo();
        
        public void Run()
        {
            Menu();
        }
        
        private void Menu()
        {
            seed();
            
            bool keepRunningProgram = true;
            while(keepRunningProgram)
            {   
                Console.Clear();
                System.Console.WriteLine("Welcome to the Warner Transit Federal delivery tracking system!\n" +
                "How can we assist you today?\n" +
                "1. Show all deliveries\n" +
                "2. Find a delivery\n" +
                "3. Add a delivery\n" +
                "4. Update a delivery\n" +
                "5. Remove a delivery\n" +
                "6. Exit\n"
                );

                string firstMenuSelect = Console.ReadLine();
                switch (firstMenuSelect)
                {
                    case "1":
                        DisplayAllDeliveries();
                        continueButton();
                        break;

                    case "2":
                        bool RunningFindDel = true;
                        while (RunningFindDel)
                        {
                            Console.Clear();
                            System.Console.WriteLine("How would you like to find a delivery?\n" +
                            "1. Find by delivery ID\n" +
                            "2. Find all scheduled \n" +
                            "3. Find all enroute \n" +
                            "4. Find all completed \n" +
                            "5. Find all canceled \n" +
                            "6. Exit \n"
                            );
                            string InputToMenu = Console.ReadLine();
                            switch (InputToMenu)
                            {
                                case "1":
                                    FindDelByID();
                                    break;
                                
                                case "2":
                                    ScheduledDels();
                                    break;

                                case "3":
                                    EnRouteDels();
                                    break;

                                case "4":
                                    CompletedDels();
                                    break;

                                case "5":
                                    CanceledDels();
                                    break;

                                case "6":
                                    RunningFindDel = false;
                                    Console.Clear();
                                    break;

                                default:
                                    System.Console.WriteLine("Please type a valid number");
                                    continueButton();
                                    break;
                            }
                        }
                        break;

                    case "3":
                        NewDelivery();
                        break;

                    case "4":
                        UpdateDelivery();
                        break;

                    case "5":
                        RemoveDelivery();
                        break;              

                    case "6":
                        System.Console.WriteLine("Have a nice day!");
                        continueButton();
                        keepRunningProgram = false;
                        break;
                    
                    default:
                        System.Console.WriteLine("Please type a valid number");
                        continueButton();
                        break;
                }
            }

        }

        public void continueButton()
        {
            System.Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
        
        public void NewDelivery()
        {
            Console.Clear();
            Delivery newDel = new Delivery();
            System.Console.WriteLine("Enter a delivery ID: ");
            string inputDelIDString = Console.ReadLine();
            newDel.DelID = int.Parse(GetValidStringInput(inputDelIDString));
            

            Console.Clear();
            System.Console.WriteLine("Enter a delivery date (MM/DD/YYYY): ");
            DateTime inputDelDate = DateTime.Parse(Console.ReadLine());
            newDel.DelDate = inputDelDate;

            Console.Clear();
            System.Console.WriteLine("Enter a delivery status (1, 2, 3, or 4): \n" + 
            "1. Scheduled\n" +
            "2. EnRoute\n" +
            "3. Completed\n" +
            "4. Canceled");
            string inputDelStatString = Console.ReadLine();
            int inputDelStatInt = int.Parse(GetValidStringInput(inputDelStatString)); 
            newDel.DelStat = (DelStatus)inputDelStatInt;
            

            Console.Clear();
            System.Console.WriteLine("Enter item ID: ");
            string inputItemIDString = Console.ReadLine();
            GetValidStringInput(inputItemIDString);
            int inputItemIDInt = int.Parse(inputItemIDString);
            newDel.ItemID = inputItemIDInt;

            Console.Clear();
            System.Console.WriteLine("Enter quantity being delivered: ");
            string inputItemQtyString = Console.ReadLine();
            GetValidStringInput(inputItemQtyString);
            int inputItemQtyInt = int.Parse(inputItemQtyString);
            newDel.ItemQuantity = inputItemQtyInt;

            Console.Clear();
            System.Console.WriteLine("Enter customer ID: ");
            string inputCusIDString = Console.ReadLine();
            int inputCusIDInt = int.Parse(GetValidStringInput(inputCusIDString));
            newDel.CustomerID = inputCusIDInt;

            _DelRepo.AddDelivery(newDel);
            Console.Clear();



        }

        public string GetValidStringInput(string InputDelID)
        {
            
            while(string.IsNullOrEmpty(InputDelID))
            {
                System.Console.WriteLine("Please enter a valid number: ");
                InputDelID = Console.ReadLine();
                
                if(string.IsNullOrEmpty(InputDelID))
                {
                    System.Console.WriteLine("Cannot enter a blank input");
                    continueButton();
                } 
            }
            return InputDelID;
        }

        public void DisplayDelivery(Delivery delivery)
        {
            System.Console.WriteLine($"Delivery ID: {delivery.DelID}\n" +
                    $"Date of delivery: {delivery.DelDate}\n" +
                    $"Status: {delivery.DelStat}\n" +
                    $"Item ID: {delivery.ItemID}\n" +
                    $"Item Quantity: {delivery.ItemQuantity}\n" +
                    $"Customer ID: {delivery.CustomerID}\n" );
        }

        public void DisplayAllDeliveries()
        {
            Console.Clear();
            List<Delivery> allDeliveries = _DelRepo.GetAllDeliveries();

            foreach (Delivery delivery in allDeliveries)
            {
                DisplayDelivery(delivery);
            }
        }

        public void UpdateDelivery()
        {
            Console.Clear();
            DisplayAllDeliveries();
            System.Console.WriteLine("Type the ID of the delivery you wish to update: ");
            int oldDelIDParsed = int.Parse(GetValidStringInput(Console.ReadLine()));
            Delivery delivery = _DelRepo.FindDelByID(oldDelIDParsed);
            Console.Clear();
            System.Console.WriteLine("What would you like to change?\n" +
            "1. Delivery ID \n" +
            "2. Delivery Date \n" +
            "3. Delivery Status \n" +
            "4. Item ID \n" +
            "5. Item Quantity \n" +
            "6. Customer ID \n" +
            "7. Cancel Changes \n" +
            "\n" +
            "If and after status is selected to update, choose a number:\n" +
            "1. Scheduled \n" +
            "2. EnRoute \n" +
            "3. Completed \n" +
            "4. Canceled \n"
            );

            string propertyToUpdate = GetValidStringInput(Console.ReadLine());
            if (propertyToUpdate != "7")
            {
                System.Console.WriteLine("What is the updated information?");
                string updatedProperty = GetValidStringInput(Console.ReadLine());
                switch (propertyToUpdate)
                {
                    case "1":
                        delivery.DelID = int.Parse(updatedProperty);
                        break;
                    case "2":
                        delivery.DelDate = DateTime.Parse(updatedProperty);
                        break;
                    case "3":
                        delivery.DelStat = (DelStatus) int.Parse(updatedProperty);
                        break;
                    case "4":
                        delivery.ItemID = int.Parse(updatedProperty);
                        break;
                    case "5":
                        delivery.ItemQuantity = int.Parse(updatedProperty);
                        break;
                    case "6":
                        delivery.CustomerID = int.Parse(updatedProperty);
                        break;
                    Default:
                            System.Console.WriteLine("Please type a valid number");
                            continueButton();
                            break;
                }

            }
        }

        public void RemoveDelivery()
        {
            Console.Clear();
            DisplayAllDeliveries();
            System.Console.WriteLine("Type the ID of the delivery you wish to remove from the system: ");
            int DelIDParsed = int.Parse(Console.ReadLine());
            bool wasRemoved = _DelRepo.DeleteDelivery(DelIDParsed);

            if (wasRemoved)
            {System.Console.WriteLine("Deletion Successful");}
            else {System.Console.WriteLine("Deletion Failed");}
            continueButton();
            Console.Clear();
        }
    
        public void FindDelByID()
        {
            Console.Clear();
            System.Console.WriteLine("Enter delivery ID: \n");
            int inputIDInt = int.Parse(GetValidStringInput(Console.ReadLine()));
            Delivery delivery = _DelRepo.FindDelByID(inputIDInt);
            if (delivery == default)
            {
                System.Console.WriteLine("Delivery could not be found");
            }
            else {DisplayDelivery(delivery);}
            continueButton();
        }

        public void ScheduledDels()
        {
            continueButton();
            System.Console.WriteLine("Scheduled deliveries");
            foreach (Delivery delivery in _DelRepo._deliveryList)
            {
                if (delivery.DelStat == DelStatus.Scheduled)
                {
                    DisplayDelivery(delivery);
                }
            }
            continueButton();
        }

        public void EnRouteDels()
        {
            continueButton();
            System.Console.WriteLine("EnRoute deliveries");
            foreach (Delivery delivery in _DelRepo._deliveryList)
            {
                if (delivery.DelStat == DelStatus.EnRoute)
                {
                    DisplayDelivery(delivery);
                }
            }
            continueButton();
        }

        public void CompletedDels()
        {
            continueButton();
            System.Console.WriteLine("Completed deliveries");
            foreach (Delivery delivery in _DelRepo._deliveryList)
            {
                if (delivery.DelStat == DelStatus.Complete)
                {
                    DisplayDelivery(delivery);
                }
            }
            continueButton();
        }

        public void CanceledDels()
        {
            continueButton();
            System.Console.WriteLine("Canceled deliveries");
            foreach (Delivery delivery in _DelRepo._deliveryList)
            {
                if (delivery.DelStat == DelStatus.Canceled)
                {
                    DisplayDelivery(delivery);
                }
            }
            continueButton();
        }

        public void seed()
        {
            Delivery delOne = new Delivery(1234, new DateTime(2023, 03, 25), DelStatus.EnRoute, 1234, 10, 123456);
            _DelRepo.AddDelivery(delOne);

            Delivery delTwo = new Delivery(5678, new DateTime(2024, 03, 25), DelStatus.Scheduled, 1234, 10, 789012);
            _DelRepo.AddDelivery(delTwo);
        }
    }
}