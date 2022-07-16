using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeableSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    private void Start()
    {
        //ResizeByPixel( 256 );
    }

    public void ResizeByPixel(int pixels)
    {
        var _sprite = _renderer.sprite;
        if ( !_sprite )
        {
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
    /* not needed
    public void setColliderBox()
    {
        if ( gameObject.GetComponent<BoxCollider2D>() )
        {
            Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
            gameObject.GetComponent<BoxCollider2D>().size = S;
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2 ((S.x / 2), 0);
        }
    } */

    public void flipOnX ( bool doFlip )
    {
        _renderer.flipX = doFlip;
    }
}
