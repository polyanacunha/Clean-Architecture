namespace CleanArchMvc.Domain.Account
{
    public interface ISeedUserRoleInitial
    {//to implement the inclusion of users and roles in the identity tables
        void SeedUSers();
        void SeedRoles();
    }
}