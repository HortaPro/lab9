using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

//Миронова Анастасия 22-ИСП-2/1 вариант 4
namespace lab9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeCanvas();
        }

        private void InitializeCanvas()
        {
            DrawBody(Brushes.Sienna, Brushes.SaddleBrown, 1);
            DrawNet();
            DrawHands(Brushes.Sienna, Brushes.SaddleBrown, 1);
            DrawLegs(Brushes.Sienna, Brushes.SaddleBrown, 1);

            DrawHead(
                Brushes.Sienna, Brushes.SaddleBrown, 1,
                Brushes.Chocolate, null, null
            );
            DrawEars(Brushes.Sienna, Brushes.SaddleBrown, 1, Brushes.Chocolate);

            DrawEyes(Brushes.White, Brushes.Sienna, 1, null);

            // Рисуем Носик
            DrawEllipse(6, 13, 253, 130, Brushes.Sienna, Brushes.SaddleBrown, 3);
        }

        private void DrawNet()
        {
            Line line = new Line
            {
                X1 = 70,
                X2 = 110,
                Y1 = 160,
                Y2 = 70,
                Stroke = Brushes.Black,
                StrokeThickness = 4,
                RenderTransform = new TranslateTransform(
                    285, 100
                )
            };

            Polygon polygon = new Polygon
            {
                Points = new PointCollection(new[]
                {
                    new Point(393, 170),
                    new Point(447, 170),
                    new Point(430, 240)
                }),
                Fill = Brushes.Black
            };


            Canvas.Children.Add(polygon);
            DrawEllipse(30, 60, 420, 170, Brushes.Black, Brushes.White, 3);
            Canvas.Children.Add(line);
        }

        private void DrawEars(
            Brush skinBackgroundColor,
            Brush? skinBorderColor,
            double? skinBorderThickness,
            Brush? earBackgroundColor
        )
        {
            DrawEar(166, 125, skinBackgroundColor, skinBorderColor, skinBorderThickness, earBackgroundColor);
            DrawEar(334, 125, skinBackgroundColor, skinBorderColor, skinBorderThickness, earBackgroundColor);
        }

        private void DrawEar(
            double positionX,
            double positionY,
            Brush skinBackgroundColor,
            Brush? skinBorderColor,
            double? skinBorderThickness,
            Brush? earBackgroundColor
        )
        {
            DrawEllipse(120, 60, positionX, positionY, skinBackgroundColor, skinBorderColor, skinBorderThickness);
            DrawEllipse(60, 40, positionX, positionY, earBackgroundColor ?? Brushes.Chocolate, null, null);
        }

        private void DrawEyes(
            Brush backgroundColor,
            Brush? borderColor,
            double? borderThickness,
            Brush? eyeballBackgroundColor
        )
        {
            DrawEye(232, 115, backgroundColor, borderColor, borderThickness, eyeballBackgroundColor);
            DrawEye(268, 115, backgroundColor, borderColor, borderThickness, eyeballBackgroundColor);
        }

        private void DrawEye(
            double positionX,
            double positionY,
            Brush backgroundColor,
            Brush? borderColor,
            double? borderThickness,
            Brush? eyeballBackgroundColor
        )
        {
            DrawEllipse(23, 20, positionX, positionY, backgroundColor, borderColor, borderThickness);
            DrawEllipse(10, 10, positionX + 1, positionY, eyeballBackgroundColor ?? Brushes.Black, null, null);
        }

        private void DrawHead(
            Brush headBackgroundColor,
            Brush? headBorderColor,
            double? headBorderThickness,
            Brush faceBackgroundColor,
            Brush? faceBorderColor,
            double? faceBorderThickness
        )
        {
            DrawEllipse(95, 110, 250, 125, headBackgroundColor, headBorderColor, headBorderThickness);
            DrawEllipse(75, 90, 250, 125, faceBackgroundColor, faceBorderColor, faceBorderThickness);
        }

        private void DrawLegs(
            Brush backgroundColor,
            Brush? borderColor,
            double? borderThickness
        )
        {
            DrawEllipse(25, 70, 195, 325, backgroundColor, borderColor, borderThickness);
            DrawEllipse(25, 70, 305, 325, backgroundColor, borderColor, borderThickness);
        }

        private void DrawHands(
            Brush backgroundColor,
            Brush? borderColor,
            double? borderThickness
        )
        {
            DrawEllipse(30, 90, 160, 225, backgroundColor, borderColor, borderThickness);
            DrawEllipse(30, 90, 340, 225, backgroundColor, borderColor, borderThickness);
        }

        private void DrawBody(
            Brush backgroundColor,
            Brush? borderColor,
            double? borderThickness
        )
        {
            DrawEllipse(160, 100,
                250, 250,
                backgroundColor, borderColor, borderThickness
            );
        }

        private void DrawEllipse(
            double height,
            double width,
            double positionX,
            double positionY,
            Brush backgroundColor,
            Brush? borderColor,
            double? borderThickness
        )
        {
            TranslateTransform position = new TranslateTransform(
                positionX - width / 2,
                positionY - height / 2
            );

            Ellipse ellipse = new Ellipse
            {
                Height = height,
                Width = width,
                StrokeThickness = borderThickness ?? 0,
                Stroke = borderColor,
                Fill = backgroundColor,
                RenderTransform = position,
            };

            Canvas.Children.Add(ellipse);
        }
    }
}

