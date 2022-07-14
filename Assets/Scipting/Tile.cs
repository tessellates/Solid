using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offColor;
    [SerializeField] private SpriteRenderer _renderer;

    public void size()
    {
        Debug.Log( _renderer.sprite.rect );
    }

    public void Init( bool offset )
    {
        _renderer.color = offset ? offColor : baseColor;
    } 
}
