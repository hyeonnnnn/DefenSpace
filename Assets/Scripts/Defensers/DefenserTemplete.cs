using UnityEngine;

[CreateAssetMenu]
public class DefenserTemplete : ScriptableObject
{
    public GameObject defenserPrefab;
    public Weapon[] weapon;

    [System.Serializable]
    public struct Weapon
    {
        public Sprite sprite;
        public float damage;
        public float rate;
        public float range;
        public int cost;
    }
}
