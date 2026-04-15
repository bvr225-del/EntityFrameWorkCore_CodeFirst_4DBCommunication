using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces
{
    public interface IRestaurantService
    {
        Task<bool> AddRestaurant(RestaurantDto Objres);
        Task<bool> UpdateRestaurant(RestaurantDto Objres);
        Task<bool> DeleteRestaurant(int Id);
        Task<List<RestaurantDto>> GetallRestaurants();
        Task<RestaurantDto> GetRestaurantById(int Id);

    }
}
