using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Repositories;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<bool> AddRestaurant(RestaurantDto Objres)
        {
            Restaurant objres = new Restaurant();
            objres.RestaurantName = Objres.RestaurantName;
            objres.RestaurantLocation = Objres.RestaurantLocation;
            objres.CreationDate = Objres.CreationDate;
            var res = await _restaurantRepository.AddRestaurant(objres);
            return res;

        }

        public async Task<bool> DeleteRestaurant(int Id)
        {
            await _restaurantRepository.DeleteRestaurant(Id);
            return true;

        }

        public async Task<List<RestaurantDto>> GetallRestaurants()
        {
            List<RestaurantDto> reslist = new List<RestaurantDto>();
            var getrestaurants = await _restaurantRepository.GetallRestaurants();
            foreach (var restaurant in getrestaurants)
            {
                RestaurantDto resobj = new RestaurantDto();
                resobj.Id = restaurant.Id;
                resobj.RestaurantName = restaurant.RestaurantName;
                resobj.RestaurantLocation = restaurant.RestaurantLocation;
                resobj.CreationDate = restaurant.CreationDate;
                reslist.Add(resobj);


            }
            return reslist;
        }

        public async Task<RestaurantDto> GetRestaurantById(int Id)
        {
            var res = await _restaurantRepository.GetRestaurantById(Id);
            RestaurantDto objres = new RestaurantDto();
            objres.Id = res.Id;
            objres.RestaurantName = res.RestaurantName;
            objres.RestaurantLocation = res.RestaurantLocation;
            objres.CreationDate = res.CreationDate;
            return objres;

        }

        public async  Task<bool> UpdateRestaurant(RestaurantDto Objres)
        {
            Restaurant res = new Restaurant();
            res.Id = Objres.Id;
            res.RestaurantLocation = Objres.RestaurantLocation;
            res.RestaurantName = Objres.RestaurantName;
            res.CreationDate = Objres.CreationDate;
            await _restaurantRepository.UpdateRestaurant(res);
            return true;

        }
    }
}
