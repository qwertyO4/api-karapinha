using System.ComponentModel;

namespace minhaprimeiraapi.Enums
{
    public enum UserType
    {
        [Description("Não Registado")]
        NonRegistered  = 1,
        [Description("Registado")]
        Registered = 2,
        [Description("Administrador")]
        Admin = 3,
        [Description("Administrativo")]
        Administrative = 4
    }
}
