using BusinessLayer;
using BusinessLayer.Auth;
using DomainLayer.Models;
using System;
using BusinessLayer.Library;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        /// <summary>
        /// Exectution starts from here
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IAuthentication obj = BALFactory.GetAuthenticationObject();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
        AuthenticationPage:

            Console.WriteLine("Enter Admin Mail id");
            string adminid = Console.ReadLine();


            Console.WriteLine("Enter Admin Password");
            string pwd = Console.ReadLine();



            bool result = obj.Authenticate(new AuthModel
            {
                Email = adminid,
                Password = pwd
            });

            if (result)
            {
                IUserModule uobj = BALFactory.GetUserModuleObject();
                IBookModule bobj = BALFactory.GetBookModuleObject();
                Console.WriteLine("\nLogin Sucessfull");
                bool logout = false;
                do
                {
                    Console.WriteLine("\n--------MENU--------");
                    Console.WriteLine("\n1) To Logout\n" + "\n2)Add Book\n" + "\n3)Get All Books\n" + "\n4)Lists NotActive Books\n" + "\n5)Make a Book Disable\n" +
                        "\n6)Enable Book\n" + "\n7)Issue a Book\n" + "\n8)Return Book\n" +
                        "\n9)Lists Available Books in BookHistoryDateBase\n" + "\n10)Add users\n" + "\n11)To Exit from the Application\n"
                        + "\n12)Lists The all Users Details\n" + "\n13)Check Availabliity of Books");
                    Console.WriteLine("\nEnter your choice");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Logout Sucessfully");
                                logout = true;
                                //To Login Again
                                goto AuthenticationPage;
                            }

                        case 2:
                            {
                                Console.WriteLine("\nEnter Book Name");
                                string bookname = Console.ReadLine();
                                Console.WriteLine("\nEnter Author Name");
                                string authorname = Console.ReadLine();
                                Console.WriteLine("\nEntet Department");
                                string dept = Console.ReadLine();
                                int lastBookId = bobj.LastBookId();
                                lastBookId += 1;
                                Console.WriteLine("\nEntet Number of copies to add");
                                int bookcount = Convert.ToInt32(Console.ReadLine());
                                for (int i = 0; i < bookcount; i++, lastBookId++)
                                    bobj.AddBook(new BookModel
                                    {
                                        BookID = lastBookId,
                                        Name = bookname,
                                        AuthorName = authorname,
                                        Department = dept,
                                        IsActive = true
                                    });
                                Console.WriteLine(+bookcount + "Added Sucessfully");
                                break;
                            }
                        case 3:
                            {
                                IEnumerable<BookModel> GetAllBooks = bobj.GetAllBooks(true);
                                Console.WriteLine("\n------Entire Books in Library are -------\n");
                                foreach (BookModel item in GetAllBooks)
                                {
                                    Console.WriteLine("\nBookId \t:{0}\nBook Name\t:{1}\nAuthor Name\t:{2}\nDepartment\t:{3}", item.BookID, item.Name, item.AuthorName, item.Department);
                                }
                                break;

                            }
                        case 4:
                            {
                                IEnumerable<BookModel> listsbooks = bobj.ListDisableBooks(false);
                                Console.WriteLine("\n------NotActive Books in Library are -------\n");
                                foreach (BookModel item in listsbooks)
                                {
                                    Console.WriteLine("\nBookId \t:{0}\nBook Name\t:{1}\nAuthor Name\t:{2}\nDepartment\t:{3}", item.BookID, item.Name, item.AuthorName, item.Department);
                                }
                                break;

                            }
                        case 5:
                            {
                                Console.WriteLine("Enter BookId to diable");
                                int bookId = Convert.ToInt32(Console.ReadLine());
                                bobj.DisableBook(bookId);
                                break;

                            }
                        case 6:
                            {
                                Console.WriteLine("Enter BookId to Enable");
                                int bookid = Convert.ToInt32(Console.ReadLine());
                                bobj.EnableBook(bookid);
                                break;
                            }
                        case 7:
                            {
                                Console.WriteLine("Enter BookId to Issue");
                                int bookid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter userId");
                                int userid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter AdminId at present who is issuing the books to the users");
                                int adminId = Convert.ToInt32(Console.ReadLine());
                                DateTime? returnat = null;
                                Console.WriteLine("\nEnter Any remarks");
                                string remarks = Console.ReadLine();

                                bobj.IssueBook(new BookHistoryModel
                                {
                                    BookID = bookid,
                                    UserID = userid,
                                    OperationPerofrmedAt = DateTime.Now,
                                    ReturnedAt = returnat,
                                    PerformedByID = adminId,
                                    Remarks = remarks,
                                    IsAvilable = false

                                });
                                break;
                            }
                        case 8:
                            {
                                Console.WriteLine("Enter Userid who is returning the book");
                                int userId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter bookId");
                                int bookId = Convert.ToInt32(Console.ReadLine());
                                //DateTime? returnat = null;
                                Console.WriteLine("\nDid you found remarks");
                                string remarks = Console.ReadLine();
                                bobj.ReturnBook(userId, bookId);



                                break;
                            }
                        case 9:
                            {
                                IEnumerable<BookHistoryModel> history = bobj.EntireHistory();
                                foreach (BookHistoryModel item in history)
                                {
                                    Console.WriteLine("\nBookID \t:{0}\nUserId \t:{1}\nAdmin ID{2}\nBook Returned\t:{3}\nAvailability\t:{4}\nAny Remarks\t:{5}"
                                        , item.BookID, item.UserID, item.PerformedByID, item.ReturnedAt, item.IsAvilable, item.Remarks);
                                }
                                break;
                            }
                        case 10:
                            {
                                Console.WriteLine("Enter New userid");//UserID=1, Name="User1", Email="Author1", IsActive=true, Password="Pwd1", IsAdmin=true
                                int userId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter name for user");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter New Email Id");
                                string email = Console.ReadLine();
                                Console.WriteLine("Enter some password to new user");
                                string password = Console.ReadLine();
                                Console.WriteLine("Did you want to make user as admin or not");
                                string admin = Console.ReadLine();
                                uobj.AddUser(new UserModel
                                {
                                    UserID = userId,
                                    Name = name,
                                    Email = email,
                                    IsActive = true,
                                    Password = "pwd",
                                    IsAdmin = true
                                });
                                break;
                            }
                        case 11:
                            {
                                //this.close();
                                Environment.Exit(0);
                                break;
                            }
                        //UserID=1, Name="User1", Email="Author1", IsActive=true, Password="Pwd1", IsAdmin=true
                        case 12:
                            {
                                Console.WriteLine("Entire User Details are");
                                IEnumerable<UserModel> userlist = uobj.GetAllUserDetails(true || false);
                                foreach (UserModel item in userlist)
                                {
                                    Console.WriteLine("\nUserID\t:{0}\nName\t:{1}\nEmail\t:{2}\nIsActive\t:{3}\nPassword\t:{4}\nIsAdmin" +
                                   item.UserID, item.Name, item.Email, item.IsActive, item.Password, item.IsAdmin);
                                }
                                break;
                            }
                        case 13:
                            {
                                Console.WriteLine("Enter Book name to check");
                                string bookname = Console.ReadLine();
                                var count= bobj.CheckBookAvailability(bookname);
                                if(count>0)
                                {
                                    Console.WriteLine(" \n{0} Books are Available",count);
                                }
                                else
                                {
                                    Console.WriteLine("No Book Found");
                                }

                                break;
                            }


                    }
                }
                while (!logout);
                    Console.WriteLine("You are Logged out Sucessfully");

                
        }
        }
    }
}
