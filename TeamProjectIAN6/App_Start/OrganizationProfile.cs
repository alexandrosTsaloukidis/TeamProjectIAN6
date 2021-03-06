﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Core.Dtos;
using TeamProjectIAN6.Core.Models;

using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.App_Start
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Education, EducationDto>();
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Area, AreaDto>();
            CreateMap<Location, LocationDto>();
            CreateMap<FollowRestaurant, FollowRestaurantDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}