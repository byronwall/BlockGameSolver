using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using BlockGameSolver.ImageAnalyzer.Core;
using BlockGameSolver.ImageAnalyzer.Utility;

namespace BlockGameSolver.ImageAnalyzer.Core
{
    public class ImageSettings
    {
        private readonly List<AnchorPoint> anchorData = new List<AnchorPoint>();
        private readonly List<ColorPoint> colorData = new List<ColorPoint>();

        public Bitmap FullImage { get; set; }
        public int ThumbnailHeight { get; set; }
        public Point ThumbnailCorner { get; set; }
        public int ThumbnailWidth { get; set; }
        public Point ColorOffset { get; set; }

        public Bitmap ThumbnailImage
        {
            get { return BitmapUtility.CropBitmap(FullImage, ThumbnailCorner.X, ThumbnailCorner.Y, ThumbnailWidth, ThumbnailHeight); }
        }

        public int PieceWidth { get; set; }
        public int PieceHeight { get; set; }

        public Bitmap PieceThumbnail
        {
            get { return BitmapUtility.CropBitmap(FullImage, PieceCorner.X, PieceCorner.Y, PieceWidth, PieceHeight); }
        }

        public Point PieceCorner { get; set; }
        public int Cols { get; set; }

        public int Rows { get; set; }

        public int Colors { get; set; }

        private Point PieceOffset
        {
            get { return new Point(PieceCorner.X - ThumbnailCorner.X, PieceCorner.Y - ThumbnailCorner.Y); }

            set { PieceCorner = new Point(ThumbnailCorner.X + value.X, ThumbnailCorner.Y + value.Y); }
        }

        public Point DoubleOffset { get; set; }
        public int BombColor { get; set; }

        public List<ColorPoint> ColorData
        {
            get { return colorData; }
        }

        public List<AnchorPoint> AnchorData
        {
            get { return anchorData; }
        }

        public IEnumerable<Point> GetPieceLocations()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    yield return new Point(PieceCorner.X + PieceWidth * j, PieceCorner.Y + PieceHeight * i);
                }
            }
        }

        private IEnumerable<AnchorPoint> GetAnchorData()
        {
            anchorData.Clear();
            for (int i = 0; i < ThumbnailWidth; i++)
            {
                for (int j = 0; j < ThumbnailHeight; j++)
                {
                    anchorData.Add(new AnchorPoint(i, j, FullImage.GetPixel(i + ThumbnailCorner.X, j + ThumbnailCorner.Y).ToArgb()));
                }
            }
            return anchorData;
        }

        public List<ColorPoint> AddColorsUnique()
        {
            IEnumerable<int> colorPoints = ColorData.Select(c => c.ImageColor);

            foreach (Point point in GetPieceLocations())
            {
                int color = FullImage.GetPixel(point.X + ColorOffset.X, point.Y + ColorOffset.Y).ToArgb();
                if (!colorPoints.Contains(color))
                {
                    ColorData.Add(new ColorPoint(color) { Source = "Color" });
                }
                int doubleColor = FullImage.GetPixel(point.X + DoubleOffset.X, point.Y + DoubleOffset.Y).ToArgb();
                if (!colorPoints.Contains(doubleColor))
                {
                    ColorData.Add(new ColorPoint(doubleColor) { Source = "Double" });
                }
            }

            return ColorData;
        }

        public void SaveDataToXML()
        {
            XDocument settings = new XDocument();
            XElement root = new XElement("settings");

            settings.Add(root);

            XElement anchorSettings = new XElement("anchorSettings", from anchorPoint in GetAnchorData() select new XElement("point", new XAttribute("xOffset", anchorPoint.XOffset), new XAttribute("yOffset", anchorPoint.YOffset), new XAttribute("color", anchorPoint.Color)));
            root.Add(anchorSettings);

            XElement pieceSettings = new XElement("pieceSettings");
            pieceSettings.Add(new XElement("initialOffset", new XAttribute("xOffset", PieceOffset.X), new XAttribute("yOffset", PieceOffset.Y)));
            pieceSettings.Add(new XElement("size", new XAttribute("width", PieceWidth), new XAttribute("height", PieceHeight)));

            root.Add(pieceSettings);

            XElement colorSettings = new XElement("colorSettings");

            colorSettings.Add(new XElement("colorOffset", new XAttribute("xOffset", ColorOffset.X), new XAttribute("yOffset", ColorOffset.Y)));
            colorSettings.Add(new XElement("doubleOffset", new XAttribute("xOffset", DoubleOffset.X), new XAttribute("yOffset", DoubleOffset.Y)));
            colorSettings.Add(new XElement("data", from colorPoint in AddColorsUnique() where colorPoint.Name != null select new XElement("colorPoint", new XAttribute("imageColor", colorPoint.ImageColor), new XAttribute("boardColor", colorPoint.BoardColor), new XAttribute("isBomb", colorPoint.IsBomb), new XAttribute("name", colorPoint.Name))));

            root.Add(colorSettings);

            settings.Save("boardData.xml");
        }

        public static ImageSettings LoadDataFromXML(XDocument document)
        {
            ImageSettings imageSettings = new ImageSettings();

            IEnumerable<AnchorPoint> anchorSettings = from points in document.Descendants("anchorSettings").Elements("point") select new AnchorPoint((int)points.Attribute("xOffset"), (int)points.Attribute("yOffset"), (int)points.Attribute("color"));

            imageSettings.anchorData.AddRange(anchorSettings);

            XElement pieceSettings = document.Descendants("pieceSettings").Single();
            XElement initialOffset = pieceSettings.Element("initialOffset");

            imageSettings.PieceOffset = new Point((int)initialOffset.Attribute("xOffset"), (int)initialOffset.Attribute("yOffset"));

            imageSettings.PieceHeight = (int)pieceSettings.Element("size").Attribute("height");
            imageSettings.PieceWidth = (int)pieceSettings.Element("size").Attribute("width");

            XElement colorSettings = document.Descendants("colorSettings").Single();
            XElement colorOffset = colorSettings.Element("colorOffset");
            XElement doubleOffset = colorSettings.Element("doubleOffset");

            imageSettings.ColorOffset = new Point((int)colorOffset.Attribute("xOffset"), (int)colorOffset.Attribute("yOffset"));
            imageSettings.DoubleOffset = new Point((int)doubleOffset.Attribute("xOffset"), (int)doubleOffset.Attribute("yOffset"));

            IEnumerable<ColorPoint> color = from point in colorSettings.Element("data").Elements("colorPoint") select new ColorPoint((int)point.Attribute("imageColor"));

            imageSettings.ColorData.AddRange(color);

            return imageSettings;
        }

        public static ImageSettings LoadDataFromXML(string path)
        {
            return LoadDataFromXML(XDocument.Load(path));
        }
    }
}