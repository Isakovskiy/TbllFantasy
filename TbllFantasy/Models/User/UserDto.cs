using System.ComponentModel.DataAnnotations;

namespace TbllFantasy.Models;

public record UserDto([Required]string userName, [Required]string password);