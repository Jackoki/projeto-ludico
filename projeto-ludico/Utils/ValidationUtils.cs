namespace projeto_ludico.Utils
{
    public static class ValidationUtils
    {
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public static bool IsValidAge(int age)
        {
            return age >= 0 && age <= 120;
        }

        public static bool IsValidEmail(string email)
        {
            return email.Contains("@");
        }
    }
}
