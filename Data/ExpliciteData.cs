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

            if (context.Question.Any())
            {
                return;   // DB has been seeded
            }

            var question = new Question[]
            {
                new Question{QuestionText="Wymień podstawowe założenia programowania obiektowego.",User = "system",TitleId=1,DomainId=1},
                new Question{QuestionText="Czym jest dziedziczenie, hermetyzacja, abstrakcja, polimorfizm: podaj przykłady (najlepiej z własnego doświadczenia). Z jakiej klasy niejawnie dziedziczą wszystkie klasy w .NET? Czy język C# obsługuje wielokrotne dziedziczenie?",User = "system",           TitleId=1,DomainId=1},
                new Question{QuestionText="Czym jest rekursja?",User = "system",TitleId=1,DomainId=1},
                new Question{QuestionText="Czym jest wyrażenie lambda?",User = "system",TitleId=1,DomainId=1},
                new Question{QuestionText="Czym są obliczenia równoległe (wielowątkowość) i do czego służą? Jakie klasy są stosowane?",User = "system",TitleId=1,DomainId=1},
                new Question{QuestionText="Czym jest JSON?",User = "system", TitleId=1,DomainId=1},
                new Question{QuestionText="Czym jest REST?",User = "system", TitleId=1,DomainId=1},
                new Question{QuestionText="Opowiedz o SPA concept.",User = "system", TitleId=1,DomainId=1},
                new Question{QuestionText="Z jakich wzorców projektowych GoF korzystałeś?",User = "system", TitleId=1,DomainId=1},
                new Question{QuestionText="Na czym polega różnica między metodami GET i POST HTTP?",User = "system", TitleId=1,DomainId=1},
                new Question{QuestionText="Jaki problem rozwiązuje Docker? Jakie ma zalety i wady?",   User = "system",    TitleId=1,DomainId=1},
                new Question{QuestionText="Na czym polega zasadnicza różnica między testami jednostkowe (unit test) a testami integracyjnymi?",User = "system", TitleId=1,DomainId=1},
                new Question{QuestionText="Czym jest Exception?",User = "system",TitleId=2,DomainId=1},
                new Question{QuestionText="Do czego służy try, catch, finaly? W jakim przypadku blok finally nie wykonuje się?",User = "system", TitleId=2,DomainId=1},
                new Question{QuestionText="Czym jest call stack? Jakie znasz słowa kluczowe?",User = "system", TitleId=2,DomainId=1},
                new Question{QuestionText="Czym jest ASP.NET?",User = "system",TitleId=3,DomainId=1},
                new Question{QuestionText="Jakie są typy Action filters?",User = "system",TitleId=3,DomainId=1},
                new Question{QuestionText="Czym jest Web Service?",User = "system", TitleId=3,DomainId=1},
                new Question{QuestionText="Czym jest CLR?",User = "system", TitleId=3,DomainId=1},
                new Question{QuestionText="Czym jest Garbage Collection na poziomie podstawowym?",User = "system", TitleId=3,DomainId=1},
                new Question{QuestionText="Czym jest delegat?",User = "system",TitleId=3,DomainId=1},
                new Question{QuestionText="Czym się różni Delegate od Action?",User = "system",TitleId=3,DomainId=1},
                new Question{QuestionText="Czym jest LINQ i do czego służy? Podaj kilka przykładów zastosowania LINQ.",User = "system",TitleId=3,DomainId=1},
                new Question{QuestionText="Czym jest przestrzeń nazw (namespace) i do czego służy?",User = "system",TitleId=3,DomainId=1},
                new Question{QuestionText="Jakie znasz typy danych?",User = "system",TitleId=4,DomainId=1},
                new Question{QuestionText="Jakie znasz proste typy danych?",User = "system",TitleId=4,DomainId=1},
                new Question{QuestionText="Czym jest typ Nullable?",User = "system",TitleId=4,DomainId=1},
                new Question{QuestionText="Czym są typy referencyjne i typy wartości? Który jest class, a który struct? W jakim obszarze pamięci są przechowywane?",User = "system",TitleId=4,DomainId=1},
                new Question{QuestionText="Czym się różni value od reference type? String to reference czy value?",User = "system",TitleId=4,DomainId=1},
                new Question{QuestionText="Na czym polega różnica między string builder i string?",User = "system",TitleId=4,DomainId=1},
                new Question{QuestionText="Czym są generyki (generics)? Jakie problemy rozwiązują?",User = "system",TitleId=4,DomainId=1},
                new Question{QuestionText="Czym jest boxing/unboxing?",User = "system",TitleId=4,DomainId=1},
                new Question{QuestionText="Czym jest Array, List, HashSet, Dictionary? Podaj przykłady zastosowania wymienionych struktur danych. Na czym polega trudność operacji (wyszukiwanie, wstawianie i usuwanie)?",User = "system",TitleId=4,DomainId=1},
                new Question{QuestionText="Jakie znasz kolekcje?",User = "system",TitleId=4,DomainId=1},
                new Question{QuestionText="Do czego służy operator yield?",User = "system",TitleId=4,DomainId=1},
                new Question{QuestionText="Czym jest klasa?",User = "system",TitleId=5,DomainId=1},
                new Question{QuestionText="Czym różni się klasa od klasy abstrakcyjnej?",User = "system",TitleId=5,DomainId=1},
                new Question{QuestionText="Czym różni się klasa abstrakcyjna od interfejsu? Do czego służą interfejsy i jakie zadania wykonują?",User = "system",TitleId=5,DomainId=1},
                new Question{QuestionText="Jakie znasz modyfikatory dostępu?",User = "system",TitleId=5,DomainId=1},
                new Question{QuestionText="Na czym polega różnica między klasą zwykłą i statyczną?",User = "system",TitleId=5,DomainId=1},
                new Question{QuestionText="Na czym polega różnica między nadpisywaniem metod a słowami kluczowymi new i override?",User = "system",TitleId=5,DomainId=1},
                new Question{QuestionText="Na czym polega różnica między const a read only?",User = "system",TitleId=5,DomainId=1},
                new Question{QuestionText="Jaka jest różnica między strukturą a klasą. Podaj przykłady struktur.",User = "system",TitleId=5,DomainId=1},
                new Question{QuestionText="Czy może egzemplarz struktury przechowywać się w stercie (heap)? Jak to zrobić?",User = "system",TitleId=5,DomainId=1},
                new Question{QuestionText="Czym jest asynchroniczność i czym się różni od wielowątkowości?",User = "system",TitleId=6,DomainId=1},
                new Question{QuestionText="Jakie słowa kluczowe służą do programowania asynchronicznego?",User = "system",TitleId=6,DomainId=1},
                new Question{QuestionText="Co oznaczają słowa kluczowe async/await?  ",User = "system",TitleId=6,DomainId=1},
                new Question{QuestionText="Jaka jest różnica pomiędzy bazą relacyjną a nierelacyjną? Jakie są zalety i wady obu wariantów.",User = "system",TitleId=7,DomainId=1},
                new Question{QuestionText="Czym są indeksy w RDBMS?",User = "system",TitleId=7,DomainId=1},
                new Question{QuestionText="Jakie typy JOIN występują w SQL?",User = "system",TitleId=7,DomainId=1},
                new Question{QuestionText="Do czego służą testy jednostkowe (unit test)? ",User = "system",TitleId=8,DomainId=1},
                new Question{QuestionText="Zalety i wady testowania jednostkowego?",User = "system",TitleId=8,DomainId=1},
                new Question{QuestionText="Z jakich trzech bloków logicznych składa się test jednostkowy?",User = "system",TitleId=8,DomainId=1}
            };
            foreach (Question e in question)
            {
                context.Question.Add(e);
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

            var domain = new Domain[]
            {
                new Domain{Name="JUNIOR"}
            };
            foreach (Domain e in domain)
            {
                context.Domain.Add(e);
            }
            context.SaveChanges();
        }
    }
}
