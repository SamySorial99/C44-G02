namespace C44_G02_OOP_5
{
    using System;

    // Base interface
    public interface IShape
    {
        double Area { get; }
        void DisplayShapeInfo();
    }

    // Derived interface for Circle
    public interface ICircle : IShape
    {
        double Radius { get; }
    }

    // Derived interface for Rectangle
    public interface IRectangle : IShape
    {
        double Width { get; }
        double Height { get; }
    }

    // Circle class implementing ICircle
    public class Circle : ICircle
    {
        public double Radius { get; private set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Area
        {
            get { return Math.PI * Radius * Radius; }
        }

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Shape: Circle");
            Console.WriteLine($"Radius: {Radius}");
            Console.WriteLine($"Area: {Area:F2}");
        }
    }

    // Rectangle class implementing IRectangle
    public class Rectangle : IRectangle
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Area
        {
            get { return Width * Height; }
        }

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Shape: Rectangle");
            Console.WriteLine($"Width: {Width}, Height: {Height}");
            Console.WriteLine($"Area: {Area:F2}");
        }
    }

    // Test Program
    class Program
    {
        static void Main()
        {
            // question 1
            ICircle circle = new Circle(5);
            IRectangle rectangle = new Rectangle(4, 6);

            circle.DisplayShapeInfo();
            Console.WriteLine();
            rectangle.DisplayShapeInfo();



            // question 2
            IAuthenticationService authService = new BasicAuthenticationService();

            // Authenticate
            bool isAliceAuth = authService.AuthenticateUser("alice", "pass123");
            bool isBobAuth = authService.AuthenticateUser("bob", "wrong"); // should be false

            Console.WriteLine($"Alice authenticated: {isAliceAuth}");
            Console.WriteLine($"Bob authenticated:   {isBobAuth}");

            // Authorize
            bool aliceIsAdmin = authService.AuthorizeUser("alice", "Admin"); // true
            bool bobIsAdmin = authService.AuthorizeUser("bob", "Admin");   // false

            Console.WriteLine($"Alice is Admin: {aliceIsAdmin}");
            Console.WriteLine($"Bob is Admin:   {bobIsAdmin}");



            // question 3
            INotificationService email = new EmailNotificationService();
            INotificationService sms = new SmsNotificationService();
            INotificationService push = new PushNotificationService();

            email.SendNotification("alice@example.com", "Welcome to our platform!");
            sms.SendNotification("+20111222333", "Your OTP is 926314");
            push.SendNotification("user-42", "You have a new message");

        }
    }
}
