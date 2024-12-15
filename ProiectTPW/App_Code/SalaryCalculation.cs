using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SalaryCalculation
/// </summary>
public class SalaryCalculation
{
    public decimal CalculateTotalBrut(decimal salar_baza, decimal spor, decimal premiiBrute)
    {
        return salar_baza + (spor / 100) * salar_baza + premiiBrute;
    }

    public decimal CalculateCAS(decimal totalBrut, decimal cas_procent)
    {
        return totalBrut * cas_procent / 100;
    }

    public decimal CalculateCASS(decimal totalBrut, decimal cass_procent)
    {
        return totalBrut * cass_procent / 100;
    }

    public decimal CalculateBrutImpozabil(decimal totalBrut, decimal cas, decimal cass)
    {
        return totalBrut - cas - cass;
    }

    public decimal CalculateImpozit(decimal brutImpozabil, decimal impozit)
    {
        return brutImpozabil * impozit / 100;
    }

    public decimal CalculateViratCard(decimal brutImpozabil, decimal impozit, decimal retineri)
    {
        return brutImpozabil - impozit - retineri;
    }

}