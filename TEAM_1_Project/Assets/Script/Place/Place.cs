using System.Globalization;
public class Place
{
    public Place(int i,int j,bool isplayerplace) {
        x = i;
        y = j;
        isPlayerPlace = isplayerplace;
    }

    public Place(Place _place) {
        x = _place.x;
        y = _place.y;
        isEmpty = _place.isEmpty;
        isPlayerPlace = _place.isPlayerPlace;
    }

	public static bool operator == (Place a,Place b) {
        if(a.x == b.x && a.y == b.y) return true;
        return false;
    }
	public static bool operator != (Place a,Place b) {
        if(a.x != b.x && a.y != b.y) return true;
        return false;

    }
    public int x = 0;
    public int y = 0;
    public bool isEmpty = true;
	public bool isPlayerPlace = true;
    
}