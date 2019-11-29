namespace CetLibrary.Data
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanChangePassword { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}