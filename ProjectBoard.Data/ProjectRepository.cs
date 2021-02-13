using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjectBoard.Data
{
    public class ProjectRepository
    {

        private readonly ProjectBoardContext _context;

        public ProjectRepository(ProjectBoardContext context)
        {
            _context = context;

        }

        public Project QueryById(Int64 id)
        {
            return _context.Project.Where(x => x.ID == id).FirstOrDefault();

        }
        public List<Project> QueryByName(String Name)
        {
            return _context.Project.Where(x => x.Name == Name).ToList();

        }
        public List<Project> QueryByCreator(String Creator)
        {
            return _context.Project.Where(x => x.Creator == Creator).ToList();

        }
        public List<Project> QueryAll()
        {
            return _context.Project.ToList();

        }

        public Boolean AddOrUpdate(Project ItemToBeSaved)
        {
            Project ExistingItem = _context.Project.Where(x => x.ID == ItemToBeSaved.ID).FirstOrDefault();

            try
            {
                if (ExistingItem == null)
                {
                    //New logic
                    ItemToBeSaved.CreateDate = DateTime.Now;
                    _context.Project.Add(ItemToBeSaved);
                    _context.SaveChanges();
                }
                else
                {
                    //update logic
                    //ExistingItem = ItemToBeSaved;
                    ExistingItem.Name = ItemToBeSaved.Name;
                    ExistingItem.Description = ItemToBeSaved.Description;
                    ExistingItem.Creator = ItemToBeSaved.Creator;
                    _context.Project.Update(ExistingItem);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean DeleteById(Int64 id)
        {
            Project ExistingItem = _context.Project.Where(x => x.ID == id).FirstOrDefault();

            if (ExistingItem != null)
            {
                //New logic
                _context.Project.Remove(ExistingItem);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

    }
}
