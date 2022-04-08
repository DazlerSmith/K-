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
        Square SelectedSq = null;
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
            foreach(Square sq in Squares)
            { 
                if (sq.OnSquare != null)
                {
                    sq.OnSquare.IsSelected = false;
                        
                }
                sq.IsSelected = false;
            }
            Selected = null;
            SelectedSq = null;
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
                        bool Check1 = CheckingCheck(Squares, SelectedSq, Squares[Y, X], turn);  // Changed from Y,X to X,Y for check
                                                                                            // But still thinks you are in check
                            
                        Console.WriteLine(check);
                        if (check && !Check1 )
                        {
                            Console.WriteLine(" Placed : " + check);
                            Squares[Y, X].OnSquare = null;
                            Squares[Y, X].OnSquare = Selected;
                            //Squares[(int)Selected.row, (int)Selected.column].OnSquare = null;
                            Squares[(int)Selected.row, (int)Selected.column].IsSelected = false;
                            Squares[Y, X].OnSquare.updateposition(Y, X);
                            Selected = null;
                            SelectedSq.OnSquare = null;
                            SelectedSq = null;
                            Squares[Y, X].OnSquare.IsSelected = false;
                            Squares[Y, X].IsSelected = false;
                            Unselect();
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
                            SelectedSq = Squares[Y, X];
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

        public bool CheckingCheck ( Square[,] s, Square selected, Square moveto, bool turn) //sx = starting x position
        {                                                                                     //fx = final x position
            Square[,] tempsq = new Square[8, 8]; 
            Color colour = Color.AliceBlue;
            Square tempssq = null;
            Square tempmsq = null;
            //for (int r = 0; r < size; r++)
            //{
            //    for (int c = 0; c < size; c++)
            //   {
            foreach (Square sq in s)
            { 
                // determine colour
                //Square temp = new Square(sq.row, sq.column, sq.t, voffset, hoffset, colour);
                //tempsq[r, c] = new Square(r, c, t, voffset, hoffset, colour);
                tempsq[sq.row,sq.column]= sq.Clone() as Square;           //tempsq[r,c] 

                if (moveto.row == sq.row && moveto.column == sq.column)
                {
                    tempmsq = tempsq[sq.row, sq.column];
                }

                if (sq.OnSquare != null)
                {
                    tempsq[sq.row, sq.column].OnSquare = sq.OnSquare;
                    tempsq[sq.row, sq.column].OnSquare.row = sq.row;
                    tempsq[sq.row, sq.column].OnSquare.column =sq.column;
                    if (selected.row == sq.row && selected.column==sq.column)
                    {
                        tempssq = tempsq[sq.row, sq.column];
                    }

                    //tempsq[r,c] 
                }
                else
                {
                    Console.WriteLine("Empty Square");
                }
                    
                if (colour == Color.AliceBlue && sq.column < 7)
                    colour = Color.Silver;
                else if (colour == Color.Silver && sq.column < 7)
                    colour = Color.AliceBlue;


                }
            //}

            Square InitialPiecePosition =tempssq;    //[sx, sy]
            Console.WriteLine("Piece to move is "+ InitialPiecePosition.OnSquare.GetType().ToString());
            Square FinalPiecePosition = tempmsq;     //[fx, fy]
            Console.WriteLine("New Square = " + FinalPiecePosition.row + " : " + FinalPiecePosition.column);
            Console.WriteLine("Turn = " + turn);
            FinalPiecePosition.OnSquare = InitialPiecePosition.OnSquare;
            FinalPiecePosition.OnSquare.row = FinalPiecePosition.row;
            FinalPiecePosition.OnSquare.column = FinalPiecePosition.column;
            InitialPiecePosition.OnSquare = null;

            King king = null;
            foreach (Square sq in tempsq)
            {
                string p = "";            // This finds the square that will contain the king piece
                    if (sq.OnSquare != null)
                    {
                        p = sq.OnSquare.GetType().ToString();
                        Console.WriteLine("p: " + p + " col: "+ sq.column + " row: "+ sq.row + " pcol: " + sq.OnSquare.column+ " prow: " + sq.OnSquare.row);
                    }
                    if (p.Contains("King") && sq.OnSquare.IsWhite == turn)
                    {
                        king = sq.OnSquare as King;
                        Console.WriteLine("King Found " + king.column + " : " + king.row);
                    }

                
            }
            if (king == null)
            {
                return false;
            }
            Console.WriteLine("***********************************************");

            foreach (Square sq in tempsq)
            {
                bool m=false;
                    if (sq.OnSquare != null)
                    {
                        if (turn != sq.OnSquare.IsWhite)
                        {
                            m = sq.OnSquare.CheckMove(king.row, king.column, tempsq);
                            if (m)
                            {
                                Console.WriteLine(sq.OnSquare.GetType().ToString() + " can take king " + sq.column + " : " + sq.row);
                                return true;
                            }
                            else
                            {
                                Console.WriteLine(sq.OnSquare.GetType().ToString() + " no check : " + sq.column + " : " + sq.row + " King : " + king.row + " : " + king.column);
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
