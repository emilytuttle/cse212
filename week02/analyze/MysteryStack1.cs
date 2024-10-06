public static class MysteryStack1 {
    public static string Run(string text) {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}

// racecar
//racecar

//stressed
//desserts

//a nut for a jar of tuna
// anut fo raj a rof tun a