using AutoMapper;
using BillingSystem.Application.DTOs.V1.Admins;
using BillingSystem.Application.Interfaces;
using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;
using FluentResults;
using FluentValidation;

namespace BillingSystem.Application.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<AdminCreateDto> _validator;

    public AdminService(IAdminRepository adminRepository, IMapper mapper,
        IValidator<AdminCreateDto> validator)
    {
        _adminRepository = adminRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<AdminDto>> GetAdminByIdAsync(Guid id)
    {
        var admin = await _adminRepository.GetByIdAsync(id);
        if (admin == null)
            return Result.Fail<AdminDto>("Admin not found");

        var dto = _mapper.Map<AdminDto>(admin);
        return Result.Ok(dto);
    }

    public async Task<Result<IEnumerable<AdminListDto>>> GetAllAdminsAsync()
    {
        var admins = await _adminRepository.GetAllAsync();

        if (!admins.Any())
            return Result.Fail<IEnumerable<AdminListDto>>("No admins found");

        var dtoList = _mapper.Map<IEnumerable<AdminListDto>>(admins);
        return Result.Ok(dtoList);
    }

    public async Task<Result<AdminDto>> CreateAdminAsync(AdminCreateDto adminCreateDto)
    {
        var validationResult = await _validator.ValidateAsync(adminCreateDto);
        if (!validationResult.IsValid)
            return Result.Fail<AdminDto>("Invalid or missing fields");

        var admin = _mapper.Map<ApplicationUser>(adminCreateDto);
        await _adminRepository.AddAsync(admin);

        var resultDto = _mapper.Map<AdminDto>(admin);
        return Result.Ok(resultDto);
    }

    public async Task<Result<AdminDto>> UpdateAdminAsync(AdminUpdateDto dto)
    {
        var admin = await _adminRepository.GetByIdAsync(dto.Id);
        if (admin == null)
            return Result.Fail<AdminDto>("Admin not found");

        if (!string.IsNullOrWhiteSpace(dto.UserName))
            admin.UserName = dto.UserName;

        if (!string.IsNullOrWhiteSpace(dto.Email))
            admin.Email = dto.Email;

        if (!string.IsNullOrWhiteSpace(dto.FirstName))
            admin.FirstName = dto.FirstName;

        if (!string.IsNullOrWhiteSpace(dto.LastName))
            admin.LastName = dto.LastName;

        if (!string.IsNullOrWhiteSpace(dto.Address))
            admin.Address = dto.Address;

        if (dto.DateOfBirth.HasValue)
            admin.DateOfBirth = dto.DateOfBirth;

        admin.UpdatedAt = DateTime.UtcNow;

        await _adminRepository.UpdateAsync(admin);

        var resultDto = _mapper.Map<AdminDto>(admin);
        return Result.Ok(resultDto);
    }

    public async Task<Result<bool>> DeleteAdminAsync(Guid id)
    {
        var exists = await _adminRepository.ExistsAsync(id);
        if (!exists)
            return Result.Fail<bool>("Admin not found");

        var success = await _adminRepository.DeleteAsync(id);
        if (!success)
            return Result.Fail<bool>("Failed to delete admin");

        return Result.Ok(true);
    }
}
