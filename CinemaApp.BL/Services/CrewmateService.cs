using AutoMapper;
using CinemaApp.BL.DTOs.CrewDTOs.Crewmate;
using CinemaApp.BL.Interfaces;
using CinemaApp.BL.Interfaces.ServiceInterfaces;
using CinemaApp.DAL.Entities;
using CinemaApp.DAL.Repositories;
using FluentValidation;

namespace CinemaApp.BL.Services
{
    public class CrewmateService : ICrewmateService
    {
        private readonly IRepository<Crewmate> _crewmateRepository;
        private readonly IMapper _mapper;

        private readonly IValidator<CrewmateCreateDto> _createValidator;
        private readonly IValidator<CrewmateUpdateDto> _updateValidator;

        public CrewmateService(IValidator<CrewmateCreateDto> createValidator, IValidator<CrewmateUpdateDto> updateValidator, IRepository<Crewmate> crewmateRepository, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _crewmateRepository = crewmateRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CrewmateDto>> GetAllCrewmatesAsync()
        {
            var crewmates = await _crewmateRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CrewmateDto>>(crewmates);
        }

        public async Task<CrewmateDto> GetCrewmateByIdAsync(int id)
        {
            var crewmate = await _crewmateRepository.GetByIdAsync(id);
            return _mapper.Map<CrewmateDto>(crewmate);
        }

        public async Task AddCrewmateAsync(CrewmateCreateDto crewmateCreateDto)
        {
            var validationResult = await _createValidator.ValidateAsync(crewmateCreateDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var crewmate = _mapper.Map<Crewmate>(crewmateCreateDto);
            await _crewmateRepository.AddAsync(crewmate);
        }

        public async Task UpdateCrewmateAsync(int id, CrewmateUpdateDto crewmateUpdateDto)
        {
            var crewmate = await _crewmateRepository.GetByIdAsync(id);
            _mapper.Map(crewmateUpdateDto, crewmate);
            await _crewmateRepository.UpdateAsync(crewmate);
        }

        public async Task DeleteCrewmateByIdAsync(int id)
        {
            await _crewmateRepository.DeleteByIdAsync(id);
        }
    }
}
