using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landgenerator : MonoBehaviour
{
    public Tile defaultTile;

    public float wordSizeX = 10;
    public float wordSizeZ = 10;
    public float wordSizeY = 3;
    public Tile[,] tiles;
    private float tileSize;

    // Start is called before the first frame update
    void Start()
    {
        // create a new array of tiles
        tiles = new Tile[(int)wordSizeX, (int)wordSizeZ];

        // get the size of the tile
        tileSize = defaultTile.GetComponent<Renderer>().bounds.size.x;

        // generate the world
        GenerateWorld(wordSizeX, wordSizeZ, wordSizeY, tileSize);
    }

    // Update is called once per frame
    void Update()
    {
        // update the color of all tiles in the world based on their height
        UpdateTilesColor();
    }

    void SpawnTile(float x, float z, float y)
    {
        // create a new tile
        Tile newTile = Instantiate(defaultTile) as Tile;

        // set the position of the tile
        newTile.transform.position = new Vector3(x, y, z);

        // set the parent of the tile
        newTile.transform.parent = transform;
    }

    // generate the world with hexes
    void GenerateWorld(float xSize, float zSize, float ySize, float tileSize)
    {
        // get half the size of the tile
        float tileSizeHalf = tileSize / 2;

        // get the offset of the tile
        float tileOffset = 0.0f; //tileSize / 25;

        float xPosition = 0;
        float zPosition = 0;
        float yPosition = 0;

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

                }

                else if (z % 2 != 0)
                {
                    xPosition = (tileSize * x) + tileSizeHalf + (tileOffset * x);
                }

                zPosition = tileSize * z * 0.9f;

                // assing yPosition as random number betwen 1 and ySize
                yPosition = CalcNoise(xSize + 1, zSize + 1, x + 1, z + 1, 1.0f) * ySize;
                // Random.Range(0, ySize) * (tileSize * 0.1f);

                // print in console the x and z position
                Debug.Log(
                    "x position: " + xPosition +
                    " z position: " + zPosition +
                    " y position: " + yPosition
                    );

                // add a Tile to the array
                Tile newTile = Instantiate(defaultTile) as Tile;
                newTile.SetPosition(xPosition, zPosition, yPosition);
                tiles[x, z] = newTile;
            }
        }
    }

    float CalcNoise(float xOrg, float zOrg, float xPosition, float zPosition, float scale)
    {
        float xCoord = xOrg / xPosition * scale;
        float zCoord = zOrg / zPosition * scale;
        float sample = Mathf.PerlinNoise(xCoord, zCoord);

        return sample;
    }

    // update the color of all tiles in the world based on their height
    void UpdateTilesColor()
    {
        // loop through the x axis
        for (int z = 0; z < wordSizeZ; z++)
        {
            // loop through the z axis
            for (int x = 0; x < wordSizeX; x++)
            {
                // get the tile
                Tile tile = tiles[x, z];

                // get the height of the tile
                float height = tile.GetHeight();

                // get the color of the tile
                Color color = tile.GetColor();

                // set the color of the tile based on the height
                if (height < 2.0f)
                {
                    color = Color.blue;
                }
                else if (height < 5.0f)
                {
                    color = Color.green;
                }
                else if (height < 8.0f)
                {
                    color = Color.white;
                }
                else if (height < 9.0f)
                {
                    color = Color.cyan;
                }
                else
                {
                    color = Color.white;
                }

                // set the color of the tile
                tile.SetColor(color);
            }
        }
    }
}
