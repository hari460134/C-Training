using DomainLayer.Models;
using System.Collections.Generic;

namespace Repository.Library
{
    public interface IBookModule
    {
        string IssueBook(BookHistoryModel obj);

        void ReturnBook(int userid, int bookid);

        string AddBook(BookModel bookObj);

        void RemoveBook(int bookID);

        IEnumerable<BookModel> GetAllBooks(bool isIncludeDisabled);

        int LastBookId();

        IEnumerable<BookModel> ListDisableBooks(bool isDisabled);

        string DisableBook(int bookId);

        string EnableBook(int bookid);

        IEnumerable<BookHistoryModel> EntireHistory();

        int CheckBookAvailability(string bookname);


    }
}
