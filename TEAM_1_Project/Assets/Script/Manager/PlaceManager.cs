using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlaceManager : MonoBehaviour
{
    [SerializeField] public List<List<GameObject>> listMyPlace = new List<List<GameObject>>(), listEnemyPlace = new List<List<GameObject>>();

    [SerializeField] private GameObject placePrefab;
    [SerializeField] private GameObject MyPlace;
    [SerializeField] private GameObject EnemyPlace;

    private const float HorizontalInterval = 2;
    private const float VerticalInterval = 2;

	public int RowMax = 3;
    public int ColumnMax = 2;


    private void Start()
    {
        setPlaceObject(MyPlace);
        setPlaceObject(EnemyPlace);
    }

    private void setPlaceObject(GameObject place){
        var pos = place.transform.position;
        var width = placePrefab.GetComponent<BoxCollider2D>().size.x;
        var height = placePrefab.GetComponent<BoxCollider2D>().size.y;
        pos = new Vector3(pos.x-(width*(ColumnMax-1) + HorizontalInterval*(ColumnMax-1))/2,pos.y+(height*(RowMax-1) + VerticalInterval*(RowMax-1))/2,0);
        var _pos = pos;
        List<List<GameObject>> lists;
        bool placeenemy;
        if(place == MyPlace){
            lists = listMyPlace;
            placeenemy = true;
        }
        else { 
            lists = listEnemyPlace;
            placeenemy = false;
        }

        for(int i = 0;i<RowMax;i++) {
            lists.Add(new List<GameObject>());
            for(int j = 0;j<ColumnMax;j++) {
                var _place = Instantiate(placePrefab);
                var script = _place.GetComponent<PlaceObject>();
                script.x = i;
                script.y = j;
                script.isPlayerPlace = placeenemy;
                lists[i].Add(_place);
                _place.transform.position = new Vector3(_pos.x,_pos.y,0);
                _pos = new Vector3(_pos.x + HorizontalInterval + width, _pos.y);
                _place.transform.SetParent(place.transform);
            }
            _pos = new Vector3(pos.x,_pos.y - VerticalInterval - height);
        }
    }

}
