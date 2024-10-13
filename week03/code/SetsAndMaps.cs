using System.Text.Json;


public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // List<string> list = new List<string>();
        // for (int i = 0; i < words.Length; i++) {
        //     var reverse = string.Join("", words[i].ToCharArray().Reverse());
        //     for (int j = 0; j < words.Length; j++) {
        //         if (words[j] == reverse && reverse[0] != reverse[1] && !list.Contains($"{words[i]} & {words[j]}")) {
        //             list.Add($"{words[j]} & {words[i]}");
        //             Console.WriteLine($"{words[j]} & {words[i]}");
        //         }
        //     }
        // } 
        // string[] myArray = list.ToArray();
        // return myArray;
        var uniqueHash = new HashSet<string>();
        List<string> list = new List<string>();
        foreach (string pair in words)
        {
            var reverse = string.Join("", pair.ToCharArray().Reverse());
            if (uniqueHash.Contains(reverse) && reverse[0] != reverse[1]) 
            {
                list.Add($"{reverse} & {pair}");
                Console.WriteLine($"{reverse} & {pair}");
            } else 
            {
                uniqueHash.Add(pair);
            }
        }
        
        string[] myArray = list.ToArray();
        return myArray;
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            string[] fields = line.Split(",");

            if (degrees.ContainsKey(fields[3])) {
                degrees[fields[3]] += 1;
            } else {
                degrees.Add(fields[3], 1);
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        Console.WriteLine("Before");
        Console.WriteLine(word1);
        word1 = String.Join("", word1.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        word2 = String.Join("", word2.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        var letters1 = new Dictionary<char, int>();
        var letters2 = new Dictionary<char, int>();

        char [] word1Arr = word1.ToLower().ToCharArray();
        char [] word2Arr = word2.ToLower().ToCharArray();

        Console.WriteLine("after");
        Console.WriteLine(word1);
        if (word1.Length != word2.Length) {
            return false;
        }
        
        for (int i = 0; i < word1Arr.Length; i++) {
            bool space = Char.IsWhiteSpace(word1Arr[i]);
            if (!space) {
                if (letters1.ContainsKey(word1Arr[i])) {
                    letters1[word1Arr[i]] += 1;
                } else {
                    letters1.Add(word1Arr[i], 1);
                }
            }
            
        }

        for (int i = 0; i < word2Arr.Length; i++) {
            bool space = Char.IsLetter(word2Arr[i]);
            if (space) {
                if (letters2.ContainsKey(word2Arr[i])) {
                letters2[word2Arr[i]] += 1;
                } else {
                letters2.Add(word2Arr[i], 1);
            }
            }
            
        }
        

        bool areEqual = letters1.OrderBy(kv => kv.Key).SequenceEqual(letters2.OrderBy(kv => kv.Key));
        if (areEqual == true) {
            return true;
        } else {
            return false;
        }
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        List<string> strings = new List<string>();
    
        for ( int i = 1; i < featureCollection.Features.Count; i++) {
            strings.Add($"{featureCollection.Features[i].Properties.place} - Mag {featureCollection.Features[i].Properties.mag}");
            Console.WriteLine($"{featureCollection.Features[i].Properties.place} - Mag {featureCollection.Features[i].Properties.mag}");
        }
        // Console.WriteLine(featureCollection.Features[2].Properties.mag);
        // Console.WriteLine(featureCollection.Features[2].Properties.place);
        // Console.WriteLine($"Magnitude: ");
        string[] final = strings.ToArray();

        return final;
    }
}