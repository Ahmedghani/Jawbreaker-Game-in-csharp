using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;
/*****************************************************************/
/* Author  : Gavi Narra (gavi@liu.edu)                                     */
/* Date    : 22 Dec 2003                                         */
/*****************************************************************/

namespace JawBreaker
{
	public class MainForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.StatusBarPanel score;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuNew;
		private System.Windows.Forms.MenuItem menuSep1;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuAbout;
		private System.Windows.Forms.Panel boardPanel;
		private System.Windows.Forms.StatusBarPanel expectedScore;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.MenuItem menuEdit;
		private System.Windows.Forms.MenuItem menuUndo;
		private System.Windows.Forms.MenuItem menuDebug;
		private System.Windows.Forms.MenuItem menuRedo;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.ToolBar toolBar;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolBarButton toolBarNew;
		private System.Windows.Forms.ToolBarButton toolBarSep1;
		private System.Windows.Forms.ToolBarButton toolBarUndo;
		private System.Windows.Forms.ToolBarButton toolBarRedo;
		
		/*Program specific objects*/
		private Board b;
		private Color[] colors;

		public MainForm()
		{
			InitializeComponent();
			colors=new Color[]{Color.Red,Color.Green,Color.Blue,Color.Brown,Color.Gray};
			b=new Board(12,12,colors.Length);
			b.Initialize();
			
			
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.boardPanel = new System.Windows.Forms.Panel();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.score = new System.Windows.Forms.StatusBarPanel();
			this.expectedScore = new System.Windows.Forms.StatusBarPanel();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuNew = new System.Windows.Forms.MenuItem();
			this.menuSep1 = new System.Windows.Forms.MenuItem();
			this.menuExit = new System.Windows.Forms.MenuItem();
			this.menuEdit = new System.Windows.Forms.MenuItem();
			this.menuUndo = new System.Windows.Forms.MenuItem();
			this.menuRedo = new System.Windows.Forms.MenuItem();
			this.menuHelp = new System.Windows.Forms.MenuItem();
			this.menuAbout = new System.Windows.Forms.MenuItem();
			this.menuDebug = new System.Windows.Forms.MenuItem();
			this.toolBar = new System.Windows.Forms.ToolBar();
			this.toolBarNew = new System.Windows.Forms.ToolBarButton();
			this.toolBarSep1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarUndo = new System.Windows.Forms.ToolBarButton();
			this.toolBarRedo = new System.Windows.Forms.ToolBarButton();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.score)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.expectedScore)).BeginInit();
			this.SuspendLayout();
			// 
			// boardPanel
			// 
			this.boardPanel.Location = new System.Drawing.Point(8, 32);
			this.boardPanel.Name = "boardPanel";
			this.boardPanel.Size = new System.Drawing.Size(360, 360);
			this.boardPanel.TabIndex = 6;
			this.boardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.boardPanel_Paint);
			this.boardPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.boardPanel_MouseDown);
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 395);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						 this.score,
																						 this.expectedScore});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(374, 22);
			this.statusBar.SizingGrip = false;
			this.statusBar.TabIndex = 7;
			// 
			// score
			// 
			this.score.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.score.Text = "Total Score: 0";
			this.score.Width = 260;
			// 
			// expectedScore
			// 
			this.expectedScore.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.expectedScore.Text = "Current Selection: 0";
			this.expectedScore.Width = 114;
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFile,
																					 this.menuEdit,
																					 this.menuHelp});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuNew,
																					 this.menuSep1,
																					 this.menuExit});
			this.menuFile.Text = "&Game";
			// 
			// menuNew
			// 
			this.menuNew.Index = 0;
			this.menuNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.menuNew.Text = "&New";
			this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
			// 
			// menuSep1
			// 
			this.menuSep1.Index = 1;
			this.menuSep1.Text = "-";
			// 
			// menuExit
			// 
			this.menuExit.Index = 2;
			this.menuExit.Text = "E&xit";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// menuEdit
			// 
			this.menuEdit.Index = 1;
			this.menuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuUndo,
																					 this.menuRedo});
			this.menuEdit.Text = "&Moves";
			// 
			// menuUndo
			// 
			this.menuUndo.Index = 0;
			this.menuUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
			this.menuUndo.Text = "&Undo";
			this.menuUndo.Click += new System.EventHandler(this.menuUndo_Click);
			// 
			// menuRedo
			// 
			this.menuRedo.Index = 1;
			this.menuRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
			this.menuRedo.Text = "Redo";
			this.menuRedo.Click += new System.EventHandler(this.menuRedo_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.Index = 2;
			this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuAbout,
																					 this.menuDebug});
			this.menuHelp.Text = "&Help";
			// 
			// menuAbout
			// 
			this.menuAbout.Index = 0;
			this.menuAbout.Text = "&About JawBreaker";
			this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
			// 
			// menuDebug
			// 
			this.menuDebug.Index = 1;
			this.menuDebug.Text = "&Debug";
			this.menuDebug.Click += new System.EventHandler(this.menuDebug_Click);
			// 
			// toolBar
			// 
			this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					   this.toolBarNew,
																					   this.toolBarSep1,
																					   this.toolBarUndo,
																					   this.toolBarRedo});
			this.toolBar.ButtonSize = new System.Drawing.Size(16, 16);
			this.toolBar.DropDownArrows = true;
			this.toolBar.ImageList = this.imageList;
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.ShowToolTips = true;
			this.toolBar.Size = new System.Drawing.Size(374, 29);
			this.toolBar.TabIndex = 8;
			this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
			// 
			// toolBarNew
			// 
			this.toolBarNew.ImageIndex = 0;
			this.toolBarNew.ToolTipText = "New Game";
			// 
			// toolBarSep1
			// 
			this.toolBarSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarUndo
			// 
			this.toolBarUndo.ImageIndex = 1;
			this.toolBarUndo.ToolTipText = "Undo Move";
			// 
			// toolBarRedo
			// 
			this.toolBarRedo.ImageIndex = 2;
			this.toolBarRedo.ToolTipText = "Redo Move";
			// 
			// imageList
			// 
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(374, 417);
			this.Controls.Add(this.toolBar);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.boardPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mainMenu;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "JawBreaker Version 1.0 <gavi@liu.edu>";
			((System.ComponentModel.ISupportInitialize)(this.score)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.expectedScore)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void DrawBoard(Graphics grfx)
		{
			//Do Double Buffering
			Bitmap offScreenBmp; 
			Graphics offScreenDC; 
			offScreenBmp = new Bitmap(boardPanel.Width, boardPanel.Height); 
			offScreenDC = Graphics.FromImage(offScreenBmp); 

			offScreenDC.Clear(boardPanel.BackColor);
			offScreenDC.SmoothingMode=SmoothingMode.AntiAlias;

			int height=boardPanel.Height-1;
			int width=boardPanel.Width-1;
			
			int rectHeight=(int)Math.Round((double)height/b.Cols);
			int rectWidth=(int)Math.Round((double)width/b.Rows);

			
			
			int x=0;
			int y=0;
			ArrayList arl=b.Selected;
			

			for(int i=0;i<b.Rows;i++)
			{
				x=0;
				for(int j=0;j<b.Cols;j++)
				{
					Rectangle r=new Rectangle(x,y,rectWidth-2,rectHeight-2);
					
					Cell c=b.Data[i,j];
					if(c!=null)
					{
						if(arl.Contains(c))
						{

							DrawBall(offScreenDC,r,colors[c.Type],true);
						}
						else
						{
							DrawBall(offScreenDC,r,colors[c.Type],false);
						}
					}
					else
					{
						//Do nothing
					}

					x+=rectWidth;
				}
				y+=rectHeight;
			}

			if(arl.Count>0)
			{
				//Select the first cell(The cell the user clicked on first)
				Cell c=(Cell)arl[0];

				//Calculate the x and y coordinates
				int x1=c.Col*rectWidth;
				int y1=c.Row*rectHeight;

				//Show the Score..s
				Rectangle scr=new Rectangle(x1,y1,30,30);
				//offScreenDC.F
				StringFormat sf=new StringFormat();
				sf.Alignment=StringAlignment.Center;
				sf.LineAlignment=StringAlignment.Center;
				offScreenDC.DrawString(b.CurrentSelection.ToString(),new Font("Arial",8,FontStyle.Bold),Brushes.Black,scr,sf);

			}

			grfx.DrawImageUnscaled(offScreenBmp, 0, 0); 


		}
	
		//Draws a ball
		public void DrawBall(Graphics grfx,Rectangle rect,Color c,bool Selected)
		{
			if(Selected)
			{
				grfx.FillRectangle(Brushes.Goldenrod,rect);
			}
			GraphicsPath path=new GraphicsPath();
			
			path.AddEllipse(rect);

			PathGradientBrush pgbrush= new PathGradientBrush(path);
			pgbrush.CenterPoint=new Point((rect.Right- rect.Left) /3+rect.Left,(rect.Bottom - rect.Top) /3+rect.Top);
			pgbrush.CenterColor=Color.White;
			pgbrush.SurroundColors=new Color[] { c };
			
			grfx.FillRectangle(pgbrush,rect);
			grfx.DrawEllipse(new Pen(c),rect);

			
			
		}

		private void boardPanel_MouseDown(object sender, MouseEventArgs e)
		{
			
			int x=e.X;
			int y=e.Y;
			
			int height=boardPanel.Height-1;
			int width=boardPanel.Width-1;
			
			int rectHeight=(int)Math.Round((double)height/b.Cols);
			int rectWidth=(int)Math.Round((double)width/b.Rows);


			int col=(int)x/rectWidth;
			int row=(int)y/rectHeight;
						
			ArrayList selected=b.Selected;
			
			Cell currentCell=b.Data[row,col];
			if(currentCell!=null)
			{

				if(selected.Contains(currentCell))
				{
					
					expectedScore.Text="Current Selection: 0";
		
					b.Remove(selected);
					UpdateScore();
					
				}
				else
				{
					b.Selected.Clear();
					b.Select(currentCell);
					expectedScore.Text="Current Selection: "+GetScore(b.Selected.Count);
				}
			
				
			}
			else
			{
				//He clicked on a null Cell -> Clear the selection

				b.Selected.Clear();
				expectedScore.Text="Current Selection: 0";
			}

			DrawBoard(boardPanel.CreateGraphics());
			if(b.GameFinished())
			{
				

				if(MessageBox.Show(this,"Game Over!!. Your total Score was: "+b.Score+"\nDo you want to Start a New Game?","JawBreaker",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation)==DialogResult.Yes)
				{
					NewGame();
				}
				
			}

			
		}

		private int GetScore(int num)
		{
			return num*(num-1);
		}

		private void menuNew_Click(object sender, System.EventArgs e)
		{
			NewGame();
		}

		private void NewGame()
		{
			b.Initialize();
			UpdateScore();
			score.Text="Total Score: 0";
			DrawBoard(boardPanel.CreateGraphics());
		}

		private void menuAbout_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(this,"JawBreaker by Gavi Narra","JawBreaker",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void menuUndo_Click(object sender, System.EventArgs e)
		{
			UndoMove();
			
		}

		private void boardPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			DrawBoard(boardPanel.CreateGraphics());
		}

		private void menuDebug_Click(object sender, System.EventArgs e)
		{
			
		}

		private void UpdateScore()
		{
			score.Text="Total Score: "+b.Score;
		}

		private void menuRedo_Click(object sender, System.EventArgs e)
		{
			RedoMove();
			
		}

		public void UndoMove()
		{
			if(b.Undo())
			{
				DrawBoard(boardPanel.CreateGraphics());
				UpdateScore();
			}
		}

		public void RedoMove()
		{
			if(b.Redo())
			{
				DrawBoard(boardPanel.CreateGraphics());
				UpdateScore();
			
			}
			
		}

		private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button==toolBarNew)
			{
				NewGame();
			}
			else if(e.Button==toolBarUndo)
			{
				UndoMove();
			}
			else if(e.Button==toolBarRedo)
			{
				RedoMove();
			}
		}

		

	}
}
