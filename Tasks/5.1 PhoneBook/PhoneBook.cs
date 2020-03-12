namespace Tasks
{
    //Direct mapping
    public class PhoneBook
    {
        private readonly string[] _contacts;

        public PhoneBook()
        {
            _contacts = new string[10_000_000];
        }

        public void Add(string number, string name)
        {
            _contacts[int.Parse(number)] = name;
        }

        public string Find(string number) => _contacts[int.Parse(number)] ?? "not found";

        public void Delete(string number)
        {
            _contacts[int.Parse(number)] = null;
        }
    }
}
