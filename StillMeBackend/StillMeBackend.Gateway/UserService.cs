using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StillMeBackend.Gateway.DTO;

namespace StillMeBackend.Gateway;

public class UserService
{
    private readonly UserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(UserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public List<UserViewDto> GetUsersByEmailPhoneName(string pattern)
    {
        return GetUsersByName(pattern).Concat(GetUsersByNumber(pattern)).Concat(GetUsersByEmail(pattern)).ToList();
    }
    
    public IEnumerable<UserViewDto> GetUsersByName(string pattern)
    {
        var users = _userRepository.GetUsers();
        return _mapper.Map<IEnumerable<UserViewDto>>(users.Where(u => u.UserName.StartsWith(pattern)));
    } 
    
    public IEnumerable<UserViewDto> GetUsersByEmail(string pattern)
    {
        var users = _userRepository.GetUsers();
        return _mapper.Map<IEnumerable<UserViewDto>>(users.Where(u => u.Email.StartsWith(pattern)));
    } 
    
    public IEnumerable<UserViewDto> GetUsersByNumber(string pattern)
    {
        var users = _userRepository.GetUsers();
        return _mapper.Map<IEnumerable<UserViewDto>>(users.Where(u => u.PhoneNumber.StartsWith(pattern)));
    } 
}