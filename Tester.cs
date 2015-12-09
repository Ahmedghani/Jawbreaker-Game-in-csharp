using System;

namespace JawBreaker
{
	/// <summary>
	/// Summary description for Tester.
	/// </summary>
	public class Tester
	{
		public Tester()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void Test()
		{
			Cell[,] data=new Cell[3,3];
			Initialize(data);
			data[2,1]=null;
			Syncronize(data);
			Print(data);

			Console.ReadLine();


		}

		public static void Initialize(Cell[,] data)
		{
			int rows=data.GetLength(0);
			int cols=data.GetLength(1);
			for(int i=0;i<rows;i++)
			{
				for(int j=0;j<cols;j++)
				{

					data[i,j]=new Cell(i,j,3);
				}
				
			}

			


		}



		public static void Syncronize(Cell[,] data)
		{
			int rows=data.GetLength(0);
			int cols=data.GetLength(1);

			//Use bruteforce to sync for the time being
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
								
							}

						}
					}
				}
			}
			
		}

		public static void Print(Cell[,] data)
		{
			int rows=data.GetLength(0);
			int cols=data.GetLength(1);
			for(int i=0;i<rows;i++)
			{
				for(int j=0;j<cols;j++)
				{
					if(data[i,j]==null)
					{
						Console.Write("--null-"+" ");
					}

					Console.Write(data[i,j]+" ");
				}
				Console.WriteLine();
			}

		}

		public static void Print(int[,] data)
		{
			int rows=data.GetLength(0);
			int cols=data.GetLength(1);
			for(int i=0;i<rows;i++)
			{
				for(int j=0;j<cols;j++)
				{
					Console.Write(data[i,j]+" ");
				}
				Console.WriteLine();
			}

		}



	}
}
