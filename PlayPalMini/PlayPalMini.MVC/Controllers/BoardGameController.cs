using PagedList;
using PlayPalMini.Model;
using PlayPalMini.MVC.Models;
using PlayPalMini.Service;
using PlayPalMini.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PlayPalMini.MVC.Controllers
{
    public class BoardGameController : Controller
    {
        public IBoardGameService BoardGameService { get; set; }
        public BoardGameController (IBoardGameService boardGameService)
        {
            BoardGameService = boardGameService;
        }

        //----------GET ALL-------------
        public async Task<ActionResult> GetAllBoardGamesAsync(string sorting, string filterby, int? page)
        {
            //----sorting-----//po descriptionu nejde jer je predugacko valjda
            ViewBag.SortByTitle = string.IsNullOrEmpty(sorting) ? "title_desc" : ""; //prvi klik prije sortanja je true pa postavi title_desc, a svaki klik kad vec ima sorting u biti je notnull, tj true pa ga obrise
            ViewBag.SortByRating = sorting == "rating_asc" ? "rating_desc" : "rating_asc"; //prvi klik je false pa postavi rating_asc, drugi klik je true pa postavi rating_desc

            //----------------       

            //-----paging----------
            int pageNumber = page ?? 1; 
            int pageSize = 5;

            IPagedList<BoardGameDTO> listDTO = await BoardGameService.GetAllBoardGamesAsync(sorting, pageNumber, pageSize);

            //---------------------

            //------filtering------
            List<BoardGameDTO> filteredListDTO = listDTO.ToList();
            if (!string.IsNullOrEmpty(filterby))
            {
                filteredListDTO = filteredListDTO.Where(x => x.Title.IndexOf(filterby, StringComparison.OrdinalIgnoreCase) >= 0 || x.Description.IndexOf(filterby, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            //---------------------

            //-------also paging--------
            IPagedList<BoardGameDTO> pagedList = new PagedList<BoardGameDTO>(filteredListDTO, pageNumber, pageSize);

            //-------------------------

            List<BoardGameView> listView = new List<BoardGameView>();

            foreach (BoardGameDTO boardGameDTO in pagedList)
            {
                BoardGameView boardGameView = new BoardGameView();
                //boardGameView.Id = boardGameDTO.Id;
                boardGameView.Title = boardGameDTO.Title;
                boardGameView.Description = boardGameDTO.Description;
                boardGameView.AvgRating = Math.Round(boardGameDTO.AvgRating, 2);
                listView.Add(boardGameView);
            }
            
            StaticPagedList<BoardGameView> pagedListView = new StaticPagedList<BoardGameView>(listView, pagedList.GetMetaData());

            return View(pagedListView);
        }
    }
}