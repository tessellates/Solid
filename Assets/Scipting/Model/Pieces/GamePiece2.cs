using System.Collections;
using System.Collections.Generic;


public class GamePiece {
    //Properties
    private PieceType pieceType;
    private Coordinate position;
    private int serial;
    private bool isMoveable;

    //Constructor
    public GamePiece(int serial, PieceType pieceTypen bool isMoveable) {
        this.serial = serial;
        this.position = null;
        this.boardPieceType = boardPieceType;
    }
    virtual isMoveable = 0;

    public bool isMoveable()
    {
        return isMoveable;
    }

    GamePieceFactory(
        createPiece( PieceType::Ball )
    )
    Class Ball : public GamePiece
    isMoveable()
    {
        return true;
    } 
    //Getters and Setters properties.
    public Colour getPieceColour() {
        return pieceColour;
    }

    public void setPieceColour(Colour pieceColour) {
        this.pieceColour = pieceColour;
    }

    public BoardPieceTypeEnum getBoardPieceType() {
        return boardPieceType;
    }

    public void setBoardPieceType(BoardPieceTypeEnum boardPieceType) {
        this.boardPieceType = boardPieceType;
    }

    public int getSerial() {
        return serial;
    }

    public void setSerial(int serial) {
        this.serial = serial;
    }

    public Coordinate getPosition() {
        return position;
    }

    public void setPosition(Coordinate position) {
        this.position = position;
    }

    public String getId() {

        return "" + pieceColour.getColour() + boardPieceType.getBoardPieceType() + (boardPieceType != BoardPieceTypeEnum.QUEEN ? serial : "");
    }

    /**
     * Indien het stuk niet geplaatst is volgt elk type dezelfde regels.
     * @param boardState
     * @param emptyTiles
     * @return
     */
    public HashSet<Coordinate> askAllowedMovesUnplaced(HashMap<Coordinate, BoardPiece> boardState, Set<Coordinate> emptyTiles) {
        HashSet<Coordinate> allAllowedMoves = new HashSet<>();
        for (Coordinate possibleMove : emptyTiles) {
            boolean add = true;
            for (Coordinate control : possibleMove.requestNeighbours()) {
                if (boardState.keySet().contains(control)) {
                    if (boardState.get(control).getPieceColour() != this.getPieceColour()) {
                        add = false;
                    }

                }
            }
            if (add) {
                allAllowedMoves.add(possibleMove);
            }
        }
        return allAllowedMoves;
    }

    /**
     * Methode voor elke boardpiece type, naar gelang het type geven ze andere moves terug.
     * @param boardState
     * @return
     */
    public abstract HashSet<Coordinate> askAllowedMoves(HashMap<Coordinate, BoardPiece> boardState);

    @Override
    public String toString() {
        return position + " " + getId();
    }


    protected boolean checkIfAllowed(Coordinate left, Coordinate right, HashMap<Coordinate, BoardPiece> boardState) {

        return (boardState.get(left) != null || boardState.get(right) != null) && !(boardState.get(left) != null && boardState.get(right) != null);
    }

    public boolean isPlaced() {
        return getPosition() != null;
    }


}
