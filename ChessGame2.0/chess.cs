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
    class Square
    {
        Texture2D pixel;
        int width = 50;
        int height = 50;
        public int row;
        public int column;
        int hoffset;
        int voffset;
        Color Colour;
        Vector2 position;
        public Piece OnSquare;
        public bool IsSelected;


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
            //sb.Draw(pixel, new Rectangle((int)position.X, (int)position.Y, width, height), Colour);
            if (IsSelected)
                sb.Draw(pixel, new Rectangle((int)position.X, (int)position.Y, width, height), Color.Green);
            else
                sb.Draw(pixel, new Rectangle((int)position.X, (int)position.Y, width, height), Colour);
            if (OnSquare != null)
            {
                OnSquare.Draw(sb);
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
                        Console.WriteLine(" x " + x + " : " + " y " + y);                   //It is only x and y that change
                        if (column == y - 1 && row == x || column == y - 2 && row == x)
                            return true;
                        else
                            Console.WriteLine(" Stupid Reason 1");
                        return false;

                    }
                    else if (column == y && row == x)
                    {
                        return false;
                    }
                    else
                    {
                        if (column == y - 1 && row == x)
                            return true;
                        else
                            Console.WriteLine(" Stupid Reason 2");
                        return false; 
                    }
                }
                else
                {
                    if (s[x, y].OnSquare.IsWhite )
                    {
                        if (column == y - 1 && (row == x + 1 || row == x - 1))

                            return true;

                        else

                            Console.WriteLine(" Stupid Reason 3");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine(" Stupid Reason 4");
                        return false;
                    }
                   
                }
            }
            else
            {
                if (s[x, y].OnSquare == null) //If selected square has not got a piece on it
                {
                    if (column == 6)
                    {
                        Console.WriteLine(" row " + row + " : " + " column " + column);  //x is rows and y is column they are inverted
                        Console.WriteLine(" x " + x + " : " + " y " + y);                //column represents x though
                        if (column == y + 1 && row == x || column == y + 2 && row == x)
                            return true;
                        else
                        {
                            Console.WriteLine(" Stupid Reason 5");

                            return false;
                        }
                    }
                    else if (column == y && row == x)
                    {
                        return false;
                    }
                    else
                    {
                        if (column == y + 1 && row == x)
                            return true;
                        else
                            Console.WriteLine(" Stupid Reason 6");
                        return false;
                    }
                }
                else
                {
                    if (s[x, y].OnSquare.IsWhite == false)
                    {
                        if (column == y + 1 && (row == x + 1 || row == x - 1))

                            return true;

                        else

                            Console.WriteLine(" Stupid Reason 7");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine(" Stupid Reason 8");
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
                        int CheckedSquares = i;   //Does reach but doesn't do for loop  
                         for (int z = 1; z < CheckedSquares ; z++)         
                         {
                             if (s[x - z, y - z].OnSquare == null)
                             {
                                 Console.WriteLine(" x " + (x - z) + " : " + " y " + (y - z));
                                 Console.WriteLine("clear");       //Checks if squares between are clear
                             }
                             else
                             {
                                 Console.WriteLine(" x " + (x - z) + " : " + " y " + (y - z));
                                 Console.WriteLine("full");
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
                                 Console.WriteLine(" x " + (x + z) + " : " + " y " + (y + z));
                                 Console.WriteLine("clear");       //Checks if squares between are clear
                                 Console.WriteLine("Bishop Reason 3");
                             }
                             else
                             {
                                 Console.WriteLine(" x " + (x + z) + " : " + " y " + (y + z));
                                 Console.WriteLine("full");
                                 Console.WriteLine("Bishop Reason 4");
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
                                 Console.WriteLine(" x " + (x - z) + " : " + " y " + (y + z));
                                 Console.WriteLine("clear");       //Checks if squares between are clear
                                 Console.WriteLine("Bishop Reason 5");
                             }
                             else
                             {
                                 Console.WriteLine(" x " + (x - z) + " : " + " y " + (y + z));
                                 Console.WriteLine("full");
                                 Console.WriteLine("Bishop Reason 6");
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
                                 Console.WriteLine(" x " + (x + z) + " : " + " y " + (y - z));
                                 Console.WriteLine("clear");       //Checks if squares between are clear
                                 Console.WriteLine("Bishop Reason 7");
                             }
                             else
                             {
                                 Console.WriteLine(" x " + (x + z) + " : " + " y " + (y - z));
                                 Console.WriteLine("full");
                                 Console.WriteLine("Bishop Reason 8");
                                 return false;
                             }
                        } 

                      }

                    if (s[x, y].OnSquare == null)
                    {
                        return true;
                    }
                    else
                    {
                        if (!IsWhite)
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
                    Console.WriteLine(".");

                }

            }


            Console.WriteLine("Reason 1");
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
                        int CheckedSquares = y - column; //gets are between starting square and selected square 

                        for (int i = 1; i < CheckedSquares; i++)
                        {
                            if (s[x,y-i].OnSquare == null)
                            {
                                Console.WriteLine(" x " + x + " : " + " y " + (y - i));
                                Console.WriteLine("clear");       //Checks if squares between are clear
                                Console.WriteLine("reason 1");
                            }
                            else
                            {
                                Console.WriteLine(" x " + x + " : " + " y " + (y-i));
                                Console.WriteLine("full");
                                Console.WriteLine("reason 2");
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
                                Console.WriteLine(" x " + x + " : " + " y " + (y - i));
                                Console.WriteLine("clear");                              
                            }
                            else
                            {
                                Console.WriteLine(" x " + x + " : " + " y " + (y - i));
                                Console.WriteLine("full");
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
                                Console.WriteLine(" x " + (x - i) + " : " + " y " + y);
                                Console.WriteLine("clear");
                                Console.WriteLine("reason 1");
                            }
                            else
                            {
                                Console.WriteLine(" x " + (x - i) + " : " + " y " + y);
                                Console.WriteLine("full");
                                Console.WriteLine("reason 2");
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
                                Console.WriteLine(" x " + (x + i) + " : " + " y " + y);
                                Console.WriteLine("clear");
                            }
                            else
                            {
                                Console.WriteLine(" x " + (x + i) + " : " + " y " + (y - i));
                                Console.WriteLine("full");
                                return false;
                            }
                        }

                    }

                }
                if (s[x,y].OnSquare == null)
                {
                    return true;
                }
                else
                {
                    if (!IsWhite)
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
                           //Need to code castling
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
                if (s[x, y].OnSquare != null) //If piece on square is true
                {
                    if (s[x, y].OnSquare.IsWhite) //If piece on target square is white (attackable)
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
            else
            {
                if (s[x, y].OnSquare != null) //If piece on square is true
                {
                    if (s[x, y].OnSquare.IsWhite == false)
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
            for (int i = 1; i < 7; i++)
            {

                if (((y == column + i) && (x == row + i)) || ((y == column - i) && (x == row + i)) || ((y == column - i) && (x == row - i)) || ((y == column + i) && (x == row - i)))
                {
                    if ((y == column + i) && (x == row + i)) //Bottom right
                    {
                        int CheckedSquares = i;   //Does reach but doesn't do for loop  
                        for (int z = 1; z < CheckedSquares; z++)
                        {
                            if (s[x - z, y - z].OnSquare == null)
                            {
                                Console.WriteLine(" x " + (x - z) + " : " + " y " + (y - z));
                                Console.WriteLine("clear");       //Checks if squares between are clear
                            }
                            else
                            {
                                Console.WriteLine(" x " + (x - z) + " : " + " y " + (y - z));
                                Console.WriteLine("full");
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
                                Console.WriteLine(" x " + (x + z) + " : " + " y " + (y + z));
                                Console.WriteLine("clear");       //Checks if squares between are clear
                                Console.WriteLine("Bishop Reason 3");
                            }
                            else
                            {
                                Console.WriteLine(" x " + (x + z) + " : " + " y " + (y + z));
                                Console.WriteLine("full");
                                Console.WriteLine("Bishop Reason 4");
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
                                Console.WriteLine(" x " + (x - z) + " : " + " y " + (y + z));
                                Console.WriteLine("clear");       //Checks if squares between are clear
                            }
                            else
                            {
                                Console.WriteLine(" x " + (x - z) + " : " + " y " + (y + z));
                                Console.WriteLine("full");
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
                                Console.WriteLine(" x " + (x + z) + " : " + " y " + (y - z));
                                Console.WriteLine("clear");       //Checks if squares between are clear
                            }
                            else
                            {
                                Console.WriteLine(" x " + (x + z) + " : " + " y " + (y - z));
                                Console.WriteLine("full");
                                return false;
                            }
                        }

                    }

                    if (s[x, y].OnSquare == null)
                    {
                        return true;
                    }
                    else
                    {
                        if (!IsWhite)
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
                    Console.WriteLine(".");

                }

            }

            if (x == row || y == column)
            {
                if (x == row) //If y-axis is same
                {
                    if (y > column)  //If selected square is to the right of the rook
                    {
                        int CheckedSquares = y - column; //gets are between starting square and selected square 

                        for (int i = 1; i < CheckedSquares; i++)
                        {
                            if (s[x, y - i].OnSquare == null)
                            {
                                Console.WriteLine(" x " + x + " : " + " y " + (y - i));
                                Console.WriteLine("clear");       //Checks if squares between are clear
                            }
                            else
                            {
                                Console.WriteLine(" x " + x + " : " + " y " + (y - i));
                                Console.WriteLine("full");
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
                                Console.WriteLine(" x " + x + " : " + " y " + (y - i));
                                Console.WriteLine("clear");
                            }
                            else
                            {
                                Console.WriteLine(" x " + x + " : " + " y " + (y - i));
                                Console.WriteLine("full");
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
                                Console.WriteLine(" x " + (x - i) + " : " + " y " + y);
                                Console.WriteLine("clear");
                            }
                            else
                            {
                                Console.WriteLine(" x " + (x - i) + " : " + " y " + y);
                                Console.WriteLine("full");
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
                                Console.WriteLine(" x " + (x + i) + " : " + " y " + y);
                                Console.WriteLine("clear");
                            }
                            else
                            {
                                Console.WriteLine(" x " + (x + i) + " : " + " y " + (y - i));
                                Console.WriteLine("full");
                                return false;
                            }
                        }

                    }

                }
                if (s[x, y].OnSquare == null)
                {
                    return true;
                }
                else
                {
                    if (!IsWhite)
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

    class King : Piece
    {
        public King(Texture2D t, int r, int c, int vo, int ho, bool w) : base(t, r, c, vo, ho, w)
        {

        }

        public override bool CheckMove(int x, int y, Square[,] s)
        {
            if (!IsWhite) //black
            {
                if (s[x,y].OnSquare != null) //target square is occupied
                {
                    if (s[x, y].OnSquare.IsWhite)
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
            else
            {
                if (s[x, y].OnSquare != null) //target square is occupied
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

    abstract class Piece
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
            Position = new Vector2((c * width) + ho, (r * height) + vo); //((c * width) + ho, (r * height) + vo)
            IsSelected = false;
            IsWhite = w;
            
            Console.WriteLine("Piece created " + r +" "+ c +" "+ dest);
        }

        public void updateposition(int r, int c)
        {
            row = r;
            column = c;
            Position = new Vector2((c * width) + hoffset, (r * height) + voffset);  //((c * width) + hoffset, (r * height) + voffset)
            Console.WriteLine(c + " " + r + " : " + Position);
        }

        public abstract bool CheckMove(int x, int y, Square[,] s);
        public void Draw(SpriteBatch spriteBatch)
        {
          
            if (IsSelected)
            {
                MouseState m = Mouse.GetState();
                dest = new Rectangle((int)m.X-(width/2), (int)m.Y-(height/2), width, height);
                spriteBatch.Draw(PieceTexture, dest, Color.Magenta);
            }
            else
            {
                dest = new Rectangle((int)Position.X, (int)Position.Y, width, height);
                spriteBatch.Draw(PieceTexture, dest, Color.White);
            }
            //spriteBatch.Draw(PieceTexture, new Rectangle(300,400, 50, 50), Color.White);



        }

       
    }
}
