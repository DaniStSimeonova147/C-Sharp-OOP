namespace E04.BorderControl.Models
{
   public abstract class Entered
    {
        public Entered(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}
