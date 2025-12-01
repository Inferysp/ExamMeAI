using ExamMeAI.Models;
using Humanizer.Localisation;

namespace ExamMeAI.Data
{
    public static class ExpliciteData
    {
        public static void Initialize(ExamMeAiContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Question.Any())
            {
                return;   // DB has been seeded
            }

            var question = new Question[]
            {
                new Question {QuestionText="Wymień podstawowe założenia programowania obiektowego.",TitleId=1,DomainId=1},
                new Question {QuestionText="Czym jest dziedziczenie, hermetyzacja, abstrakcja, polimorfizm: podaj przykłady (najlepiej z własnego doświadczenia). Z jakiej klasy niejawnie dziedziczą wszystkie klasy w .NET? Czy język C# obsługuje wielokrotne dziedziczenie?",TitleId=1,DomainId=1},
                new Question {QuestionText="Czym jest rekursja?",TitleId=1,DomainId=1},
                new Question {QuestionText="Czym jest wyrażenie lambda?",TitleId=1,DomainId=1},
                new Question {QuestionText="Czym są obliczenia równoległe (wielowątkowość) i do czego służą? Jakie klasy są stosowane?",TitleId=1,DomainId=1},
                new Question {QuestionText="Czym jest JSON?",TitleId=1,DomainId=1},
                new Question {QuestionText="Czym jest REST?",TitleId=1,DomainId=1},
                new Question {QuestionText="Opowiedz o SPA concept.",TitleId=1,DomainId=1},
                new Question {QuestionText="Z jakich wzorców projektowych GoF korzystałeś?",TitleId=1,DomainId=1},
                new Question {QuestionText="Na czym polega różnica między metodami GET i POST HTTP?",TitleId=1,DomainId=1},
                new Question {QuestionText="Jaki problem rozwiązuje Docker? Jakie ma zalety i wady?",TitleId=1,DomainId=1},
                new Question {QuestionText="Na czym polega zasadnicza różnica między testami jednostkowe (unit test) a testami integracyjnymi?",TitleId=1,DomainId=1},
                new Question {QuestionText="Czym jest Exception?",TitleId=2,DomainId=1},
                new Question {QuestionText="Do czego służy try, catch, finaly? W jakim przypadku blok finally nie wykonuje się?",TitleId=2,DomainId=1},
                new Question {QuestionText="Czym jest call stack? Jakie znasz słowa kluczowe?",TitleId=2,DomainId=1},
                new Question {QuestionText="Czym jest ASP.NET?",TitleId=3,DomainId=1},
                new Question {QuestionText="Jakie są typy Action filters?",TitleId=3,DomainId=1},
                new Question {QuestionText="Czym jest Web Service?",TitleId=3,DomainId=1},
                new Question {QuestionText="Czym jest CLR?",TitleId=3,DomainId=1},
                new Question {QuestionText="Czym jest Garbage Collection na poziomie podstawowym?",TitleId=3,DomainId=1},
                new Question {QuestionText="Czym jest delegat?",TitleId=3,DomainId=1},
                new Question {QuestionText="Czym się różni Delegate od Action?",TitleId=3,DomainId=1},
                new Question {QuestionText="Czym jest LINQ i do czego służy? Podaj kilka przykładów zastosowania LINQ.",TitleId=3,DomainId=1},
                new Question {QuestionText="Czym jest przestrzeń nazw (namespace) i do czego służy?",TitleId=3,DomainId=1},
                new Question {QuestionText="Jakie znasz typy danych?",TitleId=4,DomainId=1},
                new Question {QuestionText="Jakie znasz proste typy danych?",TitleId=4,DomainId=1},
                new Question {QuestionText="Czym jest typ Nullable?",TitleId=4,DomainId=1},
                new Question {QuestionText="Czym są typy referencyjne i typy wartości? Który jest class, a który struct? W jakim obszarze pamięci są przechowywane?",TitleId=4,DomainId=1},
                new Question {QuestionText="Czym się różni value od reference type? String to reference czy value?",TitleId=4,DomainId=1},
                new Question {QuestionText="Na czym polega różnica między string builder i string?",TitleId=4,DomainId=1},
                new Question {QuestionText="Czym są generyki (generics)? Jakie problemy rozwiązują?",TitleId=4,DomainId=1},
                new Question {QuestionText="Czym jest boxing/unboxing?",TitleId=4,DomainId=1},
                new Question {QuestionText="Czym jest Array, List, HashSet, Dictionary? Podaj przykłady zastosowania wymienionych struktur danych. Na czym polega trudność operacji (wyszukiwanie, wstawianie i usuwanie)?",TitleId=4,DomainId=1},
                new Question {QuestionText="Jakie znasz kolekcje?",TitleId=4,DomainId=1},
                new Question {QuestionText="Do czego służy operator yield?",TitleId=4,DomainId=1},
                new Question {QuestionText="Czym jest klasa?",TitleId=5,DomainId=1},
                new Question {QuestionText="Czym różni się klasa od klasy abstrakcyjnej?",TitleId=5,DomainId=1},
                new Question {QuestionText="Czym różni się klasa abstrakcyjna od interfejsu? Do czego służą interfejsy i jakie zadania wykonują?",TitleId=5,DomainId=1},
                new Question {QuestionText="Jakie znasz modyfikatory dostępu?",TitleId=5,DomainId=1},
                new Question {QuestionText="Na czym polega różnica między klasą zwykłą i statyczną?",TitleId=5,DomainId=1},
                new Question {QuestionText="Na czym polega różnica między nadpisywaniem metod a słowami kluczowymi new i override?",TitleId=5,DomainId=1},
                new Question {QuestionText="Na czym polega różnica między const a read only?",TitleId=5,DomainId=1},
                new Question {QuestionText="Jaka jest różnica między strukturą a klasą. Podaj przykłady struktur.",TitleId=5,DomainId=1},
                new Question {QuestionText="Czy może egzemplarz struktury przechowywać się w stercie (heap)? Jak to zrobić?",TitleId=5,DomainId=1},
                new Question {QuestionText="Czym jest asynchroniczność i czym się różni od wielowątkowości?",TitleId=6,DomainId=1},
                new Question {QuestionText="Jakie słowa kluczowe służą do programowania asynchronicznego?",TitleId=6,DomainId=1},
                new Question {QuestionText="Co oznaczają słowa kluczowe async/await?  ",TitleId=6,DomainId=1},
                new Question {QuestionText="Jaka jest różnica pomiędzy bazą relacyjną a nierelacyjną? Jakie są zalety i wady obu wariantów.",TitleId=7,DomainId=1},
                new Question {QuestionText="Czym są indeksy w RDBMS?",TitleId=7,DomainId=1},
                new Question {QuestionText="Jakie typy JOIN występują w SQL?",TitleId=7,DomainId=1},
                new Question {QuestionText="Do czego służą testy jednostkowe (unit test)? ",TitleId=8,DomainId=1},
                new Question {QuestionText="Zalety i wady testowania jednostkowego?",TitleId=8,DomainId=1},
                new Question {QuestionText="Z jakich trzech bloków logicznych składa się test jednostkowy?",TitleId=8,DomainId=1}
            };
            foreach (Question s in question)
            {
                context.Question.Add(s);
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
            foreach (Title c in title)
            {
                context.Title.Add(c);
            }
            context.SaveChanges();

            var domain = new Domain[]
            {
                new Domain{DomainName="JUNIOR"}
            };
            foreach (Domain e in domain)
            {
                context.Domain.Add(e);
            }
            context.SaveChanges();
        }
    }
}
