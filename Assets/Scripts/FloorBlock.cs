using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBlock : MonoBehaviour
{
    [SerializeField] private Bomb bombPrefab;
    [SerializeField] private Transform floorBlockTopPoint;

    private Bomb currentBomb = null;
    public bool Plant()
    {
        if (currentBomb != null)
        {
            Debug.Log("There is already a bomb on this block.");
            return false;
        }

        Debug.Log("Plant");
        currentBomb = Instantiate(bombPrefab, floorBlockTopPoint);
        currentBomb.transform.localPosition = Vector3.zero;
        return true;
    }
}
