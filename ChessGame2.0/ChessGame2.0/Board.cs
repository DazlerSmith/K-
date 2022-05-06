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
        Timer movetimer = new Timer();  //Timer created to not spam inputs
        int moves = 0;


        public Square[,] Squares = new Square[8,8]; //Creates 8x8 board.

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
                    Squares[r,c]= new Square(r, c, t, voffset, hoffset, colour);
                    if (colour == Color.AliceBlue && c < 7)         //This loop creates alternating squares going from left to right until 8 squares are on a row, then drops down to the next row
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
                    sq.OnSquare.IsSelected = false;  //Unselects the piece 
                        
                }
                sq.IsSelected = false; //Unselects the square
            }
            Selected = null;
            SelectedSq = null;
        }

        //Mouse Input
        public void ClickBoard(int X, int Y)
        {
            Y = Y - 50;
            X = X - 200;   

            X = X / 50;  //Simplifies coordinates to 1,2,3,4......
            Y = Y / 50;
            if (X >= 0 && X <= 7 && Y >= 0 && Y <= 7)
            {
                if(!movetimer.Enabled && Mouse.GetState().LeftButton == ButtonState.Pressed) 
                {
                    bool turn = moves % 2 == 0; //For who's turn the game is
                    if (Selected != null && Selected.IsWhite == turn)   // White's turn, timer is disabled(can move a piece)
                    {
                       

                        bool check = Selected.CheckMove(Y , X , Squares); //Check is checking the moves themselves
                        bool Check1 = CheckingCheck(Squares, SelectedSq, Squares[Y, X], turn);  //Check1 is the Check mechanic
                                                                                           
                            
                        Console.WriteLine(check);
                        if (check && !Check1 ) //Not in check but checking move for specific piece
                        {
                            Console.WriteLine(" Placed : " + check);
                            Squares[Y, X].OnSquare = null;
                            Squares[Y, X].OnSquare = Selected; 
                            Squares[(int)Selected.row, (int)Selected.column].IsSelected = false; 
                            Squares[Y, X].OnSquare.updateposition(Y, X);   //Updates position
                            Selected = null;
                            SelectedSq.OnSquare = null;
                            SelectedSq = null;                         //Completes process then nullifies all previous actions
                            Squares[Y, X].OnSquare.IsSelected = false;
                            Squares[Y, X].IsSelected = false;
                            Unselect();
                            movetimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                            movetimer.Interval = 500;
                            movetimer.Enabled = true;   //All this is while a piece is already selected and is being placed or tried to place.
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
                            Selected = Squares[Y, X].OnSquare;      //This is before a piece has been selected
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
        public bool CheckingCheckMate(Square[,] s, bool turn) //Checkmate method
        {
            foreach (Square sq in s) //Goes throgh each square
            {
                if (sq.OnSquare != null)   //Checks for pieces on squares
                {
                    if (sq.OnSquare.IsWhite == turn) // Targets sepecific pieces of the user's turn
                    {
                        foreach (Square cms in s)    
                        {
                            Square[,] temp = s;
                            bool check = sq.OnSquare.CheckMove(cms.row, cms.column, temp); //Then checks that move is legal to the square
                            if (check) //If move is legal it will then check check.
                            {
                                bool Check1 = CheckingCheck(temp, sq, cms, turn);
                                if (!Check1)
                                {
                                    return false;
                                }
                            }

                        }
                    }
                }
            }

            return true;
        }
        public bool CheckingCheck ( Square[,] s, Square selected, Square moveto, bool turn) //Checking Check method
        {                                                                                     
            Square[,] tempsq = new Square[8, 8]; //Creates a replicated board
            Color colour = Color.AliceBlue;
            Square tempssq = null;
            Square tempmsq = null;

            foreach (Square sq in s)
            { 

                tempsq[sq.row,sq.column]= sq.Clone() as Square;           

                if (moveto.row == sq.row && moveto.column == sq.column)
                {
                    tempmsq = tempsq[sq.row, sq.column]; //This will execute the move requested from the physical board to the replicated board to check for check.
                }

                if (sq.OnSquare != null)
                {
                    tempsq[sq.row, sq.column].OnSquare = sq.OnSquare;
                    tempsq[sq.row, sq.column].OnSquare.row = sq.row;     //Copies over all values from physical to replicated
                    tempsq[sq.row, sq.column].OnSquare.column =sq.column;

                    if (selected.row == sq.row && selected.column==sq.column)
                    {
                        tempssq = tempsq[sq.row, sq.column];
                    }

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

            Square InitialPiecePosition =tempssq;    
            Console.WriteLine("Piece to move is "+ InitialPiecePosition.OnSquare.GetType().ToString());  //Gets initial piece
            Square FinalPiecePosition = tempmsq;     
            Console.WriteLine("New Square = " + FinalPiecePosition.row + " : " + FinalPiecePosition.column);
            Console.WriteLine("Turn = " + turn);
            FinalPiecePosition.OnSquare = InitialPiecePosition.OnSquare;  
            FinalPiecePosition.OnSquare.row = FinalPiecePosition.row;
            FinalPiecePosition.OnSquare.column = FinalPiecePosition.column;    //Just moves the piece over to new square
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
                bool m=false;    //This checks if any pieces can take the king at the current board position
                    if (sq.OnSquare != null)
                    {
                        if (turn != sq.OnSquare.IsWhite) //Checks black pieces
                        {
                            m = sq.OnSquare.CheckMove(king.row, king.column, tempsq); //Intersection
                            if (m) //If any move is found that can take the king
                            {
                                Console.WriteLine(sq.OnSquare.GetType().ToString() + " can take king " + sq.column + " : " + sq.row);
                                return true; //Piece x can take king at position y
                            }
                            else //No moves can take the king at the current board position.
                            {
                                Console.WriteLine(sq.OnSquare.GetType().ToString() + " no check : " + sq.column + " : " + sq.row + " King : " + king.row + " : " + king.column);
                            }
                        }
                        else
                        {
                            Console.WriteLine("ignore");
                        }

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

                    Squares[r, c].Draw(sb);    //This will draw all 64 squares onto the board
                    


                }
            }
            if (Selected != null)
                Selected.Draw(sb);
        }






    }
}
