using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool IsPlaceDefenser { set; get; }

    private void Awake()
    {
        IsPlaceDefenser = false;
    }
}
