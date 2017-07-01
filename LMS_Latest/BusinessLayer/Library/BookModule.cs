using DomainLayer.Models;
using System.Collections.Generic;

using Repo = Repository.Library;

namespace BusinessLayer.Library
{
    internal class BookModule : IBookModule
    {
        Repo.IBookModule _bookObj;

        public BookModule()
        {
            _bookObj = Repository.RepoFactory.GetBookModuleObject();
        }

       
        public string AddBook(BookModel bookObj)
        {
            return _bookObj.AddBook(bookObj);
        }

        public IEnumerable<BookModel> GetAllBooks(bool isIncludeDisabled = false)
        {
            return _bookObj.GetAllBooks(isIncludeDisabled);
        }

        public string IssueBook(BookHistoryModel obj)
        {
            return _bookObj.IssueBook(obj);
        }

        public void RemoveBook(int bookID)
        {

        }

        public void ReturnBook(int userid, int bookid)
        {
        }
        public int LastBookId()
        {
            return _bookObj.LastBookId();
        }

        public IEnumerable<BookModel> ListDisableBooks(bool isDisabled=true)
        {
            return _bookObj.ListDisableBooks(isDisabled);
        }

       public string DisableBook(int bookId)
        {
            return _bookObj.DisableBook(bookId);
        }

        public string EnableBook(int bookid)
        {
            return _bookObj.EnableBook(bookid);
        }

        public IEnumerable<BookHistoryModel> EntireHistory()
        {
            return _bookObj.EntireHistory();
        }

        public int CheckBookAvailability(string bookname)
        {
            return _bookObj.CheckBookAvailability(bookname);
        }
    }
}
