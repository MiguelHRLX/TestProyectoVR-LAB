using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenaAuto : MonoBehaviour
{

    public float dimX = 1f;
    public float dimY = 1f;
    public float dimZ = 1f;
    public float radio = 3f;
    public int walls = 4;
    GameObject cubeBase;
    public List<GameObject> Cubes = new List<GameObject>();
    private Vector3 dim = Vector3.one;
    // Start is called before the first frame update
    void Start()
    {
        cubeBase = GameObject.CreatePrimitive(type: PrimitiveType.Cube);
        CreateVena();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateVena()
    {
        Vector3 originalVector = gameObject.transform.up;
        float diferenceAngle = 360 / walls;
        float acumuleAngle = 0;
        for (int i = 0;i<walls; i++)
        {
            Quaternion rotate = Quaternion.Euler(acumuleAngle, 0, 0);
            Vector3 FinalPos = gameObject.transform.position + (rotate * originalVector).normalized * radio;
            GameObject cubeWall = Instantiate(cubeBase, FinalPos, Quaternion.identity);
            cubeWall.transform.up = (rotate * originalVector).normalized;
            Cubes.Add(cubeWall);
            acumuleAngle += diferenceAngle;
        }
    }
    void Redimension()
    {
        foreach (GameObject cube in Cubes)
        {

        }
    }
}
