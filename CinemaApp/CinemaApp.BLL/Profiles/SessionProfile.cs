﻿using AutoMapper;
using CinemaApp.Common.Dtos.SessionDtos;
using CinemaApp.Domain;

namespace CinemaApp.BLL.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<Session, SessionReadDto>();
            CreateMap<SessionCreateDto, Session>();
            CreateMap<SessionUpdateDto, Session>();
            CreateMap<SessionPartialUpdateDto, Session>();
        }
    }
}
