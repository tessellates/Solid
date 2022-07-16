using System;
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
        generateGrid();
        generateBounds();
        moveCamera();
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
        var allBounds = new List<ResizeableSprite>();
        float modify = 2f;
        float shift = (1f/modify - 1)/2;
        for (int y = 0; y < height*modify; y++)
        {
            float x_left = - 1 - shift;
            float x_right = width + shift;
            allBounds.Add( Instantiate(wall, new Vector3(x_right , shift + (float)y/modify), Quaternion.Euler(0,0,270)));
            allBounds.Add( Instantiate(wall, new Vector3(x_left , shift + (float)y/modify), Quaternion.Euler(0,0,90)));
            Debug.Log( y );

        }

        for (int x = 0; x < width*modify; x++)
        {
            float y_up = height + shift;
            float y_down = - 1 - shift;
            allBounds.Add(Instantiate(wall, new Vector3(shift + (float)x/modify , y_up), Quaternion.identity));
            allBounds.Add(Instantiate(wall, new Vector3(shift + (float)x/modify , y_down), Quaternion.Euler(0,0,180)));
        }

        allBounds.Add(Instantiate(corner, new Vector3(- 1 - shift , height + shift), Quaternion.identity));
        allBounds.Add(Instantiate(corner, new Vector3(width + shift , height + shift), Quaternion.Euler(0,0,270)));
        allBounds.Add(Instantiate(corner, new Vector3(width + shift , - 1 - shift), Quaternion.Euler(0,0,180)));
        allBounds.Add(Instantiate(corner, new Vector3(- 1 - shift , - 1 - shift), Quaternion.Euler(0,0,90)));

        {
            foreach ( var bounds in allBounds )
            {
                bounds.ResizeByPixel( (int)  Math.Ceiling(256/modify));
            }
        }

    }

    private void moveCamera()
    {
        transformed_width = (float)width/2;    
        transformed_height = (float)height/2;
        cam.transform.position = new Vector3( transformed_width - 0.5f, transformed_height - 0.5f, -10 );
    }
}
