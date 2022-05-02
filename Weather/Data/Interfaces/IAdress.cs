namespace Weather.Data.Interfaces
{
    public interface IAdress
    {   
       
        public string Now(string city, string country);
        public string FewDays(string city, string country);
    }
}
