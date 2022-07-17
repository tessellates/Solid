using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceType
{
    Dirt,
    Ball,
    Gem,
    Player,
    Bomb,
    HardWall,
    WeakWall,
    Empty

}

public enum DamageType
{
    None        = 0b_0000_0000,  // 0
    Explosion   = 0b_0000_0001,  // 1
    Ball        = 0b_0000_0010,  // 2
    Gem         = 0b_0000_0100,  // 4
    Laser       = 0b_0000_1000,  // 8
    Bomb        = 0b_0001_0000,  // 16
    HardLanding = 0b_0010_0000,  // 32
    Object      = Ball | Gem | Bomb
}

public class GamePiece {
    //Properties
    private Coordinate position;
    private PieceType type;
    private bool m_isMoveable;
    private DamageType vulnerability;
    private bool m_isHard;

    //Constructor
    private GamePiece( PieceType pieceType ) {
        this.type = pieceType;
        this.m_isMoveable = false;
        this.vulnerability = DamageType.None;
        this.m_isHard = true;
    }

    public static GamePiece createPiece( PieceType pieceType )
    {
        GamePiece piece = new GamePiece( pieceType );
        switch (pieceType) 
        {
            case PieceType.Dirt:
                piece.addVulnerability( DamageType.Explosion );
                piece.m_isHard = false;
                break;
            case PieceType.Ball:
                piece.addVulnerability( DamageType.Explosion );
                break;                
            case PieceType.Gem:
                piece.addVulnerability( DamageType.Ball | DamageType.Bomb | DamageType.Explosion | DamageType.Laser );
                break;
            case PieceType.Player:
                piece.addVulnerability( DamageType.Object | DamageType.Explosion | DamageType.Laser );
                break;
            case PieceType.Bomb:
                piece.addVulnerability( DamageType.Object | DamageType.Explosion | DamageType.Laser | DamageType.HardLanding );
                break;
            case PieceType.WeakWall:
                piece.addVulnerability( DamageType.Explosion );
                break;
            default:
                break;
        }
        return piece;
    }

    static GamePiece createPiece( PieceType pieceType, Coordinate coordinate )
    {
        GamePiece piece = createPiece( pieceType );
        piece.setPosition( coordinate );
        return piece;
    }

    public void addVulnerability( DamageType damageType )
    {
        this.vulnerability = this.vulnerability | damageType;
    }

    public void setVulnerability( DamageType damageType )
    {
        this.vulnerability = damageType;
    }

    public bool isMoveable()
    {
        return m_isMoveable;
    }

    public bool isDestroyableBy( DamageType damageType )
    {
        return DamageType.None != (vulnerability & damageType);
    }

    public PieceType getPieceType() {
        return this.type;
    }

    public Coordinate getPosition() {
        return position;
    }

    public void setPosition(Coordinate position) {
        this.position = position;
    }

    public DamageType damageType()
    {
        return PieceTypeToDamageType( this.getPieceType() );
    }

    public bool isHard()
    {
        return m_isHard;
    }

    static DamageType PieceTypeToDamageType(PieceType pieceType)            
    {
        switch (pieceType) 
        {
            case PieceType.Ball:
                return DamageType.Ball;
            case PieceType.Gem:
                return DamageType.Gem;
            case PieceType.Bomb:
                return DamageType.Bomb;
            default:
                return DamageType.None;
        }
    }
}
