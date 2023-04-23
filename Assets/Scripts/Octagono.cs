using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octagono : MonoBehaviour
{
    public float size = 1f; // Tama�o del oct�gono

    void Start()
    {
        CreateOctagon();
    }

    void CreateOctagon()
    {
        float halfSize = size / 2f;

        // Crear los ocho rect�ngulos del oct�gono
        for (int i = 0; i < 8; i++)
        {
            float angle = i * 45f; // �ngulo de cada rect�ngulo en grados
            Quaternion rotation = Quaternion.Euler(0f, angle, 0f); // Rotaci�n del rect�ngulo en el eje Y

            GameObject rectangle = new GameObject("Rectangle " + i); // Crear un nuevo objeto para cada rect�ngulo
            rectangle.transform.SetParent(transform); // Establecer el oct�gono como padre del rect�ngulo
            rectangle.transform.localPosition = Vector3.zero; // Establecer la posici�n local del rect�ngulo en el centro del oct�gono
            rectangle.transform.localRotation = rotation; // Establecer la rotaci�n local del rect�ngulo
            rectangle.transform.localScale = new Vector3(halfSize, halfSize, 0.1f); // Establecer la escala local del rect�ngulo

            MeshFilter meshFilter = rectangle.AddComponent<MeshFilter>(); // A�adir un componente MeshFilter al rect�ngulo
            MeshRenderer meshRenderer = rectangle.AddComponent<MeshRenderer>(); // A�adir un componente MeshRenderer al rect�ngulo

            // Crear y asignar una malla al rect�ngulo
            Mesh mesh = new Mesh();
            mesh.vertices = new Vector3[]
            {
                new Vector3(-0.5f, 0f, -0.5f),
                new Vector3(0.5f, 0f, -0.5f),
                new Vector3(0.5f, 0f, 0.5f),
                new Vector3(-0.5f, 0f, 0.5f)
            };
            mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
            mesh.normals = new Vector3[]
            {
                Vector3.up,
                Vector3.up,
                Vector3.up,
                Vector3.up
            };
            meshFilter.mesh = mesh; // Asignar la malla creada al MeshFilter del rect�ngulo
        }
    

    // Crear un Prefab del oct�gono
    // string prefabPath = "Assets/Prefabs/Octagon3D.prefab";
    //  UnityEditor.PrefabUtility.SaveAsPrefabAsset(octagon, prefabPath);
    // Debug.Log("Prefab del oct�gono creado en: " + prefabPath);
}
}
