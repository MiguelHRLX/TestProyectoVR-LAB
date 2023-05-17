using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polling : MonoBehaviour
{
    public Cell cellPrefab;
    public int poolSize = 20;
    public float fireRate = 1f;
    private List<Cell> cellPool = new List<Cell>();
    private Cell currentCell;
    private int currentCellIndex = 0;
    public float radio = 2f;
    private float timmer;
    
    void Start()
    {

        for (int i = 0; i < poolSize; i++)
        {
            Cell cell = Instantiate(cellPrefab, transform.position, Quaternion.identity);
            cell.gameObject.SetActive(false);
            cell.transform.right = transform.right;
            cellPool.Add(cell);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timmer += Time.deltaTime;
        if (timmer >= fireRate) {
            SpawnCell();
            timmer = 0;
            //currentCell.GetComponent<Cell>().SetVelocity(transform.right, gameObject);
        } 

    }
    public void SpawnCell(){

        //for (int i=0;i<cellPool.Count;i++)
        //{
        //    if (cellPool[i].activeSelf == false)
        //    {
        //        cellPool[i].transform.position = randPositionArea();
        //        cellPool[i].SetActive(true);
        //        return;
        //    }
        //    else if(cellPool[cellPool.Count-1].activeSelf == true)
        //    {
        //        GameObject newCell = Instantiate(cellPrefab,transform.position,Quaternion.identity);
        //        cellPool.Add(newCell);
        //        newCell.transform.right = transform.right;
        //        newCell.SetActive(true);
        //        return;
        //    }
        //}
        currentCellIndex = 0;
        while (currentCellIndex < cellPool.Count)
        {
            if (cellPool[currentCellIndex].gameObject.activeSelf == false)
            {
                currentCell = cellPool[currentCellIndex];
                if (currentCell.GetComponent<Cell>()) currentCell.GetComponent<Cell>().SetVelocity(transform.right, gameObject);
                currentCell.gameObject.transform.position = randPositionArea();
                currentCell.gameObject.SetActive(true);
                return;
            }
            else
            {
                currentCellIndex += 1;
            }
                
        }
        
        if (currentCellIndex==cellPool.Count)
        {
            currentCell = Instantiate(cellPrefab, transform.position, Quaternion.identity);
            cellPool.Add(currentCell);
            //newCell.GetComponent<Cell>().SetVelocity(transform.right, gameObject);
            if (currentCell.GetComponent<Cell>()) currentCell.GetComponent<Cell>().SetVelocity(transform.right,gameObject);
            currentCell.gameObject.SetActive(true);
            return;
        }
    }

    private Vector3 randPositionArea()
    {
        float ang = Random.Range(0f, 360f);
        return transform.position + (transform.up * Mathf.Sin(ang) + transform.forward * Mathf.Cos(ang)).normalized * radio;
    }
}
