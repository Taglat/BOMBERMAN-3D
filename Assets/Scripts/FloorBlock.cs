using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBlock : MonoBehaviour
{
    [SerializeField] private Bomb bombPrefab;
    [SerializeField] private Transform floorBlockTopPoint;
    
    public void Plant() {
        Debug.Log("Plant");
        Bomb bomb = Instantiate(bombPrefab, floorBlockTopPoint);
        bomb.transform.localPosition = Vector3.zero;
    }
}
