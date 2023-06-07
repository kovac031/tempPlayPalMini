using PagedList;
using PlayPalMini.DAL;
using PlayPalMini.Model;
using PlayPalMini.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayPalMini.Repository
{
    public class BoardGameRepository : IBoardGameRepository
    {
        //--------------dependency injection----------
        public EFContext Context { get; set; }
        public BoardGameRepository(EFContext context)
        {
            Context = context;
        }
        //---------------------------------------------

        //---------GET ALL-------------------
        //-------filtering nema tu------------dovoljno samo u kontroleru
        public async Task<IPagedList<BoardGameDTO>> GetAllBoardGamesAsync(string sorting, int pageNumber, int pageSize)
        {
            IQueryable<BoardGame> boardGame = Context.BoardGames;

            //---------sorting------------
            switch (sorting)
            {
                case "rating_desc":
                    boardGame = boardGame.OrderByDescending(x => x.Reviews.Any() ? x.Reviews.Average(r => r.Rating) : 0);
                    break;
                case "rating_asc":
                    boardGame = boardGame.OrderBy(x => x.Reviews.Any() ? x.Reviews.Average(r => r.Rating) : 0);
                    break;
                case "title_desc":
                    boardGame = boardGame.OrderByDescending(x => x.Title);
                    break;
                //case "title_asc":
                //    boardGame = boardGame.OrderBy(x => x.Title);
                //    break;
                default:
                    boardGame = boardGame.OrderBy(x => x.Title);
                    break;
            }

            List<BoardGameDTO> list = await boardGame.Select(x => new BoardGameDTO()
            {
                //Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                AvgRating = x.Reviews.Any() ? x.Reviews.Average(r => r.Rating) : 0
            }).ToListAsync();

            //-------paging-----------

            int totalItemCount = list.Count;
            StaticPagedList<BoardGameDTO> pagedList = new StaticPagedList<BoardGameDTO>(list, pageNumber, pageSize, totalItemCount);

            //---------------------
            return pagedList; //bez paging je list varijabla
        }
    }
}
