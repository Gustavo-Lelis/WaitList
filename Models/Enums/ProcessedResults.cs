namespace ListaEspera.Models.Enums
{
    public enum ProcessedResults
    {
        Ok = 200,
        Created = 201,
        ErroServer = 500,
        Conflict = 409,
        NotFound = 404,
        BadRequest = 400

    }
}