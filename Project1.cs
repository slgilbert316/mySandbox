// System include
using System;

namespace OOADI_Ch_2
{
    public class Product
    {
        // Enumeration for the overall rating, with indexing that does NOT correspond directly
        // to the reliability rating value.  The rating never is zero; 1 is the minimum vlaue.
        public enum Rating
        {
            F,  // 1.0 ... <2.0
            D,  // 2.0 ... >3.0
            C,  // 3.0 ... <4.0
            B,  // 4.0 ... <5.0
            A   // 5.0
        }

        // Instance values which don't change after they are initialized
        public String modelName;
        public String manufacturerName;

        // Survey related values
        private protected double price;
        public double reliability;
        public int customerCount;
        public Rating overallRating;


        // Constructors
        public Product(String model, String manufacturer, double thePrice)
        {
            manufacturerName = manufacturer;
            modelName = model;
            price = thePrice;
            reliability = 1.0;
            customerCount = 0;
            overallRating = Rating.F;
        }

        /*  The following constructor is not implemented in Visual Studio version 16.9.1.
         public Product(String model, String manufacturer)
        {
            this.Product(model, manufacturer, 10);
        }
        */
        public Product(String model, String manufacturer)
        {
            manufacturerName = manufacturer;
            modelName = model;
            price = 10.0;
            reliability = 1.0;
            customerCount = 0;
            overallRating = Rating.F;
        }


        public string GetManufacturer()
        {
            return manufacturerName;
        }

        public string GetModel()
        {
            return modelName;
        }

        public double GetPrice()
        {
            return price;
        }

        public void SetPrice(double thePrice)
        {
            price = thePrice;
        }

        public Rating GetOverallRating()
        {
            return overallRating;
        }

        public void SetOverallRating(Rating rating)
        {
            overallRating = rating;
        }

        public double GetReliability()
        {
            return reliability;
        }

        public void UpdateReliabilityRating(double rating)
        {
            double oldReliability = this.reliability;
            int oldCustomerCount = this.customerCount;

            customerCount++;

            reliability = ((oldReliability * oldCustomerCount) + rating) /
                customerCount;
        }

        public int GetCustomerCount()
        {
            return customerCount;
        }

        public override string ToString()
        {
            string theResult = "Manufacturer "
                               + manufacturerName
                               + ", Model "
                               + modelName
                               + ", Price "
                               + price.ToString("0.00")
                               + ", Reliability "
                               + reliability.ToString("0.00")
                               + ", Overall Rating "
                               + overallRating
                               + ", Customer Count "
                               + customerCount;
            return theResult;
        }
    }

    public class Project1
    {
        public static void Main(/*string[] args*/)
        {
            Product[] theProduct = new Product[3];

            theProduct[0] = new Product("Manufacturer_1", "Model_1", 1.001);
            theProduct[1] = new Product("Manufacturer_2", "Model_2",  2.009);
            theProduct[2] = new Product("Manufacturer_3", "Model_3");

            for (int index = 0; index < theProduct.Length(); index++)
            {
                Console.WriteLine(theProduct[index].ToString());
            }
        }
    }
}