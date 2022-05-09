using studentsLabSQL.models;

namespace StudentDatabaseLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StudentsCrud sc = new StudentsCrud();
            Student s = new Student() { StudentName = "Meryl", HomeTown = "Juneao", FavoriteFood = "Plain White Rice" };
            StudentsContext context = new StudentsContext();

           
            

            
           

  

            while (true)
            {
                string[] studentName = { "Aaron", "Clyde", "Kelly", "Meryl", "Simon", "Rose", "Jack", "David", "Popeye" };
                string[] homeTown = { "Los Angeles, California", "Juneao, Alaska", "Duluth, Minnesota", "Akron, Ohio", "Talladega, Alabama", "Marfa, Texas", "Tombstone, Arizona", "Toronto, Ontario", "Victoria, Texas" };
                string[] favoriteFood = { "pizza", "cornbread", "plain white rice", "lasanga", "anything from Jimmy Johns", "salmon", "fish sticks", "ramen noodle soup", "canned spinach" };
                int navChoice;

                while (true)
                {
                    Console.WriteLine("Welcome to the Student Database. Would you like to begin by viewing a directory of all students or proceed to learning about our students? To view the directory, please type directory. To learn about students, please type database.");
                    string directoryOrDatabase = Console.ReadLine().ToLower().Trim();
                    Console.WriteLine();

                    if (directoryOrDatabase.Contains("dir"))
                    {
                        Console.WriteLine("All Students in our database:");

                        for (int i = 0; i < sc.GetStudent().Count; i++)
                        {
                            Console.WriteLine($"Student {i + 1}: {sc.GetStudent()[i].StudentName}");
                        }

                        Console.WriteLine();
                        Console.WriteLine($"Which student would you like to learn more about? Enter a number 1-{sc.GetStudent().Count}.");
                        int studentChoice = int.Parse(Console.ReadLine());

                        if (studentChoice <= 0 || studentChoice > sc.GetStudent().Count)
                        {
                            Console.WriteLine("Sorry, that is not a valid input. Please choose a number 1-9.");
                            Console.WriteLine();
                            continue;
                        }
                        else
                        {
                            navChoice = studentChoice - 1;
                            break;
                        }

                    }
                    else if (directoryOrDatabase.Contains("data"))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Which student would you like to learn more about? Enter a number 1-9.");
                        int studentChoice = int.Parse(Console.ReadLine());

                        if (studentChoice <= 0 || studentChoice > sc.GetStudent().Count+1)
                        {
                            Console.WriteLine("Sorry, that is not a valid input. Please choose a number 1-9.");
                            continue;
                        }
                        else
                        {
                            navChoice = studentChoice - 1;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that is not a valid input. Please enter directory or database");
                        continue;
                    }
                }

                while (true)
                {
                    Console.WriteLine($"You have chosen {sc.GetStudent()[navChoice].StudentName}. What would you like to know? Please enter hometown or favorite food. ");
                    string navigationChoice = Console.ReadLine().ToLower().Trim();

                    if (navigationChoice.Contains("town"))
                    {
                        Console.WriteLine($"{sc.GetStudent()[navChoice].StudentName} was born in {sc.GetStudent()[navChoice].HomeTown}.");
                        Console.WriteLine();
                        break;
                    }
                    else if (navigationChoice.Contains("food"))
                    {
                        Console.WriteLine($"{sc.GetStudent()[navChoice].StudentName}'s favorite food is {sc.GetStudent()[navChoice].FavoriteFood}.");
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, I didn't quite get that. Please choose hometown or favorite food.");
                        Console.WriteLine();
                        continue;
                    }

                    

                }

                while (true)
                {

                    try
                    {
                        Console.WriteLine("Would you like to add or remove a student from the database?");
                        Console.WriteLine("1. Add");
                        Console.WriteLine("2. Remove");
                        Console.WriteLine("3. No thanks");
                        int userAddorRemove = int.Parse(Console.ReadLine());

                        if (userAddorRemove == 1)
                        {
                            userAddStudent();
                            break;
                        }
                        else if (userAddorRemove == 2)
                        {
                            userRemoveStudent();
                            break;
                        }
                        else if (userAddorRemove == 3)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That was not a valid response. Please try again.");
                            continue;
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Sorry, that is not a valid entry. Please try again. ");
                    }
                }
               

                Console.WriteLine("Would you like to run the program again? Please enter y/n");
                string userContinue = Console.ReadLine().ToLower();

                if (userContinue == "y")
                {
                    continue;
                }
                else if (userContinue == "n")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("I'm sorry, I didn't quite get that. Please choose y/n");
                }
            }
        }

        public static void CreateStudent(Student c)
        {
            StudentsContext context = new StudentsContext();
            context.Add(c);
            context.SaveChanges();

        }

        public static void userAddStudent()
        {
            StudentsContext context = new StudentsContext();

            Console.WriteLine("What is the name of the student you would like to add?");
            string studentName = Console.ReadLine();

            Console.WriteLine("What is the home town of the student you would like to add");
            string studentHomeTown = Console.ReadLine();

            Console.WriteLine("What is the favorite food of the student you would like to add?");
            string studentfavoriteFood = Console.ReadLine();

            Student userAddStudent = new Student() { StudentName = studentName, HomeTown = studentHomeTown, FavoriteFood = studentfavoriteFood };
            context.Add(userAddStudent);
            context.SaveChanges();
        }

        public static void userRemoveStudent()
        {   int studentChoice;

            StudentsCrud sc = new StudentsCrud();
            Student s = new Student();
            int navChoice;
            while (true)
            {
                
                for (int i = 0; i < sc.GetStudent().Count; i++)
                {
                    Console.WriteLine($"Student {i + 1}: {sc.GetStudent()[i].StudentName}");
                }

                Console.WriteLine("Which Student would you like to remove from the database?");

                 studentChoice = int.Parse(Console.ReadLine());

                if (studentChoice <= 0 || studentChoice > sc.GetStudent().Count)
                {
                    Console.WriteLine($"Sorry, that is not a valid input. Please choose a number 1-{sc.GetStudent().Count}");
                    Console.WriteLine();
                    continue;
                }
                else
                {
                    navChoice = studentChoice - 1;
                    break;
                }
            }
            StudentsContext context = new StudentsContext();
            Student studentToRemove = new Student();
            studentToRemove = sc.GetStudent()[navChoice];
            context.Students.Remove(studentToRemove);
            context.SaveChanges();
        }


    }
}