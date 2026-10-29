namespace ListaEspera.Models.Enums
{
    public enum ProcessedResults
    {
        Ok = 200,
        Conflict = 409,
        NotFound = 404,
        BadRequest = 400,
        ErrorServer = 500

    }
}