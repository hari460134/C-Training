using DomainLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Library
{
    public interface IBookModule
    {
        string IssueBook(BookHistoryModel obj);

        void ReturnBook(int userid,int bookid);

        string AddBook(BookModel bookObj);

        /// <summary>
        /// To Find last book id for further adding
        /// </summary>
        /// <param name="bookID"></param>

        int LastBookId();

        void RemoveBook(int bookID);

        IEnumerable<BookModel> GetAllBooks(bool isIncludeDisabled);

        IEnumerable<BookModel> ListDisableBooks(bool isDisabled);

        string DisableBook(int bookId);

        string EnableBook(int bookid);

        IEnumerable<BookHistoryModel> EntireHistory();

        int CheckBookAvailability(string bookname);
    }
}
