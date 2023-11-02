using System;
using System.Text;

namespace Animals
{
   public class Animal : SoundProducable
    {
        private string name;
        private int age;
        private Gender gender;


        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        private string Name
        {
             set
            {
               
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        private int Age
        {
            set
            {
                if (value <=0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        private string Gender
        {
            set
            {
                Gender gender;

                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || !Enum.TryParse<Gender>(value, out gender))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = gender;
            }
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(this.GetType().Name);
            result.AppendLine($"{this.name} {this.age} {this.gender.ToString()}");
            result.AppendLine(this.ProduceSound());

            return result.ToString().TrimEnd();
        }
    }
}
