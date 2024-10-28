namespace BlazorAuth.Data 
{
    public class UserService 
    {
        private readonly AppDbContext context;
        public UserService(AppDbContext context)
        {
            this.context = context; 
        }
        public bool SaveUser(User user)
        {
            bool isExist = context.Users.Any(x => x.Email == user.Email);
            if (!isExist)
            {
                context.Add(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public User? Verify(string email, string password)
        {
            return context.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password);
        }
    }
}