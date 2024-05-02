using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.DAL
{
    public class DrinksRepository
    {
        private readonly AhbcTeachingContext _context;

        public DrinksRepository(AhbcTeachingContext context)
        {
            _context = context;
        }

        public List<Drink> GetAllDrinks() //add optional string for SortByCost parameter to sort in desc or asc
        {
            return _context.Drinks.ToList();
        }

        public Drink GetDrinkById(int id)
        {
            Drink drink = _context.Drinks.FirstOrDefault(d => d.Id == id);
            return drink;
        }

        public void AddDrink(Drink drink)
        {
            _context.Drinks.Add(drink);
            _context.SaveChanges();
        }

        public void DeleteDrinkById (int id)
        {
            Drink drink = _context.Drinks.FirstOrDefault(d => d.Id == id);
            if (drink != null)
            {
                _context.Drinks.Remove(drink);
                _context.SaveChanges();
            }
        }
    }
}
