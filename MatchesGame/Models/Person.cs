using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MatchesGame.Models
{
    public class Person : IEquatable<Person>
    {
        public Person(string Name, string Gender)
        {
            this.Name = Name;
            this.Gender = Gender;
        }

        public string Name { get; set; }
        public string Gender { get; set; }

        public bool Equals([AllowNull] Person other)
        {
            if (Name == other.Name && Gender == other.Gender)
                return true;

            return false;
            
        }

        public override int GetHashCode()
        {

            int hashName = Name == String.Empty ? 0 : Name.GetHashCode();
            int hashGender = Gender == string.Empty ? 0 : Gender.GetHashCode();

            return hashName ^ hashGender;
        }
    }
}
