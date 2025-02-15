using BazaDanych.Model;
using Dapper;
using System.ComponentModel.DataAnnotations.Schema;

namespace BazaDanych.Mapper
{
    internal static class MapSetter
    {
        public static void SetDapperMapper()
        {
            Dapper.SqlMapper.SetTypeMap(
                typeof(BookProperties),
                new CustomPropertyTypeMap(
                    typeof(BookProperties),
                    (type, columnName) =>
                        type.GetProperties().FirstOrDefault(prop =>
                            prop.GetCustomAttributes(false)
                                .OfType<ColumnAttribute>()
                                .Any(attr => attr.Name == columnName))));
        }
    }
}