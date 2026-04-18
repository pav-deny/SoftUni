namespace ClassBoxData.Models
{
    public class Box
    {
        private const string PropertyValueExceptionMessage = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Length)));

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Width)));

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Height)));

                this.height = value;
            }
        }


        public double SurfaceArea()
        {
            return 2 * this.Width * this.Length + LateralSurfaceArea();
        }

        public double LateralSurfaceArea()
        {
            return 2 * this.Length * Height + 2 * this.Width * this.Height;
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
