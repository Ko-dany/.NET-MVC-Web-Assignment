/*
 * Program: PROG2230-SEC4
 * Purpose: Assignment 1
 * Revision History:
 *      created by Dahyun Ko, Oct/03/2023
 */

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Assignment_1_Dahyun_Ko.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage ="Please enter a first name.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string? LastName { get; set;}

        [Required(ErrorMessage = "Please enter a date of birth.")]
        public DateTime DateOfBirth { get; set; }

        private double _gpa;

        [Range(0.0, 4.0, ErrorMessage ="GPA values must be decimal values between 0.0 and 4.0.")]
        public double GPA {
            get { return _gpa; }
            set
            {
                _gpa= value;
                GPAScale = GetGPAScale(_gpa);
            }
        }

        public string? GPAScale { get; set; }

        [Required(ErrorMessage = "Please select a program of study")]
        public string? ProgramId { get; set; }

        public Program? Program { get; set; }


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

        public int GetCurrentAge()
        {
            DateTime currentDate = DateTime.Now;
            int currentAge = currentDate.Year - DateOfBirth.Year;
            if (currentDate.Month < DateOfBirth.Month || (currentDate.Month == DateOfBirth.Month && currentDate.Day < DateOfBirth.Day))
            {
                currentAge--;
            }
            return currentAge;
        }

        public string Slug =>   $"{FirstName}-{LastName}".ToLower();
    }
}
