namespace KsiazkaAdresowaAPI

{
    public static class Endpoints{

        // Strowrzenie instancji ksiazki adresowej odpowiedzialnej za przechowywanie adresow i ich obsluge
        private static KsiazkaAdresowa ksiazkaAdresowa = new KsiazkaAdresowa();

        // Mapowanie endpointow
        public static WebApplication MapEndpoints(this WebApplication app)
        {

            app.MapGet("/", () => 
            {
                var latestAddress = ksiazkaAdresowa.GetLatest();
                return latestAddress != null ? Results.Ok(latestAddress) : Results.NotFound("No address found.");
            });


            app.MapGet("/{miasto}", (string miasto) =>
            {
                var adresses = ksiazkaAdresowa.GetByCity(miasto);
                return adresses != null ? Results.Ok(adresses) : Results.NotFound("No address found in that city.");
            });


            app.MapPost("/", (Adres adres) =>
            {
                ksiazkaAdresowa.Add(adres);
                return Results.Created("/", adres);
            });


            return app;
        }
    }
}