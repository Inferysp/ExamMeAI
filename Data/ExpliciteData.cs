using ExamMeAI.Models;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;

namespace ExamMeAI.Data
{
    public static class ExpliciteData
    {
        public static void Initialize(ExamMeAiContext context)
        {
            context.Database.EnsureCreated();

            // Apply any pending migrations (create DB if missing)
            //context.Database.Migrate();

            if (context.Questions.Any())
            {
                return;   // DB has been seeded
            }



            var domain = new Domain[]
            {
                new Domain{Name=".NET"}
            };
            foreach (Domain e in domain)
            {
                context.Domain.Add(e);
            }
            context.SaveChanges();



            var title = new Title[]
{
                new Title{TitleText="Ogólne"},
                new Title{TitleText="Obsługa wyjątków"},

                new Title{TitleText="Platforma .NET"},

                new Title{TitleText="Typy danych, kolekcje i struktury danych"},

                new Title{TitleText="Klasy, struktury i interfejsy"},

                new Title{TitleText="Asynchroniczność"},

                new Title{TitleText="Bazy danych"},

                new Title{TitleText="Testy"}
};
            foreach (Title e in title)
            {
                context.Title.Add(e);
            }
            context.SaveChanges();



            var Questions = new Questions[]
            {
                new Questions{QuestionText="Wymień podstawowe założenia programowania obiektowego.",UserId = 1,TitleID=1,DomainID=1},
                new Questions{QuestionText="Czym jest dziedziczenie, hermetyzacja, abstrakcja, polimorfizm: podaj przykłady (najlepiej z własnego doświadczenia). Z jakiej klasy niejawnie dziedziczą wszystkie klasy w .NET? Czy język C# obsługuje wielokrotne dziedziczenie?",UserId = 1,           TitleID=1,DomainID=1},
                new Questions{QuestionText="Czym jest rekursja?",UserId = 1,TitleID=1,DomainID=1},
                new Questions{QuestionText="Czym jest wyrażenie lambda?",UserId = 1,TitleID=1,DomainID=1},
                new Questions{QuestionText="Czym są obliczenia równoległe (wielowątkowość) i do czego służą? Jakie klasy są stosowane?",UserId = 1,TitleID=1,DomainID=1},
                new Questions{QuestionText="Czym jest JSON?",UserId = 1, TitleID=1,DomainID=1},
                new Questions{QuestionText="Czym jest REST?",UserId = 1, TitleID=1,DomainID=1},
                new Questions{QuestionText="Opowiedz o SPA concept.",UserId = 1, TitleID=1,DomainID=1},
                new Questions{QuestionText="Z jakich wzorców projektowych GoF korzystałeś?",UserId = 1, TitleID=1,DomainID=1},
                new Questions{QuestionText="Na czym polega różnica między metodami GET i POST HTTP?",UserId = 1, TitleID=1,DomainID=1},
                new Questions{QuestionText="Jaki problem rozwiązuje Docker? Jakie ma zalety i wady?",   UserId = 1,    TitleID=1,DomainID=1},
                new Questions{QuestionText="Na czym polega zasadnicza różnica między testami jednostkowe (unit test) a testami integracyjnymi?",UserId = 1, TitleID=1,DomainID=1},
                new Questions{QuestionText="Czym jest Exception?",UserId = 1,TitleID=2,DomainID=1},
                new Questions{QuestionText="Do czego służy try, catch, finaly? W jakim przypadku blok finally nie wykonuje się?",UserId = 1, TitleID=2,DomainID=1},
                new Questions{QuestionText="Czym jest call stack? Jakie znasz słowa kluczowe?",UserId = 1, TitleID=2,DomainID=1},
                new Questions{QuestionText="Czym jest ASP.NET?",UserId = 1,TitleID=3,DomainID=1},
                new Questions{QuestionText="Jakie są typy Action filters?",UserId = 1,TitleID=3,DomainID=1},
                new Questions{QuestionText="Czym jest Web Service?",UserId = 1, TitleID=3,DomainID=1},
                new Questions{QuestionText="Czym jest CLR?",UserId = 1, TitleID=3,DomainID=1},
                new Questions{QuestionText="Czym jest Garbage Collection na poziomie podstawowym?",UserId = 1, TitleID=3,DomainID=1},
                new Questions{QuestionText="Czym jest delegat?",UserId = 1,TitleID=3,DomainID=1},
                new Questions{QuestionText="Czym się różni Delegate od Action?",UserId = 1,TitleID=3,DomainID=1},
                new Questions{QuestionText="Czym jest LINQ i do czego służy? Podaj kilka przykładów zastosowania LINQ.",UserId = 1,TitleID=3,DomainID=1},
                new Questions{QuestionText="Czym jest przestrzeń nazw (namespace) i do czego służy?",UserId = 1,TitleID=3,DomainID=1},
                new Questions{QuestionText="Jakie znasz typy danych?",UserId = 1,TitleID=4,DomainID=1},
                new Questions{QuestionText="Jakie znasz proste typy danych?",UserId = 1,TitleID=4,DomainID=1},
                new Questions{QuestionText="Czym jest typ Nullable?",UserId = 1,TitleID=4,DomainID=1},
                new Questions{QuestionText="Czym są typy referencyjne i typy wartości? Który jest class, a który struct? W jakim obszarze pamięci są przechowywane?",UserId = 1,TitleID=4,DomainID=1},
                new Questions{QuestionText="Czym się różni value od reference type? String to reference czy value?",UserId = 1,TitleID=4,DomainID=1},
                new Questions{QuestionText="Na czym polega różnica między string builder i string?",UserId = 1,TitleID=4,DomainID=1},
                new Questions{QuestionText="Czym są generyki (generics)? Jakie problemy rozwiązują?",UserId = 1,TitleID=4,DomainID=1},
                new Questions{QuestionText="Czym jest boxing/unboxing?",UserId = 1,TitleID=4,DomainID=1},
                new Questions{QuestionText="Czym jest Array, List, HashSet, Dictionary? Podaj przykłady zastosowania wymienionych struktur danych. Na czym polega trudność operacji (wyszukiwanie, wstawianie i usuwanie)?",UserId = 1,TitleID=4,DomainID=1},
                new Questions{QuestionText="Jakie znasz kolekcje?",UserId = 1,TitleID=4,DomainID=1},
                new Questions{QuestionText="Do czego służy operator yield?",UserId = 1,TitleID=4,DomainID=1},
                new Questions{QuestionText="Czym jest klasa?",UserId = 1,TitleID=5,DomainID=1},
                new Questions{QuestionText="Czym różni się klasa od klasy abstrakcyjnej?",UserId = 1,TitleID=5,DomainID=1},
                new Questions{QuestionText="Czym różni się klasa abstrakcyjna od interfejsu? Do czego służą interfejsy i jakie zadania wykonują?",UserId = 1,TitleID=5,DomainID=1},
                new Questions{QuestionText="Jakie znasz modyfikatory dostępu?",UserId = 1,TitleID=5,DomainID=1},
                new Questions{QuestionText="Na czym polega różnica między klasą zwykłą i statyczną?",UserId = 1,TitleID=5,DomainID=1},
                new Questions{QuestionText="Na czym polega różnica między nadpisywaniem metod a słowami kluczowymi new i override?",UserId = 1,TitleID=5,DomainID=1},
                new Questions{QuestionText="Na czym polega różnica między const a read only?",UserId = 1,TitleID=5,DomainID=1},
                new Questions{QuestionText="Jaka jest różnica między strukturą a klasą. Podaj przykłady struktur.",UserId = 1,TitleID=5,DomainID=1},
                new Questions{QuestionText="Czy może egzemplarz struktury przechowywać się w stercie (heap)? Jak to zrobić?",UserId = 1,TitleID=5,DomainID=1},
                new Questions{QuestionText="Czym jest asynchroniczność i czym się różni od wielowątkowości?",UserId = 1,TitleID=6,DomainID=1},
                new Questions{QuestionText="Jakie słowa kluczowe służą do programowania asynchronicznego?",UserId = 1,TitleID=6,DomainID=1},
                new Questions{QuestionText="Co oznaczają słowa kluczowe async/await?  ",UserId = 1,TitleID=6,DomainID=1},
                new Questions{QuestionText="Jaka jest różnica pomiędzy bazą relacyjną a nierelacyjną? Jakie są zalety i wady obu wariantów.",UserId = 1,TitleID=7,DomainID=1},
                new Questions{QuestionText="Czym są indeksy w RDBMS?",UserId = 1,TitleID=7,DomainID=1},
                new Questions{QuestionText="Jakie typy JOIN występują w SQL?",UserId = 1,TitleID=7,DomainID=1},
                new Questions{QuestionText="Do czego służą testy jednostkowe (unit test)? ",UserId = 1,TitleID=8,DomainID=1},
                new Questions{QuestionText="Zalety i wady testowania jednostkowego?",UserId = 1,TitleID=8,DomainID=1},
                new Questions{QuestionText="Z jakich trzech bloków logicznych składa się test jednostkowy?",UserId = 1,TitleID=8,DomainID=1}
            };
            foreach (Questions e in Questions)
            {
                context.Questions.Add(e);
            }
            context.SaveChanges();



        }
    }
}
