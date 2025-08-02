namespace _10.SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();


            string command = string.Empty;
            while ((command = Console.ReadLine()) != "course start")
            {
                string[] commandArgs = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string lessonTitle = commandArgs[1];

                switch (commandArgs[0])
                {
                    case "Add":
                        if (!lessons.Contains(lessonTitle))
                        {
                            lessons.Add(lessonTitle);
                        }

                            break;

                    case "Insert":
                        if (!lessons.Contains(lessonTitle))
                        {
                            int index = int.Parse(commandArgs[2]);
                            lessons.Insert(index, lessonTitle);
                        }

                        break;

                    case "Remove":
                        lessons = RemoveLesson(lessons, lessonTitle);
                        break;

                    case "Swap":
                        
                        string secondLesson = commandArgs[2];
                        if (lessons.Contains(lessonTitle) && lessons.Contains(secondLesson))
                        {
                            lessons = SwapLessons(lessons, lessonTitle, secondLesson);
                        }

                        break;

                    case "Exercise":
                        lessons = AddExercise(lessons, lessonTitle);
                        break;
                }
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i+1}.{lessons[i]}");
            }
        }

        static List<string> RemoveLesson(List<string> lessons, string lessonTitle)
        {
            lessons.Remove(lessonTitle);

            string exerciseTitle = $"{lessonTitle}-Exercise";
            lessons.Remove(exerciseTitle);

            return lessons;
        }

        static List<string> SwapLessons(List<string> lessons, string firstLesson, string secondLesson)
        {
            int firstIndex = lessons.IndexOf(firstLesson);
            int secondIndex = lessons.IndexOf(secondLesson);

            lessons[firstIndex] = secondLesson;
            lessons[secondIndex] = firstLesson;

            string firstExercise = $"{firstLesson}-Exercise";
            string secondExercise = $"{secondLesson}-Exercise";

            int firstExerciseIndex = lessons.IndexOf(firstExercise);
            int secondExerciseIndex = lessons.IndexOf(secondExercise);

            if (firstExerciseIndex != -1 && secondExerciseIndex != -1)
            {
                lessons[firstExerciseIndex] = secondExercise;
                lessons[secondExerciseIndex] = firstExercise;
            }
            else if (firstExerciseIndex != -1)
            {
                lessons.Remove(firstExercise);
                lessons.Insert(secondIndex + 1, firstExercise);
            }
            else if (secondExerciseIndex != -1)
            {
                lessons.Remove(secondExercise);
                lessons.Insert(firstIndex + 1, secondExercise);
            }

            return lessons;
        }

        static List<string> AddExercise(List<string> lessons, string lessonTitle)
        {
            int lessonIndex = lessons.IndexOf(lessonTitle);
            string exerciseTitle = $"{lessonTitle}-Exercise";

            if (CheckForExercise(lessons, exerciseTitle))
            {
                return lessons;
            }

            if (lessonIndex == -1)
            {
                lessons.Add(lessonTitle);
                lessons.Add(exerciseTitle);
            }
            else if (lessonIndex == lessons.Count - 1) 
            {
                lessons.Add(exerciseTitle);
            }
            else
            {
                lessons.Insert(lessonIndex + 1, exerciseTitle);
            }

                return lessons;
        }

        static bool CheckForExercise(List<string> lessons, string  exerciseTitle)
        {
            if (lessons.Contains(exerciseTitle))
            {
                return true;
            }

            return false;
        }
            
    }
}
