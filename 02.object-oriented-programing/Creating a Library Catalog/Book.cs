

class Book {
    private string Title;
    private string Author;
    private string ISBN;
    private int PublicationYear;

    public Book(string aTitle, string aAuthor, string aISBN, int aPublicationYear) {
        Title = aTitle;
        Author = aAuthor;
        ISBN = aISBN;
        PublicationYear = aPublicationYear;
    }
    public override string ToString(){
        return $"{Title} by {Author} published in {PublicationYear} with ISBN {ISBN}";
    }
    public override bool Equals(object? obj){
        if (obj is Book book){
            return Title == book.Title && Author == book.Author && ISBN == book.ISBN && PublicationYear == book.PublicationYear;
        }
        return false;
    }

    public override int GetHashCode(){
        return ISBN.GetHashCode();
    }

    public string GetISBN => ISBN;
    public string GetTitle => Title;
    public string GetAuthor => Author;
    public int GetPublicationYear => PublicationYear;
}