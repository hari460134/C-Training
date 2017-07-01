using DomainLayer;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Library
{
    internal class BookModule : IBookModule
    {
        public string AddBook(BookModel bookObj)
        {
            try
            {
                StaticDatabase._booksList.Add(bookObj);

                return StringLiterals.SuccesMsg;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<BookModel> GetAllBooks(bool isIncludeDisabled)
        {
            try
            {
                if (isIncludeDisabled)
                {
                    return StaticDatabase._booksList;
                }

                return StaticDatabase._booksList.Where(m => m.IsActive == true);
            }
            catch
            {
                throw;
            }
        }

        public string IssueBook(BookHistoryModel obj)
        {
            try
            {
                if (StaticDatabase._bookHistoryList.Any(m => m.BookID == obj.BookID && m.ReturnedAt == null))
                {
                    return StringLiterals.BookIsAssignedToUser;
                }

                StaticDatabase._bookHistoryList.Add(obj);
                return StringLiterals.SuccesMsg;
            }
            catch
            {
                throw;
            }
        }

        public void RemoveBook(int bookID)
        {
            try
            {
                BookModel bookObj = StaticDatabase._booksList.Where(m => m.BookID == bookID).FirstOrDefault();
                bookObj.IsActive = false;

            }
            catch
            {
                throw;
            }


        }

        public void ReturnBook(int userid, int bookid)
        {
            try
            {

                if (StaticDatabase._bookHistoryList.Any(m => m.BookID == bookid && m.UserID == userid))
                {
                    BookHistoryModel obj = StaticDatabase._bookHistoryList.Where(m => m.BookID == bookid && m.UserID == userid).FirstOrDefault();
                    obj.IsAvilable = false;
                }

            }
            catch
            {
                throw;

            }
        }

        public int LastBookId()
        {
            try
            {
                return StaticDatabase._booksList.Max(id => id.BookID);
            }
            catch
            {
                throw;
            }
            }

        public IEnumerable<BookModel> ListDisableBooks(bool isDisabled)
        {
            try
            {
                return StaticDatabase._booksList.Where(m => m.IsActive == false);
            }
            catch
            {
                throw;
            }


            
        }

        public string DisableBook(int bookId)
        {
            try
            {
                if (StaticDatabase._booksList.Any(m => m.BookID == bookId))
                {
                    BookModel obj= StaticDatabase._booksList.Where(m => m.BookID == bookId).FirstOrDefault();
                    obj.IsActive = false;
                    return StringLiterals.DisableBook;
                }
                else
                {
                    return StringLiterals.DisableBookNotAvailable;

                }
            }
            catch
            {
                throw;
            }
            
        }
        public string EnableBook(int bookid)
        {
            try
            {
                if (StaticDatabase._booksList.Any(m => m.BookID == bookid))
                {
                    BookModel obj = StaticDatabase._booksList.Where(m => m.BookID == bookid).FirstOrDefault();
                    obj.IsActive = true;
                    return StringLiterals.EnableBook;
                }
                else
                {
                    return StringLiterals.EnableBookNotAvailable;

                }
            }
            catch
            {
                throw;
            }

        }

        public   IEnumerable<BookHistoryModel> EntireHistory()
        {
            try
            {
                return StaticDatabase._bookHistoryList;

            }
            catch
            {
                throw;
            }
        }

        public int CheckBookAvailability(string bookname)
        {
            try
            {
                if(StaticDatabase._booksList.Any(m=>m.Name==bookname && m.IsActive==true))
                {
                    var bookcount = StaticDatabase._booksList.Where(m => m.Name == bookname && m.IsActive == true).Select(p=>p.BookID);
                    return bookcount.Count();
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }

        }


    }
}
