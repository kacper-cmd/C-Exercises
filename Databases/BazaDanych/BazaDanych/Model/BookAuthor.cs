using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych.Model
{
    internal class BookAuthor
    {
        public BookAuthor(int auhtorId, int bookId)
        {
            AuthorId = auhtorId;
            BookId = bookId;
        }

        public int AuthorId { get; }
        public int BookId { get; }

        public override string? ToString()
        {
            return $"{AuthorId} | {BookId}";
        }
    }
}