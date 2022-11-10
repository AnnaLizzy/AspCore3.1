using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.EF;
using WebApp.ViewModels.Common;
using WebApp.ViewModels.System.Languages;
using WebApp.ViewModels.System.Users;

namespace WebApp.Applications.System.Languages
{
    public class LanguagesService : ILanguagesService
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        public LanguagesService(IConfiguration config,AppDbContext appDbContext)
        {
            _config = config;
            _context = appDbContext;
        }
        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            var language = await _context.Languages.Select(x => new LanguageVm()
            {
                Id = x.Id,
                Name = x.Name,
                
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageVm>>(language);
        }
        
    }
}
