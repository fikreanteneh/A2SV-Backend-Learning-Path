

class MediaItem {
    public string Title;
    public string MediaType;
    public int Duration;

    public MediaItem(string aTitle, string aMediaType, int aDuration) {
        Title = aTitle;
        MediaType = aMediaType;
        Duration = aDuration;
    }

    public override string ToString(){
        return $"{Title} is a {MediaType} with a duration of {Duration} minutes";
    }

    public override bool Equals(object? obj) {
        if (obj is MediaItem mediaItem){
            return Title == mediaItem.Title && MediaType == mediaItem.MediaType && Duration == mediaItem.Duration;
        }
        return false;
    }
    public override int GetHashCode(){
        return Title.GetHashCode();
    }
}