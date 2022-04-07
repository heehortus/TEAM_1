using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlaceManager : MonoBehaviour
{
    private List<GameObject> listPlace = new List<GameObject>();

    [SerializeField] private GameObject placePrefab;
    [SerializeField] private GameObject MyPlace;
    [SerializeField] private GameObject EnemyPlace;

    private const float HorizontalInterval = 1;
    private const float VerticalInterval = 1;

	public int RowMax = 3;
    public int ColumnMax = 2;

    public void Init()
    {
        setPlaceObject(MyPlace);
        setPlaceObject(EnemyPlace);
    }

    public void OnUpdate()
    {
        
    }

    public void display(bool chk) {
        foreach(var item in listPlace) {
            if(item.GetComponent<PlaceObject>().isPlayerPlace) {
                item.GetComponent<SpriteRenderer>().enabled = chk;
            }
        }
    }

    private void setPlaceObject(GameObject place){
        var pos = place.transform.position;
        var width = placePrefab.GetComponent<BoxCollider2D>().size.x;
        var height = placePrefab.GetComponent<BoxCollider2D>().size.y;
        pos = new Vector3(pos.x-(width*(ColumnMax-1) + HorizontalInterval*(ColumnMax-1))/2,pos.y+(height*(RowMax-1) + VerticalInterval*(RowMax-1))/2,0);
        var _pos = pos;
        bool placeenemy;
        if(place == MyPlace){
            placeenemy = true;
        }
        else { 
            placeenemy = false;
        }

        for(int i = 0;i<RowMax;i++) {
            for(int j = 0;j<ColumnMax;j++) {
                var _place = Instantiate(placePrefab);
                var script = _place.GetComponent<PlaceObject>();
                script.x = i;
                script.y = j;
                script.isPlayerPlace = placeenemy;
                listPlace.Add(_place);
                _place.transform.position = new Vector3(_pos.x,_pos.y,0);
                _pos = new Vector3(_pos.x + HorizontalInterval + width, _pos.y);
                _place.transform.SetParent(place.transform);
            }
            _pos = new Vector3(pos.x,_pos.y - VerticalInterval - height);
        }
    }

    public GameObject getPlaceObject(bool _isPlayerPlace,int x,int y) {
        foreach(var item in listPlace) {
            var script = item.GetComponent<PlaceObject>();
            if((script.x == x)&&(script.y == y)&&(script.isPlayerPlace == _isPlayerPlace)) {
                return item;
            }
        }
        return null;
    }
    
    public List<GameObject> getEmptyPlaceObject(bool _isPlayerPlace)
    {
        var list = new List<GameObject>();
        foreach(var item in listPlace) {
            if(item.GetComponent<PlaceObject>().isEmpty && item.GetComponent<PlaceObject>().isPlayerPlace == _isPlayerPlace)
                list.Add(item);
        }
        return list;
    }

}
