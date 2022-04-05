using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace ChessGame2._0
{
    class Board
    {
        int size = 8;
        int hoffset = 200;
        int voffset = 50;
        Piece Selected = null;
        Timer movetimer = new Timer();
        int moves = 0;


        public Square[,] Squares = new Square[8,8];

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            movetimer.Enabled = false;
        }

        public Board(Texture2D t)
        {
            Color colour = Color.AliceBlue;
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    // determine colour
                    //Square temp = new Square(r, c, t, voffset, hoffset, colour);
                    Squares[r,c]= new Square(r, c, t, voffset, hoffset, colour);
                    if (colour == Color.AliceBlue && c < 7)
                        colour = Color.Silver;
                    else if (colour == Color.Silver && c < 7)
                        colour = Color.AliceBlue;


                }
            }
            //SetupBoard();
        }

        public void Unselect()
        {
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (Squares[r, c].OnSquare != null)
                    {
                        Squares[r, c].OnSquare.IsSelected = false;
                        Squares[r, c].IsSelected = false;
                    }


                }
            }
            Selected = null;
        }

        //Mouse Input
        public void ClickBoard(int X, int Y)
        {
            Y = Y - 50;
            X = X - 200;   

            X = X / 50;
            Y = Y / 50;
            if (X >= 0 && X <= 7 && Y >= 0 && Y <= 7)
            {
                if(!movetimer.Enabled && Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                    bool turn = moves % 2 == 0;
                    if (Selected != null && Selected.IsWhite == turn)
                    {
                       

                        bool check = Selected.CheckMove(Y , X , Squares);
                        bool Check1 = false;// CheckingCheck(Squares, Selected.row, Selected.column, Y, X, turn);  // Changed from Y,X to X,Y for check
                                                                                            // But still thinks you are in check
                            
                        Console.WriteLine(check);
                            if (check && !Check1 )
                            {
                                Console.WriteLine(" Placed : " + check);
                                Squares[Y, X].OnSquare = null;
                                Squares[Y, X].OnSquare = Selected;
                                Squares[(int)Selected.row, (int)Selected.column].OnSquare = null;
                                Squares[(int)Selected.row, (int)Selected.column].IsSelected = false;
                                Squares[Y, X].OnSquare.updateposition(Y, X);
                                Selected = null;
                                Squares[Y, X].OnSquare.IsSelected = false;
                                Squares[Y, X].IsSelected = false;
                                //Unselect();
                                movetimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                                movetimer.Interval = 500;
                                movetimer.Enabled = true;
                                moves++;
                            }
                        else if (Check1)
                        {
                            Console.WriteLine("You are in check");
                            Unselect();
                            Console.WriteLine("unselect");
                        }
                        else
                        {
                            Unselect();
                            Console.WriteLine("unselect");
                        }


                    }
                    else
                    {
                        Unselect();
                        if (Squares[Y, X].OnSquare != null)
                        {
                            Squares[Y, X].IsSelected = true;
                            Squares[Y, X].OnSquare.IsSelected = true;
                            Selected = Squares[Y, X].OnSquare;
                            Console.WriteLine("Piece Selected " + X + " " + Y);
                            movetimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                            movetimer.Interval = 1000;
                            movetimer.Enabled = true;
                        }
                        else
                        {
                            Console.WriteLine("Piece on square");
                        }
                    }
                    Console.WriteLine(X + " " + Y + " ");
                }
            }
            else
                Unselect();
           
        }

        public bool CheckingCheck ( Square[,] s, int sx, int sy, int fy, int fx, bool turn) //sx = starting x position
        {                                                                                     //fx = final x position
            Square[,] tempsq = new Square[8, 8]; 
            Color colour = Color.AliceBlue;
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    // determine colour
                    //Square temp = new Square(r, c, t, voffset, hoffset, colour);
                    //tempsq[r, c] = new Square(r, c, t, voffset, hoffset, colour);
                    tempsq[r,c]= s[r,c];           //tempsq[r,c] 

                    if (s[r,c].OnSquare != null)
                    {
                        tempsq[r,c].OnSquare = s[r,c].OnSquare;
                        tempsq[r, c].OnSquare.row = r;
                        tempsq[r, c].OnSquare.column =c;
                        //tempsq[r,c] 
                    }
                    else
                    {
                        Console.WriteLine("Empty Square");
                    }
                    
                    if (colour == Color.AliceBlue && c < 7)
                        colour = Color.Silver;
                    else if (colour == Color.Silver && c < 7)
                        colour = Color.AliceBlue;


                }
            }

            Square InitialPiecePosition = tempsq[sx, sy];    //[sx, sy]
            Console.WriteLine("Piece to move is " + sy + " : " + sx + " " + InitialPiecePosition.OnSquare.GetType().ToString());
            Square FinalPiecePosition = tempsq[fx, fy];     //[fx, fy]
            Console.WriteLine("New Square = " + FinalPiecePosition.row + " : " + FinalPiecePosition.column);
            Console.WriteLine("Turn = " + turn);
            FinalPiecePosition.OnSquare = InitialPiecePosition.OnSquare;
            FinalPiecePosition.OnSquare.row = FinalPiecePosition.row;
            FinalPiecePosition.OnSquare.column = FinalPiecePosition.column;
            InitialPiecePosition.OnSquare = null;

            King king = null;
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    string p = "";            // This finds the square that will contain the king piece
                    if (tempsq[r, c].OnSquare != null)
                    {
                        p = tempsq[r, c].OnSquare.GetType().ToString();
                        Console.WriteLine("p: " + p);
                    }
                    if (p.Contains("King") && tempsq[r, c].OnSquare.IsWhite == turn)
                    {
                        king = tempsq[r, c].OnSquare as King;
                        Console.WriteLine("King Found " + king.column + " : " + king.row);
                    }

                }
            }
            Console.WriteLine("***********************************************");

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c<size; c++)
                {
                    bool m=false;
                    if (tempsq[r,c].OnSquare != null)
                    {
                        if (turn != tempsq[r, c].OnSquare.IsWhite)
                        {
                            m = tempsq[r, c].OnSquare.CheckMove(king.row, king.column, tempsq);
                            if (m)
                            {
                                Console.WriteLine(tempsq[r,c].OnSquare.GetType().ToString() + " can take king " + c + " : " + r);
                                return true;
                            }
                            else
                            {
                                Console.WriteLine(tempsq[r,c].OnSquare.GetType().ToString() + " no check : " + c + " : " + r);
                            }
                        }
                        else
                        {
                            Console.WriteLine("ignore");
                        }

                    }

                    /*bool m=false;
                    if (tempsq[r, c].OnSquare != null)
                    {
                        if (turn != tempsq[r, c].OnSquare.IsWhite)
                        {
                            m = tempsq[r, c].OnSquare.CheckMove(king.column, king.row, tempsq);

                        }
                        if (m)
                        {
                            Console.WriteLine(tempsq[r, c].OnSquare.GetType().ToString() + " can take king " + c + " : " + r);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine(tempsq[r, c].OnSquare.GetType().ToString() + " no check : " + c + " : " + r);
                        }
                    }
                    */

                }
            }

            return false;
        }

        public void Draw(SpriteBatch sb)
        {
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {

                    Squares[r, c].Draw(sb);
                    


                }
            }
            if (Selected != null)
                Selected.Draw(sb);
        }






    }
}
