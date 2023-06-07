using PagedList;
using PlayPalMini.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayPalMini.Service.Common
{
    public interface IBoardGameService
    {
        Task<IPagedList<BoardGameDTO>> GetAllBoardGamesAsync(string sorting, int pageNumber, int pageSize);
    }
}
