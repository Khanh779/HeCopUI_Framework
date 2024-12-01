using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Chart
{
    /// <summary>
    /// Line Chart Control
    /// Note:
    /// 1. The data column must be at least 2 columns.
    /// 2, the data column and the data title column length must be consistent
    /// 3, the maximum length of the data title is 100
    /// 4, the number of polylines cannot be greater than 10
    /// </summary>

    /*
            List<string> name = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August" };
            List<int> data = new List<int> { 1150, 250, 1550, 1600, 1800, 900, 2500, 1700 };
            List<int> data1 = new List<int> { 1250, 2250, 3550, 1600, 800, 900, 500, 2700 };
            List<int> data2 = new List<int> { 2150, 250, 1550, 1600, 1700, 900, 200, 1700 };
            FoldLineDataStyle fld = new FoldLineDataStyle(data);    //default format

            FoldLineDataStyle fld1 = new FoldLineDataStyle(data1);
            fld1.DataName = "Test Data 1";
            fld1.FoldLineColor = Color.Green;
            fld1.FoldLineDataColor = Color.Green;

            FoldLineDataStyle fld2 = new FoldLineDataStyle(data2);
            //fld2.DataName = "test data 1";
            fld2.FoldLineColor = Color.Blue;
            fld2.FoldLineDataColor = Color.Blue;

            FoldLineData foldLineData = new FoldLineData(new List<FoldLineDataStyle> { fld, fld1, fld2 }, name);
            foldLineData.ShowLegend = true;
            foldLineData.FoldLineText = "Test Line Chart";
            this.foldLineDiagram1.ShowFoldLineDiagram(foldLineData);
    */

    [ToolboxItem(true)]
    #region LinesChart

    public partial class FoldLineDiagram : Control
    {

        private Bitmap mImage;              //Draw a line chart

        private FoldLineData mData;         // Record the polyline data, can be recalculated when the window size changes

        private List<SelectionArea> mSelectionArea = new List<SelectionArea>();     // Select the area[useless here, used to record data points, to determine whether the cursor is selected a data line]





        public FoldLineDiagram()
        {
            SetStyle(HeCopUI_Framework.GetAppResources.SetControlStyles(), true);
            titleText = Name;
            DoubleBuffered = true;

        }

        bool showFolText = true;
        bool showLineText = true;
        bool showData = true;
        private string titleText = "";
        public string TitleText
        {
            get { return titleText; }
            set
            {
                titleText = value; Invalidate();
            }
        }

        private bool showLegend = true;
        public bool ShowLegend
        {
            get { return showLegend; }
            set
            {
                showLegend = value; Invalidate();
            }
        }

        private Series[] _serl;
        public Series[] HSeries
        {
            get { return _serl; }
            set
            {
                _serl = value;

                Invalidate();
            }
        }

        public class Series
        {
            public string Name = "Name";
            public string DataName = "DataName";
            public int DataNumber = 0;
            public Color LineColor = Color.DodgerBlue;
            public Color LineDataColor = Color.DodgerBlue;
        }

        protected override void OnResize(EventArgs e)
        {
            if (mData != null)
            {
                mImage = CreateImageS(mData);
                BackgroundImage = new Bitmap(mImage);      // Background is a copied picture
            }
            Invalidate();
            base.OnResize(e);
        }

        #region Disable base class attribute display


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        #endregion

        /// <summary>
        /// Get a polyline image (only if you use the ShowFoldLineDiagram method to get it correctly)
        /// </summary>
        public Bitmap Image
        {
            get { return mImage; }

        }


        /// <summary>
        /// show polyline
        /// </summary>
        /// <param name="aData">polyline data object</param>
        public void ShowFoldLineDiagram(FoldLineData aData)
        {
            mData = aData;
            mImage = CreateImageS(aData);

            BackgroundImage = new Bitmap(mImage);      // Background is a copied picture
                                                       //this.BackgroundImageLayout = ImageLayout.Stretch; //Stretch display
        }


        /// <summary>
        /// Save the line chart image (can only be saved correctly if the ShowFoldLineDiagram method is used)
        /// </summary>
        /// <param name="aSavePath">Save the path to the file</param>
        /// <param name="aImageFormat">Saved format</param>
        public void SaveImage(string aSavePath, System.Drawing.Imaging.ImageFormat aImageFormat)
        {
            new Bitmap(mImage).Save(aSavePath, aImageFormat);
        }

        private Bitmap CreateImageS(FoldLineData data)
        {

            #region Data Verification
            if (data.DataTitleText.Count <= 1) return null;                     // Limit the number of columns can not be less than 2
            if (data.DataTitleText.Count > 100) return null;                     // Limit the number of columns can not be greater than 100
            if (data.listFoldLineDataStyle.Count > 10) return null;             // Limit the number of polylines can not be greater than 10
            int temp = data.DataTitleText.Count;                                // Get the length of the data title
            for (int i = 0; i < data.listFoldLineDataStyle.Count; i++)          // Loop all data
            {
                if (data.listFoldLineDataStyle[i].Data.Count != temp)            //The current data length does not match the data header length
                {
                    return null;
                }
            }
            #endregion

            #region function internal variable assignment

            mSelectionArea.Clear();                            // Record data clear



            int height = Height, width = Width;                      // Set the image size

            // Set the left and right borders from the picture frame spacing
            int left = (int)(width * 0.1);
            int right = (int)(width * 0.1);
            int top = (int)(height * 0.1);
            int bottom;
            if (data.ShowLegend == true) bottom = (int)(height * 0.15);          // When displaying the legend, the bottom border is 0.2
            else bottom = (int)(height * 0.1);



            #endregion

            Bitmap image = new Bitmap(width, height);           // Create a new picture
            Graphics g = Graphics.FromImage(image);
            g.SmoothingMode = SmoothingMode.AntiAlias;  // Make the highest quality drawing, that is, anti - aliasing
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            try
            {
                #region Drawing preparation

                g.Clear(Color.White);                           // Clear the background color of the picture

                Font font = data.DataTitleTextFont;         // Set the X and Y axis title font
                Font font1 = data.FoldLineTextFont;        // Set the title font
                                                           //Font font2 = aLineDataFont; //Set the data display font
                LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, image.Width, image.Height), data.BackgroundBorderColor, data.BackgroundBorderColor, 1.2f, true);
                g.FillRectangle(Brushes.AliceBlue, 0, 0, width, height);
                #endregion


                #region Draw a line chart title
                Brush brush1 = new SolidBrush(data.FoldLineTextColor);

                SizeF sizeF = g.MeasureString(data.FoldLineText, font1);             // Calculate the title text size
                if (showFolText == true)
                    g.DrawString(data.FoldLineText, font1, brush1, (width - sizeF.Width) / 2, (top - sizeF.Height) / 2);             //Draw a title

                #endregion

                #region Draw a frame line

                // draw the border line of the picture
                g.DrawRectangle(new Pen(data.BackgroundBorderColor), 0, 0, image.Width - 1, image.Height - 1);

                Pen mypen = new Pen(brush, 1);              //Border line brush



                // draw vertical lines
                int xLineSpacing = (width - left - right) / (data.DataTitleText.Count - 1);            // Calculate the X axis line spacing
                int xPosition = left;                                               //X axis start position
                for (int i = 0; i < data.DataTitleText.Count; i++)
                {
                    g.DrawLine(mypen, xPosition, top, xPosition, height - bottom);                   // draw X axis vertical line

                    sizeF = g.MeasureString(data.DataTitleText[i], font);   // Calculate the X-axis text size
                    if (showData == true)
                        g.DrawString(data.DataTitleText[i], font, new SolidBrush(data.DataTitleTextColor), xPosition - (sizeF.Width / 2), height - bottom + 5); // Set the text content and output location

                    xPosition += +xLineSpacing;        // Accumulated spacing
                }
                //Pen mypen1 = new Pen(Color.Blue, 3);
                xPosition = left;
                g.DrawLine(mypen, xPosition, top, xPosition, height - bottom);                                   // draw the first line of the X axis(thick line)

                // draw horizontal lines
                List<int> yName = ReckonYLine(data.listFoldLineDataStyle);
                int mLineCount = yName.Count;                                    // Calculate the number of Y-axis lines
                int yLineSpacing = (height - bottom - top) / (yName.Count - 1);           // Calculate the Y axis line spacing
                int yPosition = height - bottom;                                                //Y axis start point

                for (int i = 0; i < yName.Count; i++)
                {
                    g.DrawLine(mypen, left, yPosition, width - right, yPosition);

                    sizeF = g.MeasureString(yName[i].ToString(), font);
                    g.DrawString(yName[i].ToString(), font, new SolidBrush(data.DataTitleTextColor), left - sizeF.Width - 5, yPosition - (sizeF.Height / 2)); // Set the text content and output location

                    yPosition -= yLineSpacing;
                }
                yPosition = height - bottom;
                g.DrawLine(mypen, left, yPosition, width - right, yPosition);      //The lowermost antenna of the Y axis is bold
                #endregion

                #region Draw a line, and data

                for (int i = 0; i < data.listFoldLineDataStyle.Count; i++)
                {
                    // Show the polyline effect
                    Pen mypen2 = new Pen(data.listFoldLineDataStyle[i].FoldLineColor, 2);         // line brush
                    List<int> pointData = data.listFoldLineDataStyle[i].Data;                       // Take out the polyline data

                    xPosition = left;
                    float yMultiple = (height - top - bottom) / (float)yName.Max();            // Calculate the Y-axis scale factor

                    List<Point> linePoint = new List<Point>();                      // Define the polyline node coordinates
                    for (int j = 0; j < pointData.Count; j++)
                    {
                        Point point = new Point
                        {
                            X = xPosition,
                            Y = top + (int)((yName.Max() - pointData[j]) * yMultiple)
                        };
                        xPosition += xLineSpacing;
                        linePoint.Add(point);
                        g.FillEllipse(new SolidBrush(data.listFoldLineDataStyle[i].FoldLineColor), point.X - 5, point.Y - 5, 10, 10);           // draw the dot of the node
                        if (showLineText == true)
                            g.DrawString(pointData[j].ToString(), data.listFoldLineDataStyle[i].FoldLineDataFont, new SolidBrush(data.listFoldLineDataStyle[i].FoldLineDataColor), point.X, point.Y + 10);       // draw node text
                    }

                    g.DrawLines(mypen2, linePoint.ToArray()); // draw a polyline

                    // Record the drawing area
                    SelectionArea sa = new SelectionArea
                    {
                        linePoint = linePoint
                    };
                    //sa.rect = new Rectangle();
                    mSelectionArea.Add(sa);

                }


                #endregion

                #region  

                if (data.ShowLegend == true)
                {


                    int length = 0;         //Draw the length
                    for (int i = 0; i < data.listFoldLineDataStyle.Count; i++)
                    {
                        // Show the polyline effect
                        Pen mypen2 = new Pen(data.listFoldLineDataStyle[i].FoldLineColor, 2);         // line brush
                        if (data.listFoldLineDataStyle[i].DataName == "polyline")
                        {
                            data.listFoldLineDataStyle[i].DataName += i.ToString(); // If it is the default name, add the number to the default name
                        }
                        sizeF = g.MeasureString(data.listFoldLineDataStyle[i].DataName, data.DataTitleTextFont);       // Calculate the font length
                                                                                                                       //20: the spacing between the two legends, 30: the color in the legend indicates the width of the area, 10: the distance between the color area of ​​the legend and the text area
                        length += 20 + 30 + 10 + (int)sizeF.Width;

                    }
                    length += 20;   //plus the final spacing


                    int startX = (width - length) / 2;
                    int startY = (int)(height * 0.92);
                    for (int i = 0; i < data.listFoldLineDataStyle.Count; i++)
                    {
                        // Show the polyline effect
                        Pen mypen2 = new Pen(data.listFoldLineDataStyle[i].FoldLineColor, 2);         // line brush
                        if (data.listFoldLineDataStyle[i].DataName == "polyline")
                        {
                            data.listFoldLineDataStyle[i].DataName += i.ToString(); // If it is the default name, add the number to the default name
                        }
                        sizeF = g.MeasureString(data.listFoldLineDataStyle[i].DataName, data.DataTitleTextFont);       // Calculate the font length

                        g.FillRectangle(new SolidBrush(data.listFoldLineDataStyle[i].FoldLineColor), startX, startY, 30, 10); // draw a small rectangle
                        g.DrawString(data.listFoldLineDataStyle[i].DataName, data.DataTitleTextFont, new SolidBrush(data.listFoldLineDataStyle[i].FoldLineColor), startX + 30 + 10, startY);
                        startX += 30 + 10 + (int)sizeF.Width + 20;


                        // Record the drawing area of ​​the drawing area
                        Rectangle rect = new Rectangle(startX, startY, 30, 10);
                        SelectionArea sa = mSelectionArea[i];
                        sa.rect = rect;
                        mSelectionArea[i] = sa;
                    }
                }



                #endregion
                return new Bitmap(image);
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }

        }



        /// <summary>
        /// Y-axis horizontal line and Y-axis title as calculated 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private List<int> ReckonYLine(List<FoldLineDataStyle> flData)
        {
            List<int> AllData = new List<int>();        //All data is put together 
            foreach (FoldLineDataStyle item in flData)
            {
                AllData.AddRange(item.Data);
            }

            // Define the maximum and minimum
            int max = AllData.Max();
            int min = AllData.Min();
            List<int> yName = new List<int>();

            int csMax = 0;       // Estimate the upper limit

            if (max.ToString().Length > 1)        //If it is greater than 9
            {
                // Calculate the maximum upper limit
                string ling = "";
                for (int i = 0; i < max.ToString().Length - 1; i++)                    // fill the end of the number 0
                    ling += "0";

                string temp = max.ToString().Substring(0, 1);           // remove the highest digit
                csMax = Int32.Parse((Int32.Parse(temp) + 1) + ling);   // If max = 75162 then converted to 80000

                for (int i = 0; i <= (Int32.Parse(temp) + 1); i++)
                {
                    yName.Add((Int32.Parse(i + ling)));
                }
            }
            else
            {
                csMax = max + 1;
                for (int i = 0; i <= csMax; i++)
                {
                    yName.Add(i);
                }
            }

            return yName;
        }


        /// <summary>
        /// select area
        /// </summary>
        private struct SelectionArea
        {
            /// <summary>
            /// select area
            /// </summary>
            public Rectangle rect;

            /// <summary>
            /// Polyline area
            /// </summary>
            public List<Point> linePoint;

        }


        /// <summary>
        /// Determine if the point is within the rectangle
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static bool IsPointIn(RectangleF rect, PointF pt)
        {
            if (pt.X >= rect.X && pt.Y >= rect.Y && pt.X <= rect.X + rect.Width && pt.Y <= rect.Y + rect.Height)
            {
                return true;
            }
            else return false;
        }

    }


    /// <summary>
    /// Polyline background setting
    /// </summary>
    public class FoldLineData
    {
        /// <summary>
        /// All polylines Default: null data
        /// </summary>
        public List<FoldLineDataStyle> listFoldLineDataStyle;

        /// <summary>
        /// Title text of the line chart Default: Empty text
        /// </summary>
        public List<string> DataTitleText;

        /// <summary>
        /// Title text of the line chart Default: Empty text
        /// </summary>
        public string FoldLineText;

        /// <summary>
        /// Title text of the line chart Font color Default: Black
        /// </summary>
        public Color FoldLineTextColor;

        /// <summary>
        /// Title text of the line chart Font format Default: " ", 20
        /// </summary>
        public Font FoldLineTextFont;

        /// <summary>
        /// Data column header Font color Default: Black
        /// </summary>
        public Color DataTitleTextColor;

        /// <summary>
        /// Data column header Font format Default: " ", 9
        /// </summary>
        public Font DataTitleTextFont;

        /// <summary>
        /// Background border line Color Default: Dark gray
        /// </summary>
        public Color BackgroundBorderColor;

        /// <summary>
        /// Show legend Default: true
        /// </summary>
        public bool ShowLegend;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="flds">Datagroup. The data length of each group must be consistent and consistent with the length of the data column name</param>
        /// <param name="dataTitleText">data column name</param>
        public FoldLineData(List<FoldLineDataStyle> flds, List<string> dataTitleText)
        {

            DataTitleText = dataTitleText;
            listFoldLineDataStyle = flds;
            FoldLineText = "";
            FoldLineTextColor = Color.Black;
            FoldLineTextFont = new System.Drawing.Font("Song body", 20, FontStyle.Regular);
            DataTitleTextColor = Color.Black;
            DataTitleTextFont = new System.Drawing.Font("Arial", 9, FontStyle.Regular);
            BackgroundBorderColor = Color.DarkGray;
            ShowLegend = true;

        }

    }


    /// <summary>
    /// Polyline data and style
    /// </summary>
    public class FoldLineDataStyle
    {

        /// <summary>
        /// Polyline data Default: null
        /// </summary>
        public List<int> Data;

        /// <summary>
        /// Polyline data name Default: Polyline
        /// </summary>
        public string DataName;

        /// <summary>
        /// Polyline color Default: Red
        /// </summary>
        public Color FoldLineColor;

        /// <summary>
        /// The color of the data displayed on the polyline point Default: Red
        /// </summary>
        public Color FoldLineDataColor;

        /// <summary>
        /// The data font format displayed on the polyline point Default: " ", 8
        /// </summary>
        public Font FoldLineDataFont;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">Data. The data length must be consistent </param>
        public FoldLineDataStyle(List<int> data)
        {
            Data = data;
            FoldLineColor = Color.Red;
            FoldLineDataColor = Color.Red;
            FoldLineDataFont = new System.Drawing.Font("Song body", 9, FontStyle.Regular);
            DataName = "polyline";

        }

    }
    #endregion
}

