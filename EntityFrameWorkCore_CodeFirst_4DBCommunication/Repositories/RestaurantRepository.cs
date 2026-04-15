using EntityFrameWorkCore_CodeFirst_4DBCommunication.DbConnect;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Migrations.Department;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantContext _restaurantContext;
        public RestaurantRepository(RestaurantContext restaurantContext)
        {
            _restaurantContext=restaurantContext;
        }
        public async Task<bool> AddRestaurant(Restaurant Objres)
        {
           await _restaurantContext.Restaurants.AddAsync(Objres);
            _restaurantContext.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteRestaurant(int Id)
        {
            Restaurant result = _restaurantContext.Restaurants.Where(e => e.Id == Id).FirstOrDefault();
            if (result != null)
            {//Here Remove() method is used for removing the data from database.

                _restaurantContext.Restaurants.Remove(result);
                _restaurantContext.SaveChanges();//similart to commit
                return true;
            }
            else return false;

        }

        public async Task<List<Restaurant>> GetallRestaurants()
        {
            var result = await _restaurantContext.Restaurants.ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }

        }

        public async Task<Restaurant> GetRestaurantById(int Id)
        {
            var result = await _restaurantContext.Restaurants.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (result == null)
            {//if result having no data i am returning null here.null means nothing.
                return null;
            }
            else
            {
                return result;
            }

        }

        public async Task<bool> UpdateRestaurant(Restaurant Objres)
        {
            _restaurantContext.Restaurants.Update(Objres);
            await _restaurantContext.SaveChangesAsync();
            return true;
        }
    }
}
