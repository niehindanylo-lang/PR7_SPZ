using System;

namespace WinFormsApp7
{
    public class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int BirthYear { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public bool IsStudent { get; set; }
        public bool HasDriverLicense { get; set; }

        public int Age
        {
            get
            {
                return 2026 - BirthYear;
            }
        }

        public double GetBMI()
        {
            return Height > 0 ? Weight / (Height * Height) : 0;
        }
    }
}