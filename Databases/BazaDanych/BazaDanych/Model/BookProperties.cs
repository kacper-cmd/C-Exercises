using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych.Model
{
    internal class BookProperties
    {
        [Column("Author Name")]
        public string AuthorName { get; }

        [Column("Author Surname")]
        public string AuthorSurname { get; }

        [Column("BookID")]
        public int BookId { get; }

        [Column("Book Name")]
        public string BookName { get; }

        [Column("Department Name")]
        public string DepartmentName { get; }

        public override string? ToString()
        {
            return $"{BookId} | {BookName} | {AuthorName} | {AuthorSurname} | {DepartmentName}";
        }
    }
}