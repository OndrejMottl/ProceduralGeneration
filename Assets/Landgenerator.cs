using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landgenerator : MonoBehaviour
{
    public Tile defaultTile;

    public float wordSizeX = 10;
    public float wordSizeZ = 10;
    public float wordSizeY = 10;

    private float tileSize;

    // Start is called before the first frame update
    void Start()
    {
        // get the size of the tile
        tileSize = defaultTile.GetComponent<Renderer>().bounds.size.x;

        // generate the world
        GenerateWorld(wordSizeX, wordSizeZ, tileSize);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnTile(float x, float z)
    {
        // create a new tile
        Tile newTile = Instantiate(defaultTile) as Tile;

        // set the position of the tile
        newTile.transform.position = new Vector3(x, 0, z);

        // set the parent of the tile
        newTile.transform.parent = transform;
    }

    // generate the world with hexes
    void GenerateWorld(float xSize, float zSize, float tileSize)
    {
        // get half the size of the tile
        float tileSizeHalf = tileSize / 2;

        // get the offset of the tile
        float tileOffset = tileSize / 10;

        float xPosition = 0;
        float zPosition = 0;

        // print in console the size of the tile, halfise and tile offset   
        Debug.Log("tileSize: " + tileSize + " tileSizeHalf: " + tileSizeHalf + " tileOffset: " + tileOffset);

        // loop through the x axis
        for (int z = 0; z < zSize; z++)
        {
            // loop through the z axis
            for (int x = 0; x < xSize; x++)
            {
                // print in console the x and z position
                Debug.Log("x: " + x + " z: " + z);

                // if the z is even
                if (z % 2 == 0)
                {
                    xPosition = (tileSize * x) + (tileOffset * x);
                    zPosition = (tileSize * z);
                }

                else if (z % 2 != 0)
                {
                    xPosition = (tileSize * x) - tileSizeHalf + (tileOffset * x);
                    zPosition = (tileSize * z);
                }

                // print in console the x and z position
                Debug.Log("x position: " + xPosition + " z position: " + zPosition);

                // spawn a tile at the position
                SpawnTile(xPosition, zPosition);
            }
        }
    }

}
