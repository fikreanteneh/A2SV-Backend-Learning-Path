class Library {
    private string Name;
    private string Address;
    private  List<Book> Books = new List<Book>();
    private List<MediaItem> MediaItems = new List<MediaItem>();

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

    //Check if ISBN already exists in the library
    public bool ISBNExists(Book aBook){
         if (Books.Exists(book => book.GetISBN == aBook.GetISBN)){
            Console.WriteLine($"Book with ISBN {aBook.GetISBN} already exists");
            return true;
         }
         return false;
    }


    //Add Book provides 3 ways to add a book
    //1. AddBook(Book aBook) - Add a book object
    public void AddBook(Book aBook) {
        if (ISBNExists(aBook)) return;
        Books.Add(aBook);
    }
    //2. AddBook(Book[] aBooks) - Add a list of book objects
    public void AddBook(Book[] aBooks) {
        foreach(Book book in aBooks){
            if (ISBNExists(book)) continue;
            Books.Add(book);
        }
    }
    //3. AddBook(string aTitle, string aAuthor, string aISBN, int aPublicationYear) - Add a book by providing the book details
    public void AddBook(string aTitle, string aAuthor, string aISBN, int aPublicationYear) {
        if (ISBNExists(new Book(aTitle, aAuthor, aISBN, aPublicationYear))) return;
        Books.Add(new Book(aTitle, aAuthor, aISBN, aPublicationYear));
    }
    //If the user provides a wrong input, the following method will be called
    public void AddBook(params Object[] books){
        Console.WriteLine("Please Insert a Book or List Of Books");
    }

    //Check if Title in the media already exists in the library
    bool TitleExist(MediaItem aMediaItem){
         if (MediaItems.Exists(mediaItem => mediaItem.GetTitle == aMediaItem.GetTitle)){
            Console.WriteLine($"MediaItem with Title {aMediaItem.GetTitle} already exists");
            return true;
         }
         return false;
    }

    //Add Media Item provides 3 ways to add a media item

    //1. AddMediaItem(MediaItem aMediaItem) - Add a media item object
    public void AddMediaItem(MediaItem aMediaItem) {
        if (TitleExist(aMediaItem)) return;
        MediaItems.Add(aMediaItem);
    }
    //2. AddMediaItem(MediaItem[] aMediaItems) - Add a list of media item objects
    public void AddMediaItem(MediaItem[] aMediaItems) {
        foreach(MediaItem mediaItem in aMediaItems){
            if (TitleExist(mediaItem)) continue;
            MediaItems.Add(mediaItem);
        }
    }
    //3. AddMediaItem(string aTitle, string aMediaType, int aDuration) - Add a media item by providing the media item details
    public void AddMediaItem(string aTitle, string aMediaType, int aDuration) {
        if (TitleExist(new MediaItem(aTitle, aMediaType, aDuration))) return;
        MediaItems.Add(new MediaItem(aTitle, aMediaType, aDuration));
    }

    //If the user provides a wrong input, the following method will be called
    public void AddMediaItem(params Object[] mediaItems){
        Console.WriteLine("Please Inser a Media Item or List Of Media Items");
    }


    //Remove Book provides 4 ways to remove a book
    //1. RemoveBook(Book aBook) - Remove a book object
    public void RemoveBook(Book aBook) {
        Books.Remove(aBook);
    }
    //2. RemoveBook(Book[] aBooks) - Remove a list of book objects
    public void RemoveBook(string aISBN) {
        Book? toRemove = Books.Find(book => book.GetISBN == aISBN);
        if (toRemove != null){
            Books.Remove(toRemove);
        }
    }
    //3. RemoveBook(string aISBN) - Remove a book by providing the ISBN
    public void RemoveBook(Book[] aBooks) {
        foreach(Book book in aBooks){
            Books.Remove(book);
        }
    }
    //4. RemoveBook(string[] aISBNs) - Remove a list of books by providing the ISBNs
    public void RemoveBook(string[] aISBNs) {
        foreach(string isbn in aISBNs){
            Book? toRemove = Books.Find(book => book.GetISBN == isbn);
            if (toRemove != null){
                Books.Remove(toRemove);
            }
        }
    }
    //If the user provides a wrong input, the following method will be called
    public void RemoveBook(params Object[] books){
        Console.WriteLine("Please Inser a Book or List Of Books");
    }    


    //Remove Media Item provides 4 ways to remove a media item
    public void RemoveMediaItem(MediaItem aMediaItem) {
        MediaItems.Remove(aMediaItem);
    }
    //1. RemoveMediaItem(MediaItem aMediaItem) - Remove a media item object
    public void RemoveMediaItem(params Object[] mediaItems){
        Console.WriteLine("Please Inser a Media Item or List Of Media Items");
    }

    // Search Books provides 4 ways to search for a book
    public List<Book> SearchBooksByTitle(string aTitle){
        return Books.FindAll(book => book.GetTitle.Contains(aTitle));
    }
    public List<Book> SearchBooksByYear(int aPublicationYear){
        return Books.FindAll(book => book.GetPublicationYear == aPublicationYear);
    }
    public List<Book> SearchBooksByISBN(string aISBN){
        return Books.FindAll(book => book.GetISBN.Contains(aISBN));
    }
    public List<Book> SearchBooksByAuthor(string aAuthor){
        return Books.FindAll(book => book.GetAuthor.Contains(aAuthor));
    }

    // Search Media Items provides 4 ways to search for a media item
    public List<MediaItem> SearchMediaItemsByTitle(string aTitle){
        return MediaItems.FindAll(mediaItem => mediaItem.GetTitle.Contains(aTitle));
    }
    public List<MediaItem> SearchMediaItemsByMediaType(string aMediaType){
        return MediaItems.FindAll(mediaItem => mediaItem.GetMediaType.Contains(aMediaType));
    }
    public List<MediaItem> SearchMediaItemsByDuration(int aDuration){
        int leftDuration = aDuration - 5;
        int rightDuration = aDuration + 5;
        return MediaItems.FindAll(mediaItem => leftDuration <= mediaItem.GetDuration && mediaItem.GetDuration <= rightDuration);
    }

}