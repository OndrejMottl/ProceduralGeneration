using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tile : MonoBehaviour
{
    public float xPosition;
    public float zPosition;
    public float yPosition;

    public void SetPosition(float xPosition, float zPosition, float yPosition)
    {
        this.xPosition = xPosition;
        this.zPosition = zPosition;
        this.yPosition = yPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        // set the position of the tile
        transform.position = new Vector3(xPosition, yPosition, zPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}