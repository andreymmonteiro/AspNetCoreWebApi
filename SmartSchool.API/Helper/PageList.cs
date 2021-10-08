using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Helper
{
 
    //É uma classe que espera um objeto genérico e implementa uma lista generica para retorno;
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public PageList(List<T> items, int count, int pageNumber, int pageSize) 
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        public static async Task<PageList<T>> CreateAsync(IQueryable<T> source, int pageNumber,int pageSize)
        {
            //Aqui é onde é chamado a classe: É feito o tratamento de paginação em si, com os counts, as configurações e definições de páginas e quantidades de itens por páginas
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            //Aqui é onde basicamente essa classe é instanciada: Percebe-se que ela não é instanciada em sua chamada nas controllers e afins,
            //é usado esse método estático que ele sim inicializa o construtor após configurar todo o pagination
            return new PageList<T>(items,count,pageNumber,pageSize);
        }
    }
}
