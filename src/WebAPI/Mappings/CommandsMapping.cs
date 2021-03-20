using AutoMapper;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Mappings
{
    public class CommandsMapping : Profile
    {
        public CommandsMapping()
        {
            // Source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
        }
    }
}