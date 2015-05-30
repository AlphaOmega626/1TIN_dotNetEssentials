using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Complex
    {
        Double real;
        Double imaginary;

        public Complex(Double real, Double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public Double GetReal
        {
            get
            {
                return this.real;
            }
        }

        public Double GetImaginary
        {
            get
            {
                return this.imaginary;
            }
        }

        public Complex AddComplex(Complex tempComlex)
        {
            Double totalReal = this.real + tempComlex.GetReal;
            Double totalImaginary = this.imaginary + tempComlex.GetImaginary;
            Complex totalComplex = new Complex(totalReal, totalImaginary);
            return totalComplex;
        }

        public Complex MultiplyComplex(Complex tempComplex)
        {
            Double totalReal = (this.real * tempComplex.GetReal) - (this.imaginary * tempComplex.GetImaginary);
            Double totalImaginary = (this.real * tempComplex.GetImaginary) + (tempComplex.GetReal * this.imaginary);
            Complex totalComplex = new Complex(totalReal, totalImaginary);
            return totalComplex;
        }
    }
}
