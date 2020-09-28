using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FunctionCalculator.Models
{
	public class ExpressionModel : INotifyPropertyChanged
    {
        private string _expression = "sin(cos(tan(x^2)))*5/14";
        private double _a = 0.1;
        private double _b = 0.9;
        private double _k = 0.01;
        public double A
        {
            get
            {
                return this._a;
            }
            set
            {
                this._a = value;
                OnPropertyChanged("A");
            }
        }
        public double B
        {
            get
            {
                return this._b;
            }
            set
            {
                this._b = value;
                OnPropertyChanged("B");
            }
        }
        public double K
        {
            get
            {
                return this._k;
            }
            set
            {
                this._k = value;
                OnPropertyChanged("K");
            }
        }
        public string Expression
        {
            get
            {
                return this._expression;
            }
            set
            {
                this._expression = value;
                OnPropertyChanged("Expression");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
