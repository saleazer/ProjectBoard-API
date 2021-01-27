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

        public List<BoardItem> QueryByItemType(String ItemType)
        {
            return _context.BoardItem.Where(x => x.ItemType == ItemType).ToList();

        }
        public List<BoardItem> QueryByParentID(String ParentID)
        {
            return _context.BoardItem.Where(x => x.ParentID == ParentID).ToList();

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
                    ItemToBeSaved.CreateDate = DateTime.Now;
                    ItemToBeSaved.LastUpdated = DateTime.Now;
                    _context.BoardItem.Add(ItemToBeSaved);
                    _context.SaveChanges();
                }
                else
                {
                    //update logic
                    //ExistingItem = ItemToBeSaved;
                    ExistingItem.Description = ItemToBeSaved.Description;
                    ExistingItem.Effort = ItemToBeSaved.Effort;
                    ExistingItem.ItemType = ItemToBeSaved.ItemType;
                    ExistingItem.Priority = ItemToBeSaved.Priority;
                    ExistingItem.State = ItemToBeSaved.State;
                    ExistingItem.Title = ItemToBeSaved.Title;
                    ExistingItem.LastUpdated = DateTime.Now;
                    ExistingItem.Iteration = ItemToBeSaved.Iteration;
                    ExistingItem.OwnerName = ItemToBeSaved.OwnerName;
                    ExistingItem.ParentID = ItemToBeSaved.ParentID;

                    _context.BoardItem.Update(ExistingItem);
                    _context.SaveChanges();
                }
                return true;
            } catch (Exception)
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
