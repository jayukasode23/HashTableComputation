using HashTableProgram;
using System;

namespace HashTableDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hash table demo"); //() []
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            hash.Add("0", "To");
            hash.Add("1", "be");
            hash.Add("2", "or");
            hash.Add("3", "not");
            hash.Add("4", "to");
            hash.Add("5", "be");
            string hash5 = hash.Get("2");
            Console.WriteLine("5th index value: " + hash5);
            string hash2 = hash.Get("2");



            FrequancyPharse<string, string> hash1 = new FrequancyPharse<string, string>(20);
            String sentence = "Paranoids Are Not Paranoid Because They Are Paranoid But Because They Keep Putting Themselves Deliberately Into Paranoid Avoidable Situations";

            //split is splitting a string into an array of substrings separated by a character
            string[] Phrase = sentence.Split(' ');
            int SLength = Phrase.Length;
            // Itreating along each word and adding it to hash set
            for (int i = 0; i < SLength; i++)
            {
                hash1.Add(Convert.ToString(i), Phrase[i]);
            }
            //iterating through each loop to get the frequency of each word in the sentence
            foreach (string word in Phrase)
            {
                hash1.GetFrequency(word);
            }



            RemovePhrase<string, string> hash3 = new RemovePhrase<string, string>(20);
            String sentence1= "Paranoids Are Not Paranoid Because They Are Paranoid But Because They Keep Putting Themselves Deliberately Into Paranoid Avoidable Situations";
            string[] Phrase1 = sentence1.Split(' ');
            int SLength1 = Phrase1.Length;
            // Itreating along each word and adding it to hash set
            for (int i = 0; i < SLength1; i++)
            {
                hash3.Add(Convert.ToString(i), Phrase1[i]);
            }
            Console.WriteLine(" Now 'Avoidable' word removing from the hash table ");
            hash3.Remove("Avoidable");
            Console.WriteLine("Frequency of 'Avoidable' after removal is :" + hash3.GetFrequency("Avoidable"));
           
        }
    }
}