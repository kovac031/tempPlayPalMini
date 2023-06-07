//using PagedList;
//using PlayPalMini.Model;
//using PlayPalMini.MVC.Models;
//using PlayPalMini.Service;
//using PlayPalMini.Service.Common;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

//namespace PlayPalMini.MVC.Controllers
//{
//    public class BoardGameNoPagingController : Controller
//    {
//        public IBoardGameService BoardGameService { get; set; }
//        public BoardGameNoPagingController(IBoardGameService boardGameService)
//        {
//            BoardGameService = boardGameService;
//        }

//        //----------GET ALL-------------
//        public async Task<ActionResult> GetAllBoardGamesAsync(string sorting, string filterby)
//        {
//            //----sorting-----
//            ViewBag.SortByTitle = string.IsNullOrEmpty(sorting) ? "title_desc" : ""; //prvi klik prije sortanja je true pa postavi title_desc, a svaki klik kad vec ima sorting u biti je notnull, tj true pa ga obrise
//            //ViewBag.SortByDescription = string.IsNullOrEmpty(sorting) ? "description_desc" : "description_asc"; // description ne moze sorting zbog tipa podatka, vj predugacko
//            ViewBag.SortByRating = sorting == "rating_asc" ? "rating_desc" : "rating_asc"; //prvi klik je false pa postavi rating_asc, drugi klik je true pa postavi rating_desc

//            //----------------            

//            List<BoardGameDTO> listDTO = await BoardGameService.GetAllBoardGamesAsync(sorting);
//            List<BoardGameView> listView = new List<BoardGameView>();

//            //------filtering------
//            if (!string.IsNullOrEmpty(filterby))
//            {
//                listDTO = listDTO.Where(x => x.Title.IndexOf(filterby, StringComparison.OrdinalIgnoreCase) >= 0 || x.Description.IndexOf(filterby, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
//            }
//            //---------------------


//            foreach (BoardGameDTO boardGameDTO in listDTO)
//            {
//                BoardGameView boardGameView = new BoardGameView();
//                //boardGameView.Id = boardGameDTO.Id;
//                boardGameView.Title = boardGameDTO.Title;
//                boardGameView.Description = boardGameDTO.Description;
//                boardGameView.AvgRating = Math.Round(boardGameDTO.AvgRating, 2);
//                listView.Add(boardGameView);
//            }
//            return View(listView);
//        }
//    }
//}