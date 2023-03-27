namespace GC3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            problema1(e);
        }

        private void problema1(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red);
            Pen linePen = new Pen(Color.Red, 1);
            Random rnd = new Random();

            int n = 50;
            PointF[] points = new PointF[n];

            float raza_m = 5;
            int i, j;
            for (i = 0; i < n; i++)
            {
                points[i].X = rnd.Next(50, this.ClientSize.Width - 50);
                points[i].Y = rnd.Next(50, this.ClientSize.Height - 50);
                g.DrawEllipse(p, points[i].X - raza_m, points[i].Y - raza_m, raza_m * 2, raza_m * 2);
            }
            bool sorted;
            do
            {
                sorted = true;
                for (i = 0; i < points.Length - 1; i++)
                {
                    if (points[i].X > points[i + 1].X)
                    {
                        (points[i], points[i + 1]) = (points[i + 1], points[i]);
                        sorted = false;
                    }
                }
            }
            while (!sorted);

            bool[] used = new bool[points.Length];

            int pozA = new int();
            int pozB = new int();

            i = 0;
            while (i < points.Length - 1)
            {
                j = i + 1;
                int min = this.ClientSize.Width;

                while (j < points.Length)
                {
                    if (!(used[i] || used[j]))
                    {
                        int distance = (int)Math.Sqrt(Math.Pow(points[i].X - points[j].X, 2) + Math.Pow(points[i].Y - points[j].Y, 2));

                        if (distance < min)
                        {
                            min = distance;
                            pozA = i;
                            pozB = j;
                        }
                    }
                    j++;
                }
                g.DrawLine(linePen, points[pozA], points[pozB]);
                used[pozA] = true;
                used[pozB] = true;
                i++;
            }
        }
    }
}