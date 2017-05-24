using System;
using System.Collections.Generic;
using System.Linq;

namespace HW2BigBankInc
{
    class Bank
    {
            public static int count=0;

            public static int accountSavings=90123400;
            public static int accountChecking=20137800;
            public static string clientName {get; set;}
            
            protected double balance{ get; set;}
            protected double sabalance{ get; set;}
            protected double chbalance{ get; set;}
       
    }

    class Customer:Deposit  // Bank
    {
        public static int totalAccounts=0; // provides the total accounts owned by that individual
        int myCheckingAcct;
        int mySavingsAcct;
        
        public Customer(string accountOwner)
        {
            clientName = accountOwner;
        }
        public string sayCustomer()
        {
            return  clientName;
        }
        public void greetClient()
        {
            Console.WriteLine("Welcome {0}", clientName);
        }
        public void newChecking()
        {
            Bank.count++; // increments the grand total of all accounts in bank
            totalAccounts++; //total accounts for this customer
            Bank.accountChecking = Bank.accountChecking++;
            myCheckingAcct = Bank.accountChecking;
            Console.WriteLine("Your checking account has been created. The account number is {0}",myCheckingAcct);
        }
        public int TheNewChecking()
        {
            return myCheckingAcct;
        }
        public void newCheckingProcess()
        {
            Console.WriteLine("Please state the amount you wish to deposit in your checking.");
            plusMoney =Convert.ToDouble (Console.ReadLine());
            checkingBalance();
            printChBalance();
        }
        public void newSavings()
        {
            Bank.count++;
            totalAccounts++;//total accounts for this customer
            Bank.accountSavings = Bank.accountSavings++;
            mySavingsAcct = Bank.accountSavings;
            Console.WriteLine("Your savings account has been created. The account number is {0}",mySavingsAcct);
        }
        public int TheNewSavings()
        {
            return mySavingsAcct;
        }
        public void newSavingsProcess()
        {
            Console.WriteLine("Please state the amount you wish to deposit in your savings.");
            plusMoney =Convert.ToDouble (Console.ReadLine());
            savingsBalance();
            printSaBalance();
        }        
    }



    class Deposit: Bank 
    { // check to enter no negative amount
        public static double currentAmount;
        public static double plusMoney;
        double newSave=0;
        double gain=0;

        public double savingsBalance()
        {
            this.sabalance = currentAmount;
            this.sabalance +=plusMoney;
            gain = this.sabalance *0.015;
            newSave = gain + this.sabalance;
            return newSave;
        }
        public double checkingBalance()
        {
            this.chbalance = currentAmount;
            return this.chbalance += plusMoney;
        }
        public double Balance()
        {
            this.balance =newSave + this.chbalance; //for grand total
            return this.balance;
        }
        public void printBalance()
        {
            Console.WriteLine("Your new balance is ${0}",this.balance);
        }
        public void printSaBalance()
        {
            Console.WriteLine("The new balance of your savings is ${0}",newSave);
            Console.WriteLine("Your savings reflect an interest rate gain of 1.5%");
        }
        public void printChBalance()
        {
            Console.WriteLine("The new balance of your checking is ${0}",this.chbalance);
        }

    }

    class Withdraw: Bank
    { //check to verify no negative amount to enter

        public static double currentAmount;
        public static double minusMoney;
        double newSave=0;
        double gain=0;

        public double savingsBalance()
        {
            this.sabalance = currentAmount;
            this.sabalance -=minusMoney;
            gain = this.sabalance *0.015;
            newSave = gain + this.sabalance;
            return newSave;
        }
        public double checkingBalance()
        {
            this.chbalance = currentAmount;
            return this.chbalance -= minusMoney;
        }
        public double Balance()
        {
            this.balance =newSave - this.chbalance; //for grand total
            return this.balance;
        }
        public void printBalance()
        {
            Console.WriteLine("Your new balance is ${0}",this.balance);
        }
        public void printSaBalance()
        {
            Console.WriteLine("The new balance of your savings is ${0}",newSave);
            Console.WriteLine("Your savings reflect an interest rate gain of 1.5%");
        }
        public void printChBalance()
        {
            Console.WriteLine("The new balance of your checking is ${0}",this.chbalance);
        }

    }


    class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("*******************");
            Console.WriteLine("Welcome to Big Bank Inc.");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("1 - Create an account");
            Console.WriteLine("2 - Make a deposit");
            Console.WriteLine("3 - Withdraw Funds");
            Console.WriteLine("4 - Close an account");
            Console.WriteLine("5 - Quit");
            Console.WriteLine("*******************");
        }

        static void AccountsMenu()
        {
            // Console.WriteLine("Welcome to Big Bank Inc.");
            Console.WriteLine("Which account would you like to open.");
            Console.WriteLine("A - Checking Account");
            Console.WriteLine("B - Savings Account");
        }
        

        static void AcctHeadingMenu()
        {
            Console.WriteLine();
            Console.WriteLine("*******************");
            Console.WriteLine("Welcome to Big Bank Inc.");
        }
        
        static void AcctFooterMenu()
        {
            Console.WriteLine();
            Console.WriteLine("*******************");
        }

        static void AcctTypeMenu()
        {
            Console.WriteLine("i - Checking Account");
            Console.WriteLine("ii - Savings Account");
        }

        static void DepositSavings()
        {
            Console.WriteLine();
            Deposit.currentAmount=43000; //demo amount
            Console.WriteLine("Please state the amount you wish to deposit in your savings.");
            Deposit.plusMoney =Convert.ToDouble (Console.ReadLine());
            while(Deposit.plusMoney<=0)
            {
                Console.WriteLine();
                Console.WriteLine("You requested to deposit the total amount of ${0}.",Deposit.plusMoney );
                Console.WriteLine("You cannot deposit a negative amount.");
                Console.WriteLine("Please state the amount you wish to deposit in your savings.");
                Deposit.plusMoney =Convert.ToDouble (Console.ReadLine());
            }
            Console.WriteLine("The orginal amount in your savings was ${0}",Deposit.currentAmount);

            Deposit addSavings = new Deposit();
            addSavings.savingsBalance();
            addSavings.printSaBalance();
            // need to format string for currency
        }

        static void WithdrawSavings()
        {
            Console.WriteLine("You have choosen to withdraw funds from your savings account.");
            Withdraw.currentAmount=43000;
            Console.WriteLine("As of today your current balance is ${0}",Withdraw.currentAmount);
            Console.WriteLine("How much funds in your savings do you wish to withdrawal?");
            Withdraw.minusMoney =Convert.ToDouble (Console.ReadLine());

            while((Withdraw.minusMoney >Withdraw.currentAmount)||(Withdraw.minusMoney <0))
            {
                Console.WriteLine();
                Console.WriteLine("You requested the total amount of ${0}.",Withdraw.minusMoney );
                Console.WriteLine("That amount exceeds your current balance or aount specify is negative.");
                Console.WriteLine("How much funds in your checking do you wish to withdrawal?");
                Withdraw.minusMoney =Convert.ToDouble (Console.ReadLine());
            }
            Console.WriteLine("You requested the total amount of ${0}",Withdraw.minusMoney );
            if(Withdraw.minusMoney >10000)
            {
                Console.WriteLine("A certified check is available for pickup at your local branch in the amount of ${0}",Withdraw.minusMoney);
                Withdraw minusSavings = new Withdraw();
                minusSavings.savingsBalance();
                minusSavings.printSaBalance();
            }
            else
            {
                Withdraw minusSavings = new Withdraw();
                minusSavings.savingsBalance();
                minusSavings.printSaBalance();
            }

        }

        static void DepositChecking()
        {
            // Console.WriteLine();
            // Deposit.currentAmount=2550;
            Console.WriteLine("Please state the amount you wish to deposit in your checking.");
            Deposit.plusMoney =Convert.ToDouble (Console.ReadLine());
            while(Deposit.plusMoney<=0)
            {
                Console.WriteLine();
                Console.WriteLine("You requested to deposit the total amount of ${0}.",Deposit.plusMoney );
                Console.WriteLine("You cannot deposit a negative amount.");
                Console.WriteLine("Please state the amount you wish to deposit in your checking.");
                Deposit.plusMoney =Convert.ToDouble (Console.ReadLine());
            }
            Console.WriteLine("The orginal checking amount was ${0}",Deposit.currentAmount);
            Console.WriteLine("You made a deposit in the amount of ${0}",Deposit.plusMoney);
            Deposit addChecking = new Deposit();
            addChecking.checkingBalance();
            addChecking.printChBalance();
            // need to format string for currency
        }
        static void WithdrawChecking()
        {
            Console.WriteLine("You have choosen to withdraw funds from your checking account.");
            Withdraw.currentAmount=2550;//demo amount
            Console.WriteLine("As of today your current balance is ${0}",Withdraw.currentAmount);
            Console.WriteLine("How much funds in your checking do you wish to withdrawal?");
            Withdraw.minusMoney =Convert.ToDouble (Console.ReadLine());
            
            while((Withdraw.minusMoney >Withdraw.currentAmount)||(Withdraw.minusMoney <0))
            {
                Console.WriteLine();
                Console.WriteLine("You requested the total amount of ${0}.",Withdraw.minusMoney );
                Console.WriteLine("That amount either exceeds your current balance or is a negative value.");
                Console.WriteLine("How much funds in your checking do you wish to withdrawal?");
                Withdraw.minusMoney =Convert.ToDouble (Console.ReadLine());
            }

            Console.WriteLine("You requested the total amount of ${0}",Withdraw.minusMoney );
            Withdraw minusChecking = new Withdraw();
            minusChecking.checkingBalance();
            minusChecking.printChBalance();
        }
        

        static void Main(string[] args)
        {

            int choice;
            string choice2;
            string choice3;
            string  YaName;
            int ChkAcct;
            int SavAcct;
            string theCustomer;
            int AccountNum;

            do
            {
                ShowMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                

                switch (choice)
                {
                    
                    case 1: // Create a new account
                    {
                        AcctHeadingMenu();
                        Console.WriteLine("You have choosen to create an Account.");
                        AccountsMenu();

                        AcctFooterMenu();
                        choice2 = Console.ReadLine().ToLower();
                        if (choice2 == "a")
                        {
                            AcctHeadingMenu();
                            Console.WriteLine("You have choosen to create a Checking Account.");
                            Dictionary<int,string> NewCheckingAcct =new Dictionary<int,string>();
                            Console.WriteLine("Please state your name.");

                            YaName = Console.ReadLine();
                            Customer ChkClient = new Customer(YaName);
                            Console.WriteLine();
                            ChkClient.greetClient(); 
                            ChkClient.newChecking();
                            
                            Bank.count++; // increments the total bank accounts number each time it is created
                            Bank.accountChecking++;// increments the account number each time it is created, not repeated
                            Console.WriteLine("You are required to make a deposit.");
                            Console.WriteLine();
                            Deposit.currentAmount=0;
                            ChkClient.newCheckingProcess();

                            theCustomer =ChkClient.sayCustomer();
                            AccountNum = ChkClient.TheNewChecking();
                            NewCheckingAcct.Add(AccountNum,theCustomer);

                            AcctFooterMenu();
                            Console.WriteLine("Press the entry key to return to main menu.");
                            Console.ReadLine(); // can be commented out but purpose is to pause
                            // until user type anything and then return to main menu, give user enough time to read output
                            break;
                            
                        }
                        else if( choice2 =="b")
                        {
                            AcctHeadingMenu();
                            Console.WriteLine("You have choosen to create a Savings Account.");
                            Dictionary<int,string> NewSavingsAcct =new Dictionary<int,string>();
                            Console.WriteLine("Please state your name.");

                            YaName = Console.ReadLine();
                            Customer SavClient = new Customer(YaName);
                            Console.WriteLine();
                            SavClient.greetClient(); 
                            SavClient.newSavings();
                            
                            Bank.count++; // increments the total bank accounts number each time it is created
                            Bank.accountSavings++;// increments the account number each time it is created, not repeated
                            Console.WriteLine("You are required to make a deposit.");
                            Console.WriteLine();
                            Deposit.currentAmount=0;
                            SavClient.newSavingsProcess();


                            theCustomer =SavClient.sayCustomer();
                            AccountNum = SavClient.TheNewSavings();
                            NewSavingsAcct.Add(AccountNum,theCustomer);

                            AcctFooterMenu();
                            Console.WriteLine("Press the enter key to return to main menu.");
                            Console.ReadLine(); // can be commented out but purpose is to pause
                            // until user type anything and then return to main menu, give user enough time to read output
                            break;
                        }
                        else
                        {
                            AcctHeadingMenu();
                            Console.WriteLine("You have choosen an invalid choice for creating an account!");
                            AcctFooterMenu();
                            break;
                        }

                    }//end case 1 of creating new account

                    case 2: //Make a deposit
                    {
                        AcctHeadingMenu();
                        Console.WriteLine(" You have choosen to make a deposit.");
                        Console.WriteLine(" Please specify an account type you wish to make your deposit.");
                        AcctTypeMenu();
                        choice3 = Console.ReadLine().ToLower();
                        if (choice3 == "i") // choice to deposit in checking
                        {
                            Console.WriteLine();
                            Deposit.currentAmount=2550; //temporary for demo
                            DepositChecking();
                            AcctFooterMenu();
                            Console.WriteLine("Press the enter key to return to main menu.");
                            Console.ReadLine(); // can be commented out but purpose is to pause
                            // until user type anything and then return to main menu, give user enough time to read output
                            break;
                        }
                        else if(choice3=="ii")// choice to deposit in savings
                        {
                            DepositSavings();
                            AcctFooterMenu();
                            Console.WriteLine("Press the enter key to return to main menu.");
                            Console.ReadLine(); // can be commented out but purpose is to pause
                            // until user type anything and then return to main menu, give user enough time to read output
                            break;
                        }
                        else
                        {
                            AcctHeadingMenu();
                            Console.WriteLine("You have choosen an invalid choice for making a deposit!");
                            AcctFooterMenu();
                            break;
                        }

                    }// end case 2 for making a deposit

                    case 3: // Make a withdraw
                    {
                        AcctHeadingMenu();
                        Console.WriteLine("You have choosen to withdraw funds.");
                        Console.WriteLine("Specify which account you wish to withdraw.");
                        AcctTypeMenu();
                        choice3 = Console.ReadLine().ToLower();
                        if (choice3 == "i") // choice to withdraw from checking
                        {
                            AcctHeadingMenu();
                            WithdrawChecking();
                            AcctFooterMenu();
                            Console.WriteLine("Press the enter key to return to main menu.");
                            Console.ReadLine(); // can be commented out but purpose is to pause
                            // until user type anything and then return to main menu, give user enough time to read output
                            break;
                        }
                        else if (choice3 == "ii") // choice to withdraw from savings
                        {
                            AcctHeadingMenu();
                            WithdrawSavings();
                            AcctFooterMenu();
                            Console.WriteLine("Press the enter key to return to main menu.");
                            Console.ReadLine(); // can be commented out but purpose is to pause
                            // until user type anything and then return to main menu, give user enough time to read output
                            break;
                        }
                        else
                        {
                            AcctHeadingMenu();
                            Console.WriteLine("You have choosen an invalid choice for withdrawing funds!");
                            AcctFooterMenu();
                            break;
                        }
                    }// ends case 3 for withdraws

                    case 4: // Closing or Removing an account
                    {
                        AcctHeadingMenu();
                        Console.WriteLine("Which account you wish to close your account.");
                        AcctTypeMenu();
                        choice3 = Console.ReadLine().ToLower();
                        if (choice3 == "i") // choice to close checking account
                        {
                            Dictionary<int,string> NewCheckingAcct =new Dictionary<int,string>();
                            Console.WriteLine("Please state your name.");

                            YaName = Console.ReadLine();
                            Customer ChkClient = new Customer(YaName);
                            Console.WriteLine();
                            Console.WriteLine("{0}, you have choosen to close your checking account.", YaName);
                            
                            Console.WriteLine("Please type in your account number.");
                            ChkAcct =Convert.ToInt32(Console.ReadLine()); // register account # customer typed in

                            if (NewCheckingAcct.ContainsValue(YaName))
                            {
                                Console.WriteLine("Your account {0} has been founded and will be close.", ChkAcct); // True.
                                NewCheckingAcct.Remove(ChkAcct);
                            }
                            else
                            {
                                Console.WriteLine("Your account was not found, you will be redirected to the main menu.");
                            }

                            AcctFooterMenu();
                            Console.WriteLine("Press the enter key to return to main menu.");
                            Console.ReadLine(); // can be commented out but purpose is to pause
                            // until user type anything and then return to main menu, give user enough time to read output
                            break;
                        }
                        else if (choice3 == "ii") // choice to close savings account
                        {

                            Dictionary<int,string> NewSavingsAcct =new Dictionary<int,string>();
                            Console.WriteLine("Please state your name.");

                            YaName = Console.ReadLine();
                            Customer SavClient= new Customer(YaName);
                            Console.WriteLine();
                            Console.WriteLine("{0}, you have choosen to close your savings account.", YaName);
                            
                            Console.WriteLine("Please type in your account number.");
                            SavAcct=Convert.ToInt32(Console.ReadLine()); // register account # customer typed in

                            if (NewSavingsAcct.ContainsValue(YaName))
                            {
                                Console.WriteLine("Your account {0} has been founded and will be close.", SavAcct); // True.
                                NewSavingsAcct.Remove(SavAcct);
                                Console.WriteLine("A cashier's check will be pprovided for your balance.");
                            }
                            else
                            {
                                Console.WriteLine("Your account was not found, you will be redirected to the main menu.");
                            }

                            // state amount that is being withdrawn
                            AcctFooterMenu();
                            Console.WriteLine("Press the enter key to return to main menu.");
                            Console.ReadLine(); // can be commented out but purpose is to pause
                            // until user type anything and then return to main menu, give user enough time to read output
                            break;
                        }
                        else
                        {
                            AcctHeadingMenu();
                            Console.WriteLine("You have choosen an invalid choice for closing an account!");
                            AcctFooterMenu();
                            break;
                        }
                    }//ends bank account removal 

                    case 5: // Most like will not printout this, for test
                    Console.WriteLine("Bye. We enjoyed your business.");
                    break;
                    default:
                    throw new Exception(String.Format("Unknown state: {0}", choice));

                }// end switch statement
            }// end do while loop
            while (choice != 5);
        }// ends static void Main(string[] args)
    }// ends class Program
}// ends namespace HW2BigBankInc
