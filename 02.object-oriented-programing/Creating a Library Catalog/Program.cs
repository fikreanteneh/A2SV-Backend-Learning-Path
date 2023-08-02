// See https://aka.ms/new-console-template for more information


class Program {
    public static void Main(){

        Library aberehot = new Library("Aberehot", "4 kilo, Addis Ababa");

        Book[] myBooks = new Book[10]; 
        MediaItem[] myMediaItems = new MediaItem[10]; 

        for (int i = 0; i < 10; i++){
            myBooks[i] = new Book($"Book {i}", $"Author {i}", $"ISBN {i}", 2000 + i);
            myMediaItems[i] = new MediaItem($"MediaItem {i}", $"Media Type CD", 20);
        }

        aberehot.AddBook(myBooks);
        aberehot.AddMediaItem(myMediaItems);
        aberehot.RemoveBook(0, "Yess");
        Console.WriteLine(aberehot);
        Console.WriteLine(aberehot.Books[0]);


    }
}
