namespace SalesWebMvc.Models.Enums
{
    // Enum contendo os status de uma venda
    public enum SaleStatus : int
    {
        Pending = 0,
        Billed = 1,
        Canceled = 2
    }
}