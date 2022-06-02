using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DividingPolynoms
{
    class Polynom
    {
        private List<int> degrees;
        public string infoCalculations;
        public List<int> resultPolynom;

        public Polynom()
        {
            degrees = new List<int>();
        }

        public Polynom(string polynom)
        {
            degrees = new List<int>();
            writeDegrees(polynom);
        }

        private void writeDegrees(string polynom)
        {
            string[] stringMembers = polynom.Split("+");
            foreach(string member in stringMembers)
            {
                if(member.Length == 1 && member == "x")
                {
                    degrees.Add(1);
                }
                else if(member.Length == 1 && member != "x")
                {
                    degrees.Add(0);
                }
                else
                {
                    degrees.Add(Convert.ToInt32(member.Substring(1)));
                }
            }

        }

        public Polynom[] divideBy(Polynom polynom)
        {
            Polynom tempPolynom = new Polynom();
            Polynom resultPolynom = new Polynom();
            tempPolynom.degrees = this.degrees;
            StringBuilder resultString = new StringBuilder();
            //find difference between two polynoms
            int differance = tempPolynom.degrees[0] - polynom.degrees[0];
            while (differance >= 0)
            {
                resultPolynom.degrees.Add(differance);
                SortPolynom(tempPolynom);
                resultString.Append(tempPolynom + "\n");

                //multiply second polynom by difference
                Polynom multipliedPolynom = multiplyPolynom(polynom, differance);
                resultString.Append(multipliedPolynom + "\n--------------\n");

                //substract polynoms
                Polynom substractedPolynom = substractPolynom(tempPolynom, multipliedPolynom);
                tempPolynom.degrees = substractedPolynom.degrees;


                //find difference between two polynoms
                if (tempPolynom.degrees.Count != 0)
                {
                    differance = tempPolynom.degrees[0] - polynom.degrees[0];
                }
                else
                {
                    tempPolynom.degrees.Add(-1);
                    differance = -1;
                }
            }

            tempPolynom.infoCalculations = resultString.ToString();
            SortPolynom(tempPolynom);
            Polynom[] polynoms = { resultPolynom, tempPolynom };
            return polynoms;
        }

        public Polynom multiplyPolynom(Polynom polynom, int difference)
        {
            Polynom resultPolynom = new Polynom();
            SortPolynom(polynom);
            for(int i = 0; i < polynom.degrees.Count; i++)
            {
                if(polynom.degrees[i] == 0)
                {
                    resultPolynom.degrees.Add(difference);
                }
                else
                {
                    resultPolynom.degrees.Add(polynom.degrees[i] + difference);
                }
            }
            SortPolynom(resultPolynom);
            return resultPolynom;
        }

        public Polynom substractPolynom(Polynom polynom1, Polynom polynom2)
        {
            Polynom resultPolynom = new Polynom();
            resultPolynom.degrees = polynom1.degrees.Concat(polynom2.degrees).ToList();

            int i = 0;
            while(i < resultPolynom.degrees.Count)
            {
                int j = i+1;
                while(j < resultPolynom.degrees.Count)
                {
                    if(resultPolynom.degrees[i] == resultPolynom.degrees[j])
                    {
                        resultPolynom.degrees.RemoveAt(i);
                        resultPolynom.degrees.RemoveAt(j-1);
                        i = -1;
                        break;
                    }
                    j++;
                }
                i++;
            }
            SortPolynom(resultPolynom);
            return resultPolynom;
        }

        public override string ToString()
        {
            StringBuilder resultString = new StringBuilder();
            for(int i = 0; i < this.degrees.Count; i++)
            {
                if(this.degrees[i] == 0)
                {
                    resultString.Append(String.Format("1", this.degrees[i]));
                }
                else if(this.degrees[i] == -1)
                {
                    resultString.Append(String.Format("0", this.degrees[i]));
                }
                else if (i == this.degrees.Count - 1)
                {
                    resultString.Append(String.Format("x{0}", this.degrees[i]));
                }
                else
                {
                    resultString.Append(String.Format("x{0} + ", this.degrees[i]));
                }
            }
            return resultString.ToString();
        }

        public void SortPolynom(Polynom polynom)
        {
            polynom.degrees.Sort();
            polynom.degrees.Reverse();

        }
    }
}
