class Task2{
    public static Dictionary<char, int> counter(string s) {
        var count = new Dictionary<char, int>();
        foreach(char a in s) {
            if (char.IsLetter((a))) {
                count.TryGetValue(a, out int value);
                count[a] = value + 1;
            }
        }
        return count;
    }
}