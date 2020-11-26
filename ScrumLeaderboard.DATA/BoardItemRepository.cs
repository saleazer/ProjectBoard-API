using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScrumLeaderboard.DATA
{
    
    public class BoardItemRepository
    {
        
        private readonly ScrumLeaderboardContext _context;

        public BoardItemRepository(ScrumLeaderboardContext context)
        {
            _context = context;

        }

        public BoardItem QueryById(Int64 id)
        {
            return _context.BoardItem.Where(x => x.ID == id).FirstOrDefault();

        }

        public List<BoardItem> QueryByState(String State)
        {
            return _context.BoardItem.Where(x => x.State == State).ToList();

        }

        public List<BoardItem> QueryAll()
        {
            return _context.BoardItem.ToList();

        }

        public Boolean AddOrUpdate(BoardItem ItemToBeSaved)
        {
            BoardItem ExistingItem = _context.BoardItem.Where(x => x.ID == ItemToBeSaved.ID).FirstOrDefault();

            try
            {
                if (ExistingItem == null)
                {
                    //New logic
                    _context.BoardItem.Add(ItemToBeSaved);
                    _context.SaveChanges();
                }
                else
                {
                    //update logic
                    ExistingItem = ItemToBeSaved;
                    _context.BoardItem.Update(ExistingItem);
                    _context.SaveChanges();
                }
                return true;
            } catch
            {
                return false;
            }
        }

        public Boolean DeleteById(Int64 id)
        {
            BoardItem ExistingItem = _context.BoardItem.Where(x => x.ID == id).FirstOrDefault();

            if (ExistingItem != null)
            {
                //New logic
                _context.BoardItem.Remove(ExistingItem);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

    }

}
