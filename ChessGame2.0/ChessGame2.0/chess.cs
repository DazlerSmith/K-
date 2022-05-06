using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGame2._0
{
    
    class Square: ICloneable
    {
        Texture2D pixel;     //Width and Height are standardised to 50
        int width = 50;
        int height = 50;  
        public int row;       //Row and Column are written here for when board is made with 64 squares
        public int column;            
        int hoffset;         
        int voffset;
        Color Colour;
        Vector2 position;          
        public Piece OnSquare;
        public bool IsSelected;     

    public object Clone()
    {
        return this.MemberwiseClone();
    }


        public Square(int r, int c, Texture2D t, int vo, int ho, Color co)
        {
            row = r;
            column = c;
            pixel = t;
            hoffset = ho;
            voffset = vo;
            Colour = co;
            position.X = (c * width) + ho;
            position.Y = (r * height) + vo;
            OnSquare = null;
            IsSelected = false;
        }

        public void Draw(SpriteBatch sb)
        {
            if (IsSelected)
                sb.Draw(pixel, new Rectangle((int)position.X, (int)position.Y, width, height), Color.Green);    //This is the code that will turn the selected square green
            else
                sb.Draw(pixel, new Rectangle((int)position.X, (int)position.Y, width, height), Colour); //Returns the square to the original colour.
            if (OnSquare != null)    
            {
                OnSquare.Draw(sb); //When the selected piece is unselected, the piece will be drawn back to the square.
            }
        }


    }
    class Pawn:Piece
    {
        public Pawn(Texture2D t, int r, int c, int vo, int ho, bool w):base(t,r,c,vo,ho, w)
        {

        }

        public override bool CheckMove(int x, int y, Square[,] s)
        {
            if (!IsWhite) //Piece is black
            {
                if (s[x, y].OnSquare == null) //If selected square has not got a piece on it
                {
                    if (column == 1)
                    {
                        Console.WriteLine(" row " + row + " : " + " column " + column);     //The row and column are constants
                                                                                            //It is only x and y that change
                        if (column == y - 1 && row == x || column == y - 2 && row == x)
                            return true;
                        else
                           
                        return false;

                    }
                    else if (column == y && row == x)  //Same square problem fix
                    {
                        return false;
                    }
                    else
                    {
                        if (column == y - 1 && row == x) //Square to the left
                            return true;
                        else
                        return false; 
                    }
                }
                else
                {
                    if (s[x, y].OnSquare.IsWhite ) //if the black piece selects to take a white piece on the selected square
                    {
                        if (column == y - 1 && (row == x + 1 || row == x - 1))   //diagonal 1 square

                            return true;

                        else

                        
                        return false;
                    }
                    else
                    {
                  
                        return false;
                    }
                   
                }
            }
            else   //Now white
            {
                if (s[x, y].OnSquare == null) //If selected square has not got a piece on it
                {
                    if (column == 6)
                    {
                        Console.WriteLine(" row " + row + " : " + " column " + column);  //x is rows and y is column they are inverted
                                                                                        //column represents x axis
                        if (column == y + 1 && row == x || column == y + 2 && row == x)
                            return true;
                        else
                        {

                            return false;
                        }
                    }
                    else if (column == y && row == x)
                    {
                        return false;  // This is the same square fix
                    }
                    else
                    {
                        if (column == y + 1 && row == x)
                            return true;
                        else
                        return false;
                    }
                }
                else
                {
                    if (s[x, y].OnSquare.IsWhite == false)  //if selected square is black piece
                    {
                        if (column == y + 1 && (row == x + 1 || row == x - 1))

                            return true;

                        else

                        return false;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
            }
        }
    }

    class Bishop : Piece
    {
        public Bishop(Texture2D t, int r, int c, int vo, int ho, bool w) : base(t, r, c, vo, ho, w)
        {

        }

        public override bool CheckMove(int x, int y ,Square[,] s)
        {

            for (int i = 1; i < 7; i++)
            {

                if (((y == column + i) && (x == row + i)) || ((y == column - i) && (x == row + i)) || ((y == column - i) && (x == row - i)) || ((y == column + i) && (x == row - i)))
                {
                     if ((y == column + i) && (x == row + i)) //Bottom right
                     {
                        int CheckedSquares = i;   
                         for (int z = 1; z < CheckedSquares ; z++)         
                         {
                             if (s[x - z, y - z].OnSquare == null)
                             {
                                //If no pieces are in between check the next and so on.
                             }
                             else
                             {
                                 //Piece in between so false.
                                 return false;
                             }
                         }
                     }
                      else if ((y == column - i) && (x == row - i)) //Top Left
                     {
                         int CheckedSquares = i;
                         for (int z = 1; z < CheckedSquares; z++)
                         {
                             if (s[x + z, y + z].OnSquare == null)
                             {

                             }
                             else
                             {
                                 return false;
                             }
                         }
                     }
                     else if ((y == column - i) && (x == row + i)) //Top right
                     {
                         int CheckedSquares = i;
                         for (int z = 1; z < CheckedSquares; z++)
                         {
                             if (s[x - z, y + z].OnSquare == null)
                             {

                             }
                             else
                             {
                                 return false;
                             }
                        }
                     }
                     else if ((y == column + i) && (x == row - i)) //Bottom left
                     {
                         int CheckedSquares = i;
                         for (int z = 1; z < CheckedSquares; z++)
                         {
                             if (s[x + z, y - z].OnSquare == null)
                             {

                             }
                             else
                             {
                                 return false;
                             }
                        } 

                      }

                    if (s[x, y].OnSquare == null)  //No piece on selected square
                    {
                        return true;
                    }
                    else if (column == y && row == x) //Same Square Fix
                    {
                        return false;
                    }
                    else
                    {
                        if (!IsWhite) //User's Piece is black
                        {
                            if (s[x, y].OnSquare.IsWhite) //If targeted piece is white
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (IsWhite)
                        {
                            if (s[x, y].OnSquare.IsWhite == false)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    //Allows to loop

                }

            }


            return false;  

        }
    }

    class Rook : Piece
    {
        public Rook(Texture2D t, int r, int c, int vo, int ho, bool w) : base(t, r, c, vo, ho, w)
        {

        }

        public override bool CheckMove(int x, int y, Square[,] s)
        {

            if (x == row || y == column)
            {
                if (x == row) //If y-axis is same
                {
                    if (y > column)  //If selected square is to the right of the rook
                    {
                        int CheckedSquares = y - column; //Gets area between starting square and selected square 

                        for (int i = 1; i < CheckedSquares; i++)
                        {
                            if (s[x,y-i].OnSquare == null)
                            {

                            }
                            else
                            {

                                return false;
                            }
                        }
                       
                    }
                    else if (y < column)  //If selected square is to the left of the rook
                    {
                        int CheckedSquares = column - y; //To the left of the rook

                        for (int i = 1; i < CheckedSquares; i++)
                        {
                            if (s[x, y + i].OnSquare == null)
                            {
                           
                            }
                            else
                            {

                                return false;
                            }
                        }

                    }
                  
                }
                else if (y == column) //If x-axis is same
                {
                    if (x > row)  //If selected square below the rook
                    {
                        int CheckedSquares = x - row;

                        for (int i = 1; i < CheckedSquares; i++)
                        {
                            if (s[x - i, y].OnSquare == null)
                            {

                            }
                            else
                            {

                                return false;
                            }
                        }

                    }
                    else if (x < row)  //If selected square is above the rook
                    {
                        int CheckedSquares = row - x;

                        for (int i = 1; i < CheckedSquares; i++)
                        {
                            if (s[x + i, y].OnSquare == null)
                            {

                            }
                            else
                            {

                                return false;
                            }
                        }

                    }

                }
                if (s[x,y].OnSquare == null) //No piece on targeted square
                {
                    return true;
                }
                else if (column == y && row == x) //Same square fix
                {
                    return false;
                }
                else
                {
                    if (!IsWhite)  //User's piece is black
                    {
                        if (s[x, y].OnSquare.IsWhite)  //Targeted Piece is white
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (IsWhite)
                    {
                        if (s[x, y].OnSquare.IsWhite == false)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                         
            }
            
            return false;
        }
    }

    class Knight : Piece
    {
        public Knight(Texture2D t, int r, int c, int vo, int ho, bool w) : base(t, r, c, vo, ho, w)
        {
           
        }

        public override bool CheckMove(int x, int y, Square[,] s)
        {
            if (!IsWhite) //Piece is black
            {
                if (column == y && row == x) //Same Square Fix
                {
                    return false;
                }
                else if (s[x, y].OnSquare != null) //If piece on square is true
                {
                    if (s[x, y].OnSquare.IsWhite) //If piece on target square is white (attackable)
                    {
                        if ((column == y - 2 && (row == x - 1 || row == x + 1)) || (column == y + 2 && (row == x - 1 || row == x + 1)) || (row == x + 2 && (column == y - 1 || column == y + 1)) || (row == x - 2 && (column == y - 1 || column == y + 1)))
                        {
                            return true; //All L moves
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {                                  
                        return false;
                    }
                }
                else //No piece occupying the square
                {
                    if ((column == y - 2 && (row == x - 1 || row == x + 1)) || (column == y + 2 && (row == x - 1 || row == x + 1)) || (row == x + 2 && (column == y - 1 || column == y + 1)) || (row == x - 2 && (column == y - 1 || column == y + 1)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else //Piece is white
            {
                if (column == y && row == x)
                {
                    return false;
                }
                else if (s[x, y].OnSquare != null) //If piece on square is true
                {
                    if (s[x, y].OnSquare.IsWhite == false) //Target piece is black
                    {
                        if ((column == y - 2 && (row == x - 1 || row == x + 1)) || (column == y + 2 && (row == x - 1 || row == x + 1)) || (row == x + 2 && (column == y - 1 || column == y + 1)) || (row == x - 2 && (column == y - 1 || column == y + 1)))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if ((column == y - 2 && (row == x - 1 || row == x + 1)) || (column == y + 2 && (row == x - 1 || row == x + 1)) || (row == x + 2 && (column == y - 1 || column == y + 1)) || (row == x - 2 && (column == y - 1 || column == y + 1)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            
        }
    }

    class Queen : Piece
    {
        public Queen(Texture2D t, int r, int c, int vo, int ho, bool w) : base(t, r, c, vo, ho, w)
        {

        }

        public override bool CheckMove(int x, int y, Square[,] s)
        {
            for (int i = 1; i < 7; i++) //Bishop moves for queen
            {

                if (((y == column + i) && (x == row + i)) || ((y == column - i) && (x == row + i)) || ((y == column - i) && (x == row - i)) || ((y == column + i) && (x == row - i)))
                {
                    if ((y == column + i) && (x == row + i)) //Bottom right
                    {
                        int CheckedSquares = i;   
                        for (int z = 1; z < CheckedSquares; z++) //Loops the same amount of times as the squares in between
                        {
                            if (s[x - z, y - z].OnSquare == null)
                            {

                            }
                            else
                            {

                                return false;
                            }
                        }
                    }
                    else if ((y == column - i) && (x == row - i)) //Top Left
                    {
                        int CheckedSquares = i;
                        for (int z = 1; z < CheckedSquares; z++)
                        {
                            if (s[x + z, y + z].OnSquare == null)
                            {

                            }
                            else
                            {

                                return false;
                            }
                        }
                    }
                    else if ((y == column - i) && (x == row + i)) //Top right
                    {
                        int CheckedSquares = i;
                        for (int z = 1; z < CheckedSquares; z++)
                        {
                            if (s[x - z, y + z].OnSquare == null)
                            {

                            }
                            else
                            {

                                return false;
                            }
                        }
                    }
                    else if ((y == column + i) && (x == row - i)) //Bottom left
                    {
                        int CheckedSquares = i;
                        for (int z = 1; z < CheckedSquares; z++)
                        {
                            if (s[x + z, y - z].OnSquare == null)
                            {

                            }
                            else
                            {

                                return false;
                            }
                        }

                    }

                    if (s[x, y].OnSquare == null) 
                    {
                        return true;
                    }
                    else if (column == y && row == x) //Same Square Fix
                    {
                        return false;
                    }
                    else
                    {
                        if (!IsWhite) //User's piece is black
                        {
                            if (s[x, y].OnSquare.IsWhite) //Targeted Piece is white
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (IsWhite)
                        {
                            if (s[x, y].OnSquare.IsWhite == false)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    //Allows for looping

                }

            }

            if (x == row || y == column) //Rook moves for queen
            {
                if (x == row) //If y-axis is same
                {
                    if (y > column)  //If selected square is to the right of the rook
                    {
                        int CheckedSquares = y - column; //Get area between starting square and selected square 

                        for (int i = 1; i < CheckedSquares; i++)
                        {
                            if (s[x, y - i].OnSquare == null)
                            {

                            }
                            else
                            {

                                return false;
                            }
                        }

                    }
                    else if (y < column)  //If selected square is to the left of the rook
                    {
                        int CheckedSquares = column - y;

                        for (int i = 1; i < CheckedSquares; i++)
                        {
                            if (s[x, y + i].OnSquare == null)
                            {

                            }
                            else
                            {

                                return false;
                            }
                        }

                    }

                }
                else if (y == column) //If x-axis is same
                {
                    if (x > row)  //If selected square below the rook
                    {
                        int CheckedSquares = x - row;

                        for (int i = 1; i < CheckedSquares; i++)
                        {
                            if (s[x - i, y].OnSquare == null)
                            {

                            }
                            else
                            {

                                return false;
                            }
                        }

                    }
                    else if (x < row)  //If selected square is above the rook
                    {
                        int CheckedSquares = row - x;

                        for (int i = 1; i < CheckedSquares; i++)
                        {
                            if (s[x + i, y].OnSquare == null)
                            {

                            }
                            else
                            {

                                return false;
                            }
                        }

                    }

                }
                if (s[x, y].OnSquare == null) //No Piece on Targeted Square
                {
                    return true;
                }
                else
                {
                    if (!IsWhite) //Piece is black
                    {
                        if (s[x, y].OnSquare.IsWhite)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (IsWhite) //Piece is white
                    {
                        if (s[x, y].OnSquare.IsWhite == false)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
               
            }

            return false;


        }
    }

    class King : Piece
    {
        public King(Texture2D t, int r, int c, int vo, int ho, bool w) : base(t, r, c, vo, ho, w)
        {

        }

        public override bool CheckMove(int x, int y, Square[,] s)
        {
            if (!IsWhite) //Black
            {
                 if (column == y && row == x) //Same Square Fix
                {
                    return false;
                }
                else if (s[x,y].OnSquare != null) //Target square is occupied
                {
                    if (s[x, y].OnSquare.IsWhite)
                    {
                        if ((column == y - 1 && (row == x - 1 || row == x + 1 || row == x)) || (column == y + 1 && (row == x - 1 || row == x + 1 || row == x)) || (column == y && (row == x + 1 || row == x - 1)))
                        {
                            return true; //All square available 1 square adjacent/diagonal to the king
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if ((column == y - 1 && (row == x - 1 || row == x + 1 || row == x)) || (column == y + 1 && (row == x - 1 || row == x + 1 || row == x)) || (column == y && (row == x + 1 || row == x - 1)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else //White
            {
                 if (column == y && row == x) //Same Square Fix
                {
                    return false;  
                    
                }
                else if (s[x, y].OnSquare != null) //target square is occupied
                {
                    if (s[x, y].OnSquare.IsWhite == false)
                    {
                        if ((column == y - 1 && (row == x - 1 || row == x + 1 || row == x)) || (column == y + 1 && (row == x - 1 || row == x + 1 || row == x)) || (column == y && (row == x + 1 || row == x - 1)))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if ((column == y - 1 && (row == x - 1 || row == x + 1 || row == x)) || (column == y + 1 && (row == x - 1 || row == x + 1 || row == x)) || (column == y && (row == x + 1 || row == x - 1)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

    }

    abstract class Piece:ICloneable
    {
        public int row;
        public int column;
        public Texture2D PieceTexture;
        protected Vector2 Position;
        protected int width = 50;
        protected int height = 50;
        protected int hoffset;
        protected int voffset;
        protected Rectangle dest;
        public bool IsWhite;
        public bool IsSelected;

        public Piece(Texture2D t, int r, int c, int vo, int ho, bool w)
        {
            PieceTexture = t;
            row = r;
            column = c;
            hoffset = ho;
            voffset = vo;
            Position = new Vector2((c * width) + ho, (r * height) + vo); 
            IsSelected = false;     //If the piece has been selected
            IsWhite = w;              //Colour of pieces
            
            Console.WriteLine("Piece created " + r +" "+ c +" "+ dest);
        }

        public object Clone()
        {
            return this.MemberwiseClone(); // By cloning the objects it gets rid of the issue of moves being retained to the physical board during  the check and checkmate method checks.
        }

        public void updateposition(int r, int c) //Finds position of pieces after a move
        {
            row = r;
            column = c;
            Position = new Vector2((c * width) + hoffset, (r * height) + voffset);  
            Console.WriteLine(c + " " + r + " : " + Position);
        }
        public abstract bool CheckMove(int x, int y, Square[,] s); //Main method that checks the legality of every move

        public void Draw(SpriteBatch spriteBatch)
        {
          
            if (IsSelected)
            {
                MouseState m = Mouse.GetState();
                dest = new Rectangle((int)m.X-(width/2), (int)m.Y-(height/2), width, height); //Draws piece to the mouse constamtly updating its position and highlights the piece pink
                spriteBatch.Draw(PieceTexture, dest, Color.Magenta);
            }
            else
            {
                dest = new Rectangle((int)Position.X, (int)Position.Y, width, height);
                spriteBatch.Draw(PieceTexture, dest, Color.White);  //Highlighted Pieces will be returned to their original colour.
            }


        }

       
    }
}
