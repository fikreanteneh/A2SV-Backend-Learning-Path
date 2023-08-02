class Library {
    public string Name;
    public string Address;
    public  List<Book> Books = new List<Book>();
    public List<MediaItem> MediaItems = new List<MediaItem>();

    public Library(string aName, string aAddress) {
        Name = aName;
        Address = aAddress;
    }

    public override String ToString() {
        return $"{Name} is located at {Address} and has {Books.Count} books and {MediaItems.Count} media items.";
    }
    public void PrintCataloge(){
        Console.WriteLine($"Cataloge for {Name}");
        Console.WriteLine("Books:");
        foreach(Book book in Books){
            Console.WriteLine($"\t{book}");
        }
        Console.WriteLine("Media Items:");
        foreach(MediaItem mediaItem in MediaItems){
            Console.WriteLine($"\t{mediaItem}");
        }
    }

    public void AddBook(Book aBook) {
        Books.Add(aBook);
    }
    public void AddBook(Book[] aBooks) {
        foreach(Book book in aBooks){
            Books.Add(book);
        }
    }
    public void AddBook(string aTitle, string aAuthor, string aISBN, int aPublicationYear) {
        Books.Add(new Book(aTitle, aAuthor, aISBN, aPublicationYear));
    }
    public void AddBook(params Object[] books){
        Console.WriteLine("Please Inser a Book or List Of Books");
    }



    public void AddMediaItem(MediaItem aMediaItem) {
        MediaItems.Add(aMediaItem);
    }
    public void AddMediaItem(MediaItem[] aMediaItems) {
        foreach(MediaItem mediaItem in aMediaItems){
            MediaItems.Add(mediaItem);
        }
    }
    public void AddMediaItem(string aTitle, string aMediaType, int aDuration) {
        MediaItems.Add(new MediaItem(aTitle, aMediaType, aDuration));
    }

    public void AddMediaItem(params Object[] mediaItems){
        Console.WriteLine("Please Inser a Media Item or List Of Media Items");
    }



    public void RemoveBook(Book aBook) {
        Books.Remove(aBook);
    }
    public void RemoveBook(string aISBN) {
        Book? toRemove = Books.Find(book => book.ISBN == aISBN);
        if (toRemove != null){
            Books.Remove(toRemove);
        }
    }
    public void RemoveBook(Book[] aBooks) {
        foreach(Book book in aBooks){
            Books.Remove(book);
        }
    }
    public void RemoveBook(string[] aISBNs) {
        foreach(string isbn in aISBNs){
            Book? toRemove = Books.Find(book => book.ISBN == isbn);
            if (toRemove != null){
                Books.Remove(toRemove);
            }
        }
    }
    public void RemoveBook(params Object[] books){
        Console.WriteLine("Please Inser a Book or List Of Books");
    }    


    public void RemoveMediaItem(MediaItem aMediaItem) {
        MediaItems.Remove(aMediaItem);
    }
    public void RemoveMediaItem(params Object[] mediaItems){
        Console.WriteLine("Please Inser a Media Item or List Of Media Items");
    }

    public List<Book> SearchBooksByTitle(string aTitle){
        return Books.FindAll(book => book.Title.Contains(aTitle));
    }
    public List<Book> SearchBooksByYear(int aPublicationYear){
        return Books.FindAll(book => book.PublicationYear == aPublicationYear);
    }
    public List<Book> SearchBooksByISBN(string aISBN){
        return Books.FindAll(book => book.ISBN.Contains(aISBN));
    }
    public List<Book> SearchBooksByAuthor(string aAuthor){
        return Books.FindAll(book => book.Author.Contains(aAuthor));
    }


    public List<MediaItem> SearchMediaItemsByTitle(string aTitle){
        return MediaItems.FindAll(mediaItem => mediaItem.Title.Contains(aTitle));
    }
    public List<MediaItem> SearchMediaItemsByMediaType(string aMediaType){
        return MediaItems.FindAll(mediaItem => mediaItem.MediaType.Contains(aMediaType));
    }
    public List<MediaItem> SearchMediaItemsByDuration(int aDuration){
        int leftDuration = aDuration - 5;
        int rightDuration = aDuration + 5;
        return MediaItems.FindAll(mediaItem => leftDuration <= mediaItem.Duration && mediaItem.Duration <= rightDuration);
    }

}