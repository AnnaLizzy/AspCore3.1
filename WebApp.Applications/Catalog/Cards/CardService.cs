using Microsoft.EntityFrameworkCore;
using Syncfusion.EJ2.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Data.EF;
using WebApp.Data.Entities;
using WebApp.ViewModels.Catalog.Card;
using WebApp.ViewModels.Common;

namespace WebApp.Applications.Catalog.Cards
{
    public class CardService : ICardService
    {
        private readonly AppDbContext _context;
        public  CardService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(CardCreateRequest request)
        {
            var card = new Card()
            {                
                CardModelID= request.CardModelID,
                Company = request.Company,
                ControlType= request.ControlType,
                AdminID= request.AdminID,
                ID= request.ID,
                DeleteDate= request.DeleteDate,
                IsDeleted= request.IsDeleted,
                ModifiedTime= request.ModifiedTime,
                CardNumber = request.CardNumber,
                CreatedTime = DateTime.Now,
                EndTime = request.EndTime,
                CardGUID= request.CardGUID,
                WorkType= request.WorkType,
                Color= request.Color,
                SerialNumber= request.SerialNumber,
                Status = request.Status,
                Type= request.Type,                
            };
            _context.Cards.Add(card);
             await _context.SaveChangesAsync();
            return card.CardID;
            
        }

        public async Task<int> Delete(int CardId)
        {
            var cardID = await _context.Cards.FindAsync(CardId);
            if(cardID == null)
            {
                throw new Exception($"Không tìm thấy mã thẻ {cardID}");
            }
            _context.Cards.Remove(cardID);
            return await _context.SaveChangesAsync();
        }

        public async Task<PageResult<CardViewModel>> GetAllPaging(GetManageCardPagingRequest request)
        {
            //show all
            var userlist = await _context.Cards.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new CardViewModel()
                { 
                   AdminID= x.AdminID,
                   CardGUID= x.CardGUID,
                   WorkType= x.WorkType,
                   Color= x.Color,
                   CardID = x.CardID,
                   CardModelID = x.CardModelID,
                   CardNumber= x.CardNumber,
                   Company = x.Company,
                   ControlType= x.ControlType,
                   CreatedTime= x.CreatedTime,
                   DeleteDate= x.DeleteDate,
                   EndTime= x.EndTime,
                   ID= x.ID,
                   IsDeleted= x.IsDeleted,
                   ModifiedTime= x.ModifiedTime,
                   SerialNumber= x.SerialNumber,
                   Status= x.Status,
                   Type= x.Type,
                
                }).ToListAsync();

            int totalrow = userlist.Count();
            var page = new PageResult<CardViewModel>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalrow,
                Items = userlist,
            };
            return page;
        }

        public async Task<CardViewModel> GetById(int CardId)
        {
            var card = await _context.Cards.FindAsync(CardId);
            
            var cardViewModel = new CardViewModel()
            {
                Color= card.Color,
                Company= card.Company,
                ControlType= card.ControlType,
                CreatedTime= DateTime.Now,
                CardGUID= card.CardGUID,             
                CardModelID= card.CardModelID,
                CardNumber = card.CardNumber,
                EndTime= card.EndTime,
                ID= card.ID,
                IsDeleted= card.IsDeleted,
                AdminID= card.AdminID,
                SerialNumber = card.SerialNumber,
                Status= card.Status,
                Type= card.Type,
                WorkType= card.WorkType,
                ModifiedTime= DateTime.Now,
            };
            return cardViewModel;
        }

        public async Task<int> Update(CardUpdateRequest request)
        {
            var card =await _context.Cards.FindAsync(request.CartId);
            if(card == null)
            {
                throw new Exception($"Không tìm thấy mã thẻ {request.CartId}");
            }
            card.CardGUID= request.CardGUID;
            card.CardNumber = request.CardNumber;
            card.EndTime = request.EndTime;
            card.Status = request.Status;
            card.Type = request.Type;
            card.WorkType = request.WorkType;
            card.ModifiedTime = DateTime.Now;
            card.ID = request.ID;
            card.AdminID = request.AdminID;
            card.SerialNumber = request.SerialNumber;
            card.Color = request.Color;
            card.Company = request.Company;
            
            return await _context.SaveChangesAsync();
        }
    }
}
