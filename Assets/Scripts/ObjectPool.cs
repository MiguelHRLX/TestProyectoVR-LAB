using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject cellPrefab;
    public int poolSize = 20;
    public float fireRate = 1f;
    private List<GameObject> cellPool;
    private int currentCellIndex = 0;
    public GameObject cells;
    public float radio=2f;
    void Start()
    {
        cellPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject cell = Instantiate(cellPrefab);
            cell.SetActive(false);
            //cell.transform.parent = cells.transform;
            cellPool.Add(cell);
        }

        InvokeRepeating("disparaCell", fireRate, fireRate);
    }

    private void disparaCell()
    {
        GameObject cell = GetNextCellFromPool();

        if (cell != null)
        {
            cell.transform.position = randPositionArea();
            cell.SetActive(true);

        }
    }

    private GameObject GetNextCellFromPool()
    {
        int initialIndex = currentCellIndex;

        do
        {
            if (!cellPool[initialIndex].activeInHierarchy)
            {
                return cellPool[initialIndex];
            }
            initialIndex++;

        } while (initialIndex < poolSize);

        return null;
    }
    private Vector3 randPositionArea()
    {
        float ang = Random.Range(0f, 360f);
        return transform.position + (transform.up * Mathf.Sin(ang) + transform.forward * Mathf.Cos(ang)).normalized * radio;
    }

}
