using System;

/*****************************************************************/
/* Author  : Gavi Narra (gavi@liu.edu)                                     */
/* Date    : 22 Dec 2003                                         */
/*****************************************************************/

namespace JawBreaker
{
	public class Cell
	{
		int row;
		int col;
		int type;

		public Cell(int row,int col,int type)
		{
			this.row=row;
			this.col=col;
			this.type=type;
		}

		public int Row
		{
			get
			{
				return row;
				
			}
			set
			{
				this.row=value;
			}
		}


		public int Col
		{
			get
			{
				return this.col;
			}

			set
			{
				this.col=value;
			}
		}

		public int Type
		{
			get
			{
				return type;
			}

			set
			{
				this.type=value;
			}
		}

		public override string ToString()
		{
			return "("+row+","+col+"):"+type;
		}

		
		
	}
}
