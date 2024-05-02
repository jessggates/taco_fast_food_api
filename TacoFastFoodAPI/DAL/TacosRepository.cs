using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.DAL
{
    public class TacosRepository
    {
        private readonly AhbcTeachingContext _context;

        public TacosRepository(AhbcTeachingContext context)
        {
            _context = context;
        }

        public List<Taco> GetAllTacos() //add bool for optional query param for softshell
        {
            return _context.Tacos.ToList();
        }

        public Taco GetTacoById(int id)
        {
            Taco taco = _context.Tacos.FirstOrDefault(t => t.Id == id);
            return taco;
        }

        public void AddTaco(Taco taco)
        {
            _context.Tacos.Add(taco);
            _context.SaveChanges();
        }

        public void DeleteTacoById(int id)
        {
            Taco taco = _context.Tacos.FirstOrDefault(t =>t.Id == id);
            if (taco != null)
            {
                _context.Tacos.Remove(taco);
                _context.SaveChanges();
            }
        }


    }
}
