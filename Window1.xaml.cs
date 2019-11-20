#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Syncfusion.Windows.Controls.Cells;
using System.Windows.Controls;
using System.Data;

namespace VirtualGrid
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.DataContext = new Dictionary<RowColumnIndex, object>();
            InitializeGridControl();
            
        }
        Random r = new Random();
        private void InitializeGridControl()
        {
            DataTable table = CreateTable();
            grid.Model.RowCount = table.Rows.Count;
            grid.Model.ColumnCount = table.Columns.Count;
            for (int i = 1; i <= grid.Model.RowCount; i++)
                for (int j = 1; j < grid.Model.ColumnCount; j++)
                    grid.Model[i, j].CellValue = dt.Rows[i - 1][j - 1];
        }
        private Rect GetBoundingBox(FrameworkElement element, UserControl containerWindow)
        {
            GeneralTransform transform = element.TransformToAncestor(containerWindow);
            //To get the left and top location of the element.
            Point topLeft = transform.Transform(new Point(0, 0));
            //To get the right and bottom point of the element using height and width.
            Point bottomRight = transform.Transform(new Point(element.ActualWidth, element.ActualHeight));
            return new Rect(topLeft, bottomRight);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Suggestion 1
            Rect rect = GetBoundingBox(grid as FrameworkElement, this.contrl);
            //Suggestion 2
            Point position = this.grid.PointToScreen(new Point(0d, 0d)),
                controlPosition = this.PointToScreen(new Point(0d, 0d));
            //To get grid's exact position on the window.
            position.X -= controlPosition.X;
            position.Y -= controlPosition.Y;
            MessageBox.Show("Rectangle of the grid : " + rect.ToString() + "\n\nPosition X : " + position.X.ToString() + "\n\nPosition Y : " + position.Y.ToString());
        }
        #region "DataTable"
        string[] name1 = new string[] { "John", "Peter", "Smith", "Jay", "Krish", "Mike" };
        string[] country = new string[] { "UK", "USA", "Pune", "India", "China", "England" };
        string[] city = new string[] { "Graz", "Resende", "Bruxelles", "Aires", "Rio de janeiro", "Campinas" };
        string[] scountry = new string[] { "Brazil", "Belgium", "Austria", "Argentina", "France", "Beiging" };
        DataTable dt = new DataTable();
        int col = 0;
        private DataTable CreateTable()
        {

            dt.Columns.Add("Name");
            dt.Columns.Add("Id");
            dt.Columns.Add("Date");
            dt.Columns.Add("Country");
            dt.Columns.Add("Ship City");
            dt.Columns.Add("Ship Country");
            dt.Columns.Add("Freight");
            dt.Columns.Add("Postal code");
            dt.Columns.Add("Salary");
            dt.Columns.Add("PF");
            dt.Columns.Add("EMI");

            for (int l = 0; l < 100; l++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = name1[r.Next(0, 5)];
                dr[1] = "E" + r.Next(30);
                dr[2] = new DateTime(2012, 5, 23);
                dr[3] = country[r.Next(0, 5)];
                dr[4] = city[r.Next(0, 5)];
                dr[5] = scountry[r.Next(0, 5)];
                dr[6] = "12,789";
                dr[7] = r.Next(10 + (r.Next(600000, 600100)));
                dr[8] = r.Next(14000, 20000);
                dr[9] = r.Next(r.Next(2000, 4000));
                dr[10] = r.Next(300, 1000);

                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

    }
}
