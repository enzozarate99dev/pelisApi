using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NetTopologySuite.Geometries;
using pelisApi.DTOs;
using pelisApi.Entidades;

namespace pelisApi.Utilidades
{
    public class AutomapperProfiles: Profile
    {
        public AutomapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<Actor, GeneroDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO, Actor>();
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<ActorCreacionDTO, Actor>()        
            .ForMember(x => x.Foto, options => options.Ignore()); //ignorar foto

            CreateMap<CineCreacionDTO, Cine>()
            .ForMember(x => x.Ubicacion, x => x.MapFrom(dto =>
            geometryFactory.CreatePoint(new Coordinate(dto.Latitud, dto.Longitud))));

            CreateMap<Cine, CineDTO>()
            .ForMember(x => x.Latitud, dto => dto.MapFrom(campo => campo.Ubicacion.Y))
            .ForMember(x => x.Longitud, dto => dto.MapFrom(campo => campo.Ubicacion.X));

        }
    }
}