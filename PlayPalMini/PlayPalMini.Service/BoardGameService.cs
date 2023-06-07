using PagedList;
using PlayPalMini.Model;
using PlayPalMini.Repository.Common;
using PlayPalMini.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayPalMini.Service
{
    public class BoardGameService : IBoardGameService
    {
        public IBoardGameRepository BoardGameRepository { get; set; }
        public BoardGameService(IBoardGameRepository boardGameRepository)
        {
            BoardGameRepository = boardGameRepository;
        }

        public async Task<IPagedList<BoardGameDTO>> GetAllBoardGamesAsync(string sorting, int pageNumber, int pageSize)
        {
            IPagedList<BoardGameDTO> list = await BoardGameRepository.GetAllBoardGamesAsync(sorting, pageNumber, pageSize);
            return list;
        }
    }
}
