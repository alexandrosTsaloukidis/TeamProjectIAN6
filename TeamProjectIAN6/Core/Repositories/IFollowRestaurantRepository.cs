using TeamProjectIAN6.Core.Models;

namespace TeamProjectIAN6.Persistence.Repositories
{
    public interface IFollowRestaurantRepository
    {
        void AddRestaurantFollowing(FollowRestaurant followRestaurant);
        bool CheckIfAlreadyFollows(string userId, int restaurntId);
    }
}