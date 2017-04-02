using System;
using System.Collections.Generic;

namespace AsgQuizzes
{
    public class OOShapes
    {
        private List<IShape> shapes;

        public OOShapes()
        {
            //Todo: Use DI
            shapes = new List<IShape>();
        }

        public IEnumerable<IShape> AllShapes
        {
            get { return shapes; }
        }

        public void AddTriangle(double height, double width)
        {
            var t = new Triangle();
            t.Area = (height * width) / 2;
            t.WhatIAm = ShapeType.Triangle.ToString();
            shapes.Add(t);
        }

        public void AddRectangle(double height, double width)
        {
            var r = new Rectangle();
            r.Area = height * width;
            r.WhatIAm = ShapeType.Rectangle.ToString();
            shapes.Add(r);
        }

        public string PrintAll()
        {
            string value = string.Empty;
            foreach (var shape in shapes)
            {
                if (shape.WhatIAm.Equals(ShapeType.Triangle.ToString()))
                {
                    value += "/\\" + shape.Area;
                }
                else if (shape.WhatIAm.Equals(ShapeType.Rectangle.ToString()))
                {
                    value += "||" + shape.Area;
                }
            }
            return value;
        }

    }

    /// <summary>
    /// HINT: You are expected to write classes that implement this interface
    /// </summary>
    public interface IShape
    {
        string WhatIAm { get; }
        double Area { get; }
    }
}