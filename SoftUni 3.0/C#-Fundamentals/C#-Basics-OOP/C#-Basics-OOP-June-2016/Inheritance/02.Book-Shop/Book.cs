using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Shop
{
    public class Book
    {
        #region Fields

        private string author;
        private string title;
        private double price;

        #endregion Fields

        //===========================

        #region Constructors

        public Book(string author, string title, double price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        #endregion Constructors

        //===========================

        #region Properties

        public string Author
        {
            get { return this.author; }
            protected set
            {
                var splittedInput = value
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (splittedInput.Length > 1)
                {
                    if (char.IsDigit(value.Split()[1][0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }

                this.author = value;
            } 
        }

        public string Title
        {
            get { return this.title; }
            protected set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public virtual double Price
        {
            get { return this.price; }
            protected set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        #endregion Properties

        //===========================

        #region Methods

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Type: {this.GetType().Name}")
                    .Append(Environment.NewLine)
                    .Append($"Title: {this.Title}")
                    .Append(Environment.NewLine)
                    .Append("Author: ").Append(this.Author)
                    .Append(Environment.NewLine)
                    .Append($"Price: {this.Price:F1}")
                    .Append(Environment.NewLine);

            return sb.ToString();
        }

        #endregion Methods
    }
}
