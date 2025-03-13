namespace ConsoleApp1
{
    public static class Extensions
    {
        /// <summary>
        /// Rearrange the elements of a sequence in random order.
        /// N.B. It's random, so writing a unit test will be difficult.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var array = source.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                // Using the Fisher-Yates shuffle algorithm
                var randomIndex = new Random().Next(i, array.Length);
                (array[randomIndex], array[i]) = (array[i], array[randomIndex]);
            }
            return array;
        }
        /// <summary>
        /// guess = "guess" (example)
        //  response = "ggyyb" (example) (b=letter not in word,
        //                               y=letter in word but not in correct position,
        //                               g=letter in correct position)>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="guess"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public static IEnumerable<string> ApplyClue(this IEnumerable<string> source, string guess, string response)
        {
            var ret = source;

            IEnumerable<(char First, char Second)> r = guess.Zip(response);
            foreach (var  (letter,flag /*gy or b*/,i) in r.Select(((char f,char s) d, int i) => (d.f, d.s, i)))
            {
                // TODO handle cases where the word contains more than one of the same letter
                switch (flag)
                {
                    case 'g':
                        ret = ret.Where(x => x[i] == letter);
                        continue;
                    case 'y':
                        ret = ret.Where(x => x.Contains(letter));
                        continue;
                    default: // i.e. 'b'
                        ret = ret.Where(x => !x.Contains(letter));
                        continue;
                }
            }
            return ret;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var filename = "combined_wordlist.txt";

            var file = File.ReadLines(filename).Skip(1);


            foreach (var line in file.Shuffle() // EXERCISE: is this the best place to call Shuffle?


                // plume, bbbbg

                .ApplyClue("plume", "bbbbg")
                // brane, bbbbg
                .ApplyClue("brane", "bbbbg")
                // wedge, bybbg
                // TODO BUG FIX .ApplyClue("wedge", "bybbg")
                // It should do the following:
                .Where(x => !x.Contains("w")
                            && x.Count(l => l=='e')>1
                            &&!x.Contains("d")
                            && !x.Contains("g")
                            && x[4] == 'e')
                .Take(10))
            {
                Console.WriteLine(line);
            }

        }
    }
}
