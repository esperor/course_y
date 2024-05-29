using System.Diagnostics;
using System.Security.Cryptography;
using System.Data.Entity;

namespace course.Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(InsuranceCompanyContext context)
        {
            context.Database.EnsureCreated();

            context.Database.BeginTransaction();

            try
            {
                // Look for any agents.
                if (context.Agents.Any())
                {
                    return;   // DB has been seeded
                }

                var agents = new Agent[]
                {
                new Agent{ID=RandomNumberGenerator.GetInt32(10000),Passport="2312567121",DateHired=DateOnly.Parse("2005-09-01"),Email=GenerateRandomEmail(),Phone="89823232184"},
                new Agent{ID=RandomNumberGenerator.GetInt32(10000),Passport="2515523291",DateHired=DateOnly.Parse("2002-09-01"),Email=GenerateRandomEmail(),Phone="89825292184"},
                new Agent{ID=RandomNumberGenerator.GetInt32(10000),Passport="2213183451",DateHired=DateOnly.Parse("2003-09-01"),Email=GenerateRandomEmail(),Phone="89823822184"},
                new Agent{ID=RandomNumberGenerator.GetInt32(10000),Passport="2122569371",DateHired=DateOnly.Parse("2002-09-01"),Email=GenerateRandomEmail(),Phone="89765212184"},
                };
                foreach (Agent s in agents)
                {
                    context.Agents.Add(s);
                }
                context.SaveChanges();

                var clients = new Client[]
                {
                new Client{ID=RandomNumberGenerator.GetInt32(10000),Name=GenerateRandomFio(),Email=GenerateRandomEmail(),Phone="89823232184",INN=$"5902{RandomNumberGenerator.GetInt32(1000000, 9999999)}"},
                new Client{ID=RandomNumberGenerator.GetInt32(10000),Name=GenerateRandomFio(),Email=GenerateRandomEmail(),Phone="89827932184",INN=$"5902{RandomNumberGenerator.GetInt32(1000000, 9999999)}"},
                new Client{ID=RandomNumberGenerator.GetInt32(10000),Name=GenerateRandomFio(),Email=GenerateRandomEmail(),Phone="89823263968",INN=$"5902{RandomNumberGenerator.GetInt32(1000000, 9999999)}"},
                new Client{ID=RandomNumberGenerator.GetInt32(10000),Name=GenerateRandomFio(),Email=GenerateRandomEmail(),Phone="89812232181",INN=$"5902{RandomNumberGenerator.GetInt32(1000000, 9999999)}"},
                new Client{ID=RandomNumberGenerator.GetInt32(10000),Name=GenerateRandomFio(),Email=GenerateRandomEmail(),Phone="89823847184",INN=$"5902{RandomNumberGenerator.GetInt32(1000000, 9999999)}"},
                new Client{ID=RandomNumberGenerator.GetInt32(10000),Name=GenerateRandomFio(),Email=GenerateRandomEmail(),Phone="89823265282",INN=$"5902{RandomNumberGenerator.GetInt32(1000000, 9999999)}"},
                new Client{ID=RandomNumberGenerator.GetInt32(10000),Name=GenerateRandomFio(),Email=GenerateRandomEmail(),Phone="89829842184",INN=$"5902{RandomNumberGenerator.GetInt32(1000000, 9999999)}"}
                };
                foreach (Client c in clients)
                {
                    context.Clients.Add(c);
                }
                context.SaveChanges();

            } catch (Exception ex)
            {
                context.Database.RollbackTransaction();
                throw ex;
            }

            context.Database.CommitTransaction();
        }

        private readonly static char[] alphabet =
            [
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
                'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                'y', 'z'
            ];

        private readonly static string[] domains =
            [
                "mail.ru", "gmail.com", "yandex.ru"
            ];

        private static string GenerateRandomEmail()
        {
            int usernameLength = RandomNumberGenerator.GetInt32(5, 10);

            string username = "";

            for(int i = 0; i < usernameLength; i++) 
                username = $"{username}{alphabet[RandomNumberGenerator.GetInt32(alphabet.Length)]}";

            return $"{username}@{domains[RandomNumberGenerator.GetInt32(domains.Length)]}";
        }


        private readonly static string[] names =
            [
                "Александр", "Виктор", "Михаил", "Арсений", "Вадим", "Никита"
            ];
        private readonly static string[] surnames =
            [
                "Александров", "Смирнов", "Иванов", "Астахов", "Невзоров", "Мельников"
            ];
        private readonly static string[] patronymics =
            [
                "Александрович", "Андреевич", "Иванович", "Арсениевич", "Анатольевич", "Сергеевич"
            ];

        private static string GenerateRandomFio()
        {
            var surname = surnames[RandomNumberGenerator.GetInt32(surnames.Length)];
            var name = names[RandomNumberGenerator.GetInt32(names.Length)];
            var patronymic = patronymics[RandomNumberGenerator.GetInt32(patronymics.Length)];
            return $"{surname} {name} {patronymic}";
        }
    }
}
