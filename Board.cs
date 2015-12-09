using System;
using System.Collections;

/*****************************************************************/
/* Author  : Gavi Narra (gavi@liu.edu)                                     */
/* Date    : 22 Dec 2003                                         */
/*****************************************************************/
namespace JawBreaker
{
	class Board
	{
		// Members of the Board class
		private int rows;
		private int cols;
		private int types;
		private Cell[,] data; 
		private ArrayList selected;
		private Stack undoStack;
		private Stack redoStack;
		private int totalScore;
	        

		public Board(int rows,int cols,int numColors)
		{
			this.rows=rows;
			this.cols=cols;
			this.types=numColors;
			data=new Cell[rows,cols];
			selected=new ArrayList();
			undoStack=new Stack();
			redoStack=new Stack();
			totalScore=0;
		}


		public ArrayList Selected
		{
			get
			{
				if(selected.Count==1)
					selected.Clear();
				return selected;
			}
		}

		public int Rows
		{
			get
			{
				return rows;
			}
		}

		public int Cols
		{
			get
			{
				return cols;
			}
		}

		public int Score
		{
			get
			{
				return totalScore;
			}
		}

		//Initializes the board 

		public void Initialize()
		{
			Random r=new Random();
        

			for(int i=0;i<rows;i++)
			{
				for(int j=0;j<cols;j++)
				{
					data[i,j]=new Cell(i,j,r.Next(types));
				}
			}

			totalScore=0;
			undoStack.Clear();
			redoStack.Clear();
			selected.Clear();

		}

		public Cell[,] Data
		{
			get
			{
				return data;
			}
			// This could come from an undo or redo stack
			set
			{
				data=value;
			}
		}

		public int CurrentSelection
		{
			get
			{
				return GetScore(selected.Count);
			}
		}

		//Checks if all the moves are finished
		public bool GameFinished()
		{
			for(int i=0;i<rows;i++)
			{
				for(int j=0;j<cols;j++)
				{
					Cell c=data[i,j];
					if(c!=null)
					{
						ArrayList arl=GetNeighborhoodCells(c);
						foreach (Cell ce in arl)
						{
							if(c.Type==ce.Type)
								return false;
						}
					}
					
				}
			}

			return true;
			
		}

		public bool IsValidCell(int row,int col)
		{
			if(row<0 || row>rows-1 || col<0 || col > cols-1)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		ArrayList GetNeighborhoodCells(Cell c)
		{
			ArrayList arl=new ArrayList();
			int row=c.Row;
			int col=c.Col;

			if(IsValidCell(row-1,col)&&data[row-1,col]!=null)
			{
				
				arl.Add(data[row-1,col]);
			}

			
			if(IsValidCell(row,col-1)&&data[row,col-1]!=null)
			{
				arl.Add(data[row,col-1]);
			}

			if(IsValidCell(row,col+1)&&data[row,col+1]!=null)
			{
				arl.Add(data[row,col+1]);
			}

			
			if(IsValidCell(row+1,col)&&data[row+1,col]!=null)
			{
				arl.Add(data[row+1,col]);
			}

			

			return arl;
		}

		// Removes cells from the board
		
		public void Remove(ArrayList arl)
		{
			if(arl.Count>0)
			{
				//Fist push the current data to Undo Stack

				undoStack.Push(GetTypeArray());

				//Clear the redo Stack..

				redoStack.Clear();

				


				foreach(Cell c in arl)
				{
					data[c.Row,c.Col]=null;
				}
				
				

				//Sync the board 
				Syncronize();

				//update the score

				totalScore+=GetScore(arl.Count);

				//Clear the selected
				selected.Clear();
			}
		}

		//Selects the neighborhood Cells recursively

		public void Select(Cell c)
		{
			selected.Add(c);
			ArrayList arl=GetNeighborhoodCells(c);
			if(arl.Count==0)
			{
				return;
			}
			foreach(Cell cell in arl)
			{
				if(cell.Type==c.Type&&!selected.Contains(cell))
				{
					Select(cell);
				}
			}
		}

		public void Syncronize()
		{
			//Use bruteforce to sync for the time being
			//Use a cool algorithm here to speed up things
			for(int times=0;times<rows;times++)
			{
			
				for(int i=0;i<rows-1;i++)
				{
					for(int j=0;j<cols;j++)
					{
						Cell c=data[i,j];

						if(c!=null)
						{
							Cell other=data[c.Row+1,c.Col];
							if(other==null)
							{
								data[c.Row+1,c.Col]=c;
								data[c.Row,c.Col]=null;
								c.Row=c.Row+1;
							}

						}
					}
				}
			}

			//Check if any empty columns-- and move accordingly
			//Again use simple algorithm
			for(int times=0;times<cols;times++)
			{
				for(int i=1;i<cols;i++)
				{
					if(isColNull(i))
					{
						MoveCol(i);
					}
				}
			}
			
		}
		/// <summary>
		/// Checks whether given column is null
		/// </summary>
		/// <param name="col"></param>
		/// <returns></returns>

		private bool isColNull(int col)
		{
			for(int i=0;i<rows;i++)
			{
				if(data[i,col]!=null)
					return false;
			}

			return true;
		}

		/// <summary>
		/// Moves the left column to the current position
		/// </summary>
		/// <param name="col"></param>

		private void MoveCol(int col)
		{
			for(int i=0;i<rows;i++)
			{
				Cell c=data[i,col-1];
				if(c!=null)
				{
					c.Col=col;
					data[i,col]=c;
					data[i,col-1]=null;
					
				}
			}
		}



		public override string ToString()
		{
			string str="";
			for(int i=0;i<data.GetLength(0);i++)
			{
				for(int j=0;j<data.GetLength(1);j++)
				{
					str+=(data[i,j]+" | ");
				}
				str+="\r\n\r\n";
			}

			return str;

		}

		public void SetTypeArray(int[,] arr)
		{
			for(int i=0;i<rows;i++)
			{
				for(int j=0;j<cols;j++)
				{
						
					Cell c=data[i,j];

					if(arr[i,j]==-1)
					{
						data[i,j]=null;
					}
					else
					{
						if(c==null)
						{
							data[i,j]=new Cell(i,j,arr[i,j]);
						}
						else
						{
							c.Type=arr[i,j];
						}
					}
				}
					
			}

		}


		public int[,] GetTypeArray()
		{
			int[,] arr=new int[rows,cols];
			for(int i=0;i<rows;i++)
			{
				for(int j=0;j<cols;j++)
				{
					if(data[i,j]!=null)
					{
						arr[i,j]=data[i,j].Type;
					}
					else
					{
						arr[i,j]=-1;
					}
				}
			}

			return arr;
		}

		private int GetActiveCells(int[,] arr)
		{
			int total=0;
			for(int i=0;i<arr.GetLength(0);i++)
			{
				for(int j=0;j<arr.GetLength(1);j++)
				{
					if(arr[i,j]!=-1)
						total++;
				}

			}

			return total;
		}



		public bool Undo()
		{
			if(undoStack.Count>0)
			{
				selected.Clear();
				//Push to redo
				int[,] current=GetTypeArray();
				int[,] popped=(int[,])undoStack.Pop();

				//update the scores
				totalScore-=GetScore(GetActiveCells(popped)-GetActiveCells(current));

				redoStack.Push(current);
				SetTypeArray(popped);
				return true;
			}

			return false;

		}




		public bool Redo()
		{
			if(redoStack.Count>0)
			{
				selected.Clear();
				int[,] current=GetTypeArray();
				int[,] popped=(int[,])redoStack.Pop();

				//update score
				totalScore+=GetScore(GetActiveCells(current)-GetActiveCells(popped));

				//push current to undo
				undoStack.Push(current);

				//pop for redo stack
				SetTypeArray(popped);
				return true;
			}

			return false;


		}

		/// <summary>
		/// The rule to calculate the score.
		/// </summary>
		/// <param name="num"></param>
		/// <returns></returns>

		private int GetScore(int num)
		{
			return num*(num-1);
		}



		
	}
}