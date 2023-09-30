using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Assignment_1_Dahyun_Ko.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage ="Student's first name is required.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Student's last name is required.")]
        public string? LastName { get; set;}

        [Required(ErrorMessage = "Student's date of birth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Student's GPA is required.")]
        [Range(0.0, 4.0, ErrorMessage ="GPA must be between 0.0 and 4.0.")]
        public double GPA { get; set; }

        public string GPAScale { get; set; }

        public Student(int studentId, string? firstName, string? lastName, DateTime dateOfBirth, double GPA)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            this.GPA = GPA;
            GPAScale = GetGPAScale(GPA);
        }

        public string GetGPAScale(double GPA)
        {
            string GPAScale;

            if (GPA == 4.0)
            {
                GPAScale = "Excellence";
            }
            else if (GPA >= 3.5 && GPA < 4.0)
            {
                GPAScale = "Very Good";
            }
            else if (GPA >= 3.0 && GPA < 3.5)
            {
                GPAScale = "Good";
            }
            else if (GPA >= 2.5 && GPA < 3.0)
            {
                GPAScale = "Satisfactory";
            }
            else
            {
                GPAScale = "Unsatisfactory";
            }

            return GPAScale;
        }

        public string Slug =>   $"{FirstName}-{LastName}".ToLower();
    }
}
