using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.ViewModels.Catalog.Card;
using WebApp.ViewModels.Catalog.Products;
using WebApp.ViewModels.Common;

namespace WebApp.Applications.Catalog.Cards
{
    public interface ICardService
    {
        Task<int> Create(CardCreateRequest request);
        Task<int> Update(CardUpdateRequest request);
        Task<int> Delete(int CardId);
        Task<CardViewModel> GetById(int CardId);
        Task<PageResult<CardViewModel>> GetAllPaging(GetManageCardPagingRequest request);
    }
}
