using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octagono : MonoBehaviour
{
    public float size = 1f; // Tamaño del octágono

    void Start()
    {
        CreateOctagon();
    }

    void CreateOctagon()
    {
        float halfSize = size / 2f;

        // Crear los ocho rectángulos del octágono
        for (int i = 0; i < 8; i++)
        {
            float angle = i * 45f; // Ángulo de cada rectángulo en grados
            Quaternion rotation = Quaternion.Euler(0f, angle, 0f); // Rotación del rectángulo en el eje Y

            GameObject rectangle = new GameObject("Rectangle " + i); // Crear un nuevo objeto para cada rectángulo
            rectangle.transform.SetParent(transform); // Establecer el octágono como padre del rectángulo
            rectangle.transform.localPosition = Vector3.zero; // Establecer la posición local del rectángulo en el centro del octágono
            rectangle.transform.localRotation = rotation; // Establecer la rotación local del rectángulo
            rectangle.transform.localScale = new Vector3(halfSize, halfSize, 0.1f); // Establecer la escala local del rectángulo

            MeshFilter meshFilter = rectangle.AddComponent<MeshFilter>(); // Añadir un componente MeshFilter al rectángulo
            MeshRenderer meshRenderer = rectangle.AddComponent<MeshRenderer>(); // Añadir un componente MeshRenderer al rectángulo

            // Crear y asignar una malla al rectángulo
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
            meshFilter.mesh = mesh; // Asignar la malla creada al MeshFilter del rectángulo
        }
    

    // Crear un Prefab del octágono
    // string prefabPath = "Assets/Prefabs/Octagon3D.prefab";
    //  UnityEditor.PrefabUtility.SaveAsPrefabAsset(octagon, prefabPath);
    // Debug.Log("Prefab del octágono creado en: " + prefabPath);
}
}
