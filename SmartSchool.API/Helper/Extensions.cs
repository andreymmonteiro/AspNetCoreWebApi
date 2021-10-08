using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SmartSchool.API.Helper
{
    //Classe usada para adicionar as informações da paginação no Header da resposta da requisição
    //Ela usa o PaginationHeader para construir o objeto e adicionar no Header
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response, 
                                            int CurrentPage, 
                                            int TotalPages, 
                                            int ItemsPerPage, 
                                            int TotalItems)
        {
            var paginationHeader = new PaginationHeader(CurrentPage, TotalPages, ItemsPerPage, TotalItems);
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader));
            response.Headers.Add("Access-Control-Expose-Header", "Pagination");
        }
    }
}
