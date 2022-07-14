using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeableSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    private void Start()
    {
        ResizeByPixel( 170 );
    }

    public void ResizeByPixel(int pixels)
    {
        var _sprite = _renderer.sprite;
        if ( !_sprite )
        {
            Debug.Log( "triggered" );
            _sprite = GetComponent<Sprite>();
        }
        Debug.Log( _sprite.rect );
        var originalSpriteSize = _sprite.rect;
        var scaleFactorWidth = pixels / originalSpriteSize.width;
        var scaleFactorHeight = pixels / originalSpriteSize.height;
        Debug.Log( scaleFactorHeight );
        Debug.Log( scaleFactorWidth );
        gameObject.transform.localScale = new Vector3(scaleFactorWidth * gameObject.transform.localScale.x, scaleFactorHeight * gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
}
