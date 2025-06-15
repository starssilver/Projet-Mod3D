using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ProceduralTerrain : MonoBehaviour
{
    private const int width = 50;
    private const int height = 50;
    public float scale = 0.1f;
    public float amplitude = 5f;

    private Vector3[] vertices;
    private int[] triangles;
    private Mesh mesh;
    private MeshCollider meshCollider;

    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        meshCollider = GetComponent<MeshCollider>();

        CreateTerrain();
    }

    private void CreateTerrain()
    {
        vertices = new Vector3[(width + 1) * (height + 1)];
        for (int z = 0, i = 0; z <= height; z++)
        {
            for (int x = 0; x <= width; x++, i++)
            {
                float y = Mathf.PerlinNoise(x * scale, z * scale) * amplitude;
                vertices[i] = new Vector3(x, y, z);
            }
        }

        triangles = new int[width * height * 6];
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                int i = vert;

                triangles[tris + 0] = i;
                triangles[tris + 1] = i + width + 1;
                triangles[tris + 2] = i + width + 2;

                triangles[tris + 3] = i;
                triangles[tris + 4] = i + width + 2;
                triangles[tris + 5] = i + 1;

                vert++;
                tris += 6;
            }
            vert++;
        }

        mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }

}
