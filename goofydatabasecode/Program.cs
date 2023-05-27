string[,] databaseList = new string[10, 10]; // databaseList of all users
string[,] LogIn = new string[2, 2]; // Once user has logged in, their account information is stored in here
int Count = 0; // used ONLY for registering AND deleting accounts to know how many are in databaseList
bool loggedIn = false; // Simply used to identify if user is logged in
bool loopCheck = false; // Used in logining in so it doesnt print already "logged in" AFTER successfully logging in
bool noDupe = true;
databaseList[0, 0] = "admin"; // testing account
databaseList[0, 1] = "1234"; // testing account

while (true)
{
    noDupe = true;


    while (loggedIn == false)
    {
        Console.Write("1 - REGISTER . 2 - LOGIN: ");
        int selectionChoice = Convert.ToInt32(Console.ReadLine());



        if (selectionChoice == 1 && loggedIn == false) // START of REGISTER code
        {
            Console.WriteLine("Enter username");
            string tempUserName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string tempPassword = Console.ReadLine();
            string countString = Count.ToString();

            for (int i = 0; i < databaseList.GetLength(0); i++)
            {
                if (databaseList[i, 0] == tempUserName)
                {
                    noDupe = false;
                    Console.WriteLine("Username taken");
                }

            }

            if (noDupe == true)
            {
                databaseList[Count, 0] = tempUserName;
                databaseList[Count, 1] = tempPassword;
                LogIn[0, 0] = databaseList[Count, 0];
                LogIn[0, 1] = databaseList[Count, 1];
                Count = Count + 1;
                loggedIn = true;
            }

        }                                              // END of REGISTER code

        if (selectionChoice == 2 && loggedIn == false) // START of LOGIN code
        {
            Console.WriteLine("Enter your username: ");
            string tempUserName = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string tempPassword = Console.ReadLine();

            for (int i = 0; i < databaseList.GetLength(0); i++) // simple for loop using databaseList.getlength(0), 0 being the collumn since it is a 2d array.
            {
                if (tempUserName == databaseList[i, 0] && tempPassword == databaseList[i, 1])
                {
                    loggedIn = true;
                    loopCheck = true;
                    LogIn[0, 0] = databaseList[i, 0];
                    LogIn[0, 1] = databaseList[i, 1];
                    Console.WriteLine("Login successful");
                }
            }


            if (selectionChoice == 2 && loggedIn == false)
            {
                Console.WriteLine("Incorrect login");
                LogIn[0, 0] = "";
            }
            if (loggedIn && loopCheck == false)
            {
                Console.WriteLine("You are already logged in.");
            }
        }                                           // END of LOGIN code




    }
    while (loggedIn == true)
    {
        string user = LogIn[0, 0];
        Console.WriteLine("Welcome {0} ", user);
        Console.Write("3 - DELETE ACCOUNT . 4 - VIEW ACCOUNT . 5 - LOG OUT: ");
        `       int selectionChoice = Convert.ToInt32(Console.ReadLine());


        if (selectionChoice == 3)                   // START of DELETE ACCOUNT code wiktor wrote this code
        {
            for (int i = 0; i < databaseList.GetLength(0); i++) // simple for loop using databaseList.getlength(0), 0 being the collumn since it is a 2d array.
            {
                if (LogIn[0, 0] == databaseList[i, 0] && LogIn[0, 1] == databaseList[i, 1])
                {
                    LogIn[0, 0] = "";
                    databaseList[i, 0] = "";
                    LogIn[0, 1] = "";
                    databaseList[i, 1] = "";
                    loggedIn = false;
                    Count = Count - 1;
                }
            }
        }                                           // END of DELETE ACCOUNT code

        if (selectionChoice == 4 && loggedIn)       // START of PRINT LOGIN INFORMATION code
        {
            foreach (string word in LogIn) // a foreach loop is different from a for loop, this uses strings and "word" is any string inside of LogIn, as it iteraties through
            {
                Console.WriteLine("{0}", word); // prints out every string in LogIn (it only holds the user's signed in information)
            }
            if (loggedIn == false)
            {
                Console.WriteLine("You are not logged in!");
            }
        } // END of PRINT LOGIN INFORMATION code


        if (selectionChoice == 5 && loggedIn)                  // START of LOGOUT code
        {
            loggedIn = false;
            LogIn[0, 0] = "";
            LogIn[0, 0] = "";
            if (selectionChoice == 5 && loggedIn == false)
            {
                Console.WriteLine("You are not logged in!");
            }
        }                                                     // END of LOGOUT code

    }
}
