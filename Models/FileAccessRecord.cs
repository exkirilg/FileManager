using System;
using System.ComponentModel.DataAnnotations;

namespace FileManager.Models;

public class FileAccessRecord
{
    [Key]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string FileName { get; set; }

    [Required]
    public DateTime AccessDateTime { get; set; }
}
