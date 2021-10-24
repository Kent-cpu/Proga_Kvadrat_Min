using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using Google.Apis.Sheets.v4;
using Google.Apis.Auth.OAuth2;
using System.IO;
using Google.Apis.Services;
using MathNet.Numerics.LinearAlgebra;
using ZedGraph;
using System.Threading;


namespace Proga_lab_3
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string SpreadsheetId = "1BbjZxzIjTQ1ACC0q3kYqXJl-0RChhXQe_viwL7tF1PI";
        static readonly string sheet = "Data";
        static SheetsService service;


        public Form1()
        {
            InitializeComponent();
        }

        private void disbledBtn(bool enable)
        {
            dataExcelBtn.Enabled = enable;
            calculateBtnN1.Enabled = enable;
            calculateBtnN2.Enabled = enable;
            googleSheetsBtn.Enabled = enable;
        }

        public void drawN2(double a, double b, double c)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();

            PointPairList list = new PointPairList();
            for (int i = 0; i < points.Count; ++i)
            {
                list.Add(points[i].x, points[i].y);
            }
            double minX = findPoint()[0];
            double maxX = findPoint()[1];


            LineItem myCurve = pane.AddCurve("Points", list, Color.Blue, SymbolType.Diamond);
            LineItem approximating = pane.AddCurve("f(x)", new double[] { minX, maxX },
                new double[] { a * minX * minX + b * minX + c, a * maxX * maxX + b * maxX + c }, Color.DarkRed, SymbolType.Circle);

            myCurve.Line.IsVisible = false;

            myCurve.Symbol.Fill.Color = Color.Blue;
            myCurve.Symbol.Fill.Type = FillType.Solid;

            myCurve.Symbol.Size = 7;

            zedGraphControl1.AxisChange();

            zedGraphControl1.Invalidate();
        }

        private void drawN1(double a, double b)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();

            PointPairList list = new PointPairList();
            for (int i = 0; i < points.Count; ++i)
            {
                list.Add(points[i].x, points[i].y);
            }


            LineItem myCurve = pane.AddCurve("Points", list, Color.Blue, SymbolType.Diamond);
            LineItem approximating = pane.AddCurve("f(x)", new double[] { findPoint()[0], findPoint()[1] }, new double[] { a * findPoint()[0] + b, a * findPoint()[1] + b }, Color.DarkRed, SymbolType.Circle);

            myCurve.Line.IsVisible = false;

            myCurve.Symbol.Fill.Color = Color.Blue;
            myCurve.Symbol.Fill.Type = FillType.Solid;

            myCurve.Symbol.Size = 7;

            zedGraphControl1.AxisChange();

            zedGraphControl1.Invalidate();
        }


        private void dataExcel_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                try
                {

                    Invoke((System.Action)(() =>
                    {
                        disbledBtn(false);
                        points.Clear();
                        dataGridView1.Rows.Clear();
                    }));
                    

                    string path = @"C:\Users\rusla\Desktop\Data.xlsx";
                    Excel.Application ObjExcel = new Excel.Application();
                    Workbook ObjWorkBook = ObjExcel.Workbooks.Open(path);
                    Worksheet ObjWorkSheet = (Worksheet)ObjWorkBook.Sheets[1];

                    Range xRange = ObjWorkSheet.UsedRange.Columns[1];
                    Range yRange = ObjWorkSheet.UsedRange.Columns[2];
                    Array xCells = (Array)xRange.Cells.Value2;
                    Array yCells = (Array)yRange.Cells.Value2;

                    string[] xColumn = xCells.OfType<object>().Select(o => o.ToString()).ToArray();
                    string[] yColumn = yCells.OfType<object>().Select(o => o.ToString()).ToArray();

                    for (int i = 0; i < xColumn.Length; ++i)
                    {
                        Invoke((System.Action)(() =>
                        {
                            dataGridView1.Rows.Add(xColumn[i], yColumn[i]);
                        }));
                        
                    }
                    ObjWorkBook.Close();
                    ObjExcel.Quit();

                    Invoke((System.Action)(() =>
                    {
                        disbledBtn(true);
                    }));

                }
                catch (Exception error)
                {
                    MessageBox.Show("Ошибка при считывания данных");
                }
            }).Start();
            

        }

        private void googleSheetsBtn_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    Invoke((System.Action)(() =>
                        {
                            disbledBtn(false);
                            points.Clear();
                            dataGridView1.Rows.Clear();
                        }));

                    GoogleCredential credential;
                    using (var stream = new FileStream("creds.json", FileMode.Open, FileAccess.Read))
                    {
                        credential = GoogleCredential.FromStream(stream)
                            .CreateScoped(Scopes);
                    }

                    service = new SheetsService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                    });

                    var range = $"Point!A:B";
                    SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

                    var response = request.Execute();
                    IList<IList<object>> values = response.Values;

                    if (values != null && values.Count > 0)
                    {
                        foreach (var row in values)
                        {
                            Invoke((System.Action)(() =>
                            {
                                dataGridView1.Rows.Add(row[0], row[1]);
                            }));
                        }
                    }

                    Invoke((System.Action)(() =>
                    {
                        disbledBtn(true);
                    }));


                }
                catch (Exception error)
                {
                    MessageBox.Show("Ошибка при считывания данных");
                }
            }).Start();
        }


        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void calculateBtnN2_Click(object sender, EventArgs e)
        {

            try
            {
                points.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    Point point = new Point(Convert.ToDouble(dataGridView1[0, i].Value), Convert.ToDouble(dataGridView1[1, i].Value));
                    points.Add(point);
                }

                if (points.Count > 0)
                {
                    double XiPow4 = 0, XiPow3 = 0, XiPow2 = 0, Xi = 0, XiMultiYi = 0, XiPow2MultiYi = 0, Yi = 0, n = points.Count;

                    for (int i = 0; i < points.Count; ++i)
                    {
                        XiPow4 += Math.Pow(points[i].x, 4);
                        XiPow3 += Math.Pow(points[i].x, 3);
                        XiPow2 += Math.Pow(points[i].x, 2);
                        XiMultiYi += points[i].x * points[i].y;
                        XiPow2MultiYi += Math.Pow(points[i].x, 2) * points[i].y;
                        Xi += points[i].x;
                        Yi += points[i].y;
                    }

                    Matrix<double> A = Matrix<double>.Build.DenseOfArray(new double[,] {
                        { XiPow4, XiPow3, XiPow2},
                        { XiPow3, XiPow2, Xi },
                        { XiPow2, Xi, n},
                    });

                    try
                    {
                        Vector<double> B = Vector<double>.Build.Dense(new double[] { XiPow2MultiYi, XiMultiYi, Yi });
                        var result = A.SolveIterative(B, new MathNet.Numerics.LinearAlgebra.Double.Solvers.MlkBiCgStab());
                        answerField.Text = "a: " + Math.Round(result[0], 2).ToString() + " b: " + Math.Round(result[1], 2).ToString() + " c:" + Math.Round(result[2], 2).ToString();
                        drawN2(Math.Round(result[0], 2), Math.Round(result[1], 2), Math.Round(result[2], 2)); 
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Ошибка в вычисления");
                        answerField.Text = null;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Ведите данные");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Ошибки в вычислениях");
            }
        }

        private void calculateBtnN1_Click_1(object sender, EventArgs e)
        {
           
            try
            {
                points.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; ++i)
                {
                    Point point = new Point(Convert.ToDouble(dataGridView1[0, i].Value), Convert.ToDouble(dataGridView1[1, i].Value));
                    points.Add(point);
                }
                if (points.Count > 0)
                {
                    double XiPow2 = 0, Xi = 0, XiMultiYi = 0, Yi = 0, n = points.Count;
                    for (int i = 0; i < points.Count; ++i)
                    {
                        XiPow2 += Math.Pow(points[i].x, 2);
                        Xi += points[i].x;
                        XiMultiYi += points[i].x * points[i].y;
                        Yi += points[i].y;
                    }

                    Matrix<double> A = Matrix<double>.Build.DenseOfArray(new double[,] {
                    { XiPow2, Xi},
                    { Xi, n },
                });

                    Vector<double> B = Vector<double>.Build.Dense(new double[] { XiMultiYi, Yi });

                    var result = A.SolveIterative(B, new MathNet.Numerics.LinearAlgebra.Double.Solvers.MlkBiCgStab());
                    answerField.Text = "a: " + Math.Round(result[0], 2).ToString() + " b: " + Math.Round(result[1], 2).ToString();

                    drawN1(Math.Round(result[0], 2), Math.Round(result[1], 2));
                }
                else
                {
                    MessageBox.Show("Ведите данные");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Ошибки в вычислениях");
            }


        }

        private double[] findPoint()
        {
            double minElement = points[0].x;
            double maxElement = points[0].x;
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].x < minElement)
                {
                    minElement = points[i].x;
                }
                else if (maxElement < points[i].x)
                {
                    maxElement = points[i].x;
                }
            }
            double[] result = { minElement, maxElement };
            return result;
        }
    }
}


class Point
{
    public double x, y;

    public Point()
    {

    }

    public Point(double xKoordinate, double yKoordinate)
    {
        x = xKoordinate;
        y = yKoordinate;
    }
}

