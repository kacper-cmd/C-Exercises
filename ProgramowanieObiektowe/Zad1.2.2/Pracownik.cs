using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1._2._2;
public class Pracownik
{
    #region Fields
    private string imie;
    private string nazwisko;
    private string stanowisko;
    private decimal pensja;
    private int dostepnyUrlop;
    private int wykorzystanyUrlop;
    #endregion
    #region Constructor
    public Pracownik(string imie, string nazwisko, string stanowisko, decimal pensja, int dostepnyUrlop, int wykorzystanyUrlop)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.stanowisko = stanowisko;
        this.pensja = pensja;
        this.dostepnyUrlop = dostepnyUrlop;
        this.wykorzystanyUrlop = wykorzystanyUrlop;
    }
    #endregion
    #region Getters
    public string GetImie()
    {
        return imie;
    }
    public string GetNazwisko()
    {
        return nazwisko;
    }

    public string GetStanowisko()
    {
        return stanowisko;
    }

    public decimal GetPensja()
    {
        return pensja;
    }

    public int GetDostepnyUrlop()
    {
        return dostepnyUrlop;
    }

    public int GetWykorzystanyUrlop()
    {
        return wykorzystanyUrlop;
    }

   
    #endregion
}
