using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    private float transformed_width, transformed_height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;
    [SerializeField] private ResizeableSprite wall;
    [SerializeField] private ResizeableSprite corner;
    [SerializeField] private ResizeableSprite player;

    private void Start()
    {
        transformed_width = (float)width/2;    
        transformed_height = (float)height/2;
        generateGrid();
        generateBounds();
        moveCamera();
        var spawnedTile = Instantiate(tilePrefab, new Vector3(-2 , -2), Quaternion.identity);

    }


    private void generateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x , y), Quaternion.identity);
                spawnedTile.name = $"Tile ({x}, {y})";
                bool isOff = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init( isOff );
            }
        }
    }

    private void generateBounds()
    {
        float modify = 1.5f;
        for (int y = 0; y < height*modify; y++)
        {
            float x_left = - 1 - (1/modify - 1);
            float x_right = width + (1/modify - 1);
            var rightWall = Instantiate(wall, new Vector3(x_right , (float)y/modify), Quaternion.Euler(0,0,270));
            var leftWall = Instantiate(wall, new Vector3(x_left , (float)y/modify), Quaternion.Euler(0,0,90));
        }

        for (int x = 0; x < height*modify; x++)
        {
            float y_up = height + (1/modify -1);
            float y_down = - 1 - (1/modify -1);
            var rightWall = Instantiate(wall, new Vector3((float)x/modify , y_up), Quaternion.identity);
            var leftWall = Instantiate(wall, new Vector3((float)x/modify , y_down), Quaternion.Euler(0,0,180));
        }

        Instantiate(corner, new Vector3(- 1 - (1/modify -1) , height + (1/modify -1)), Quaternion.identity);
        Instantiate(corner, new Vector3(width + (1/modify -1) , height + (1/modify -1)), Quaternion.Euler(0,0,270));
        Instantiate(corner, new Vector3(width + (1/modify -1) , - 1 - (1/modify -1)), Quaternion.Euler(0,0,180));
        Instantiate(corner, new Vector3(- 1 - (1/modify -1) , - 1 - (1/modify -1)), Quaternion.Euler(0,0,90));

    }

    private void moveCamera()
    {
        cam.transform.position = new Vector3( transformed_width - 0.5f, transformed_height - 0.5f, -10 );
    }
}
