using System.Threading.Tasks;
using WebApp.ViewModels.Catalog.Card;
using WebApp.ViewModels.Common;

namespace WebApp.AdminApp.Services
{
    public interface ICardAPIClient
    {
        Task<PageResult<CardViewModel>> GetPaging(GetManageCardPagingRequest request);
        Task<bool> Create(CardCreateRequest request);
    }
}
