using FunctionCalculator.Commands;
using FunctionCalculator.Models;
using FunctionCalculator.Models.Calculation;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FunctionCalculator.ViewModels
{
	public class DoublePoint
	{
		public double X { get; set; }
		public double Y { get; set; }
	}

	class ExpressionViewModel : INotifyPropertyChanged
	{
		private readonly Calculation _calculation;
		private string _exceptionMessage;
		private ObservableCollection<DoublePoint> _points { get; set; }
		private readonly PlotModel _plotModel;
		public ExpressionViewModel()
		{
			_calculation = new Calculation();
			_points = new ObservableCollection<DoublePoint>();
			_plotModel = new PlotModel();
			Expression1 = new ExpressionModel();
		}
		public PlotModel PlotModel
		{
			get { return _plotModel; }
		}
		public string ExceptionMessage
		{
			get { return _exceptionMessage; }
			set { this._exceptionMessage = value; OnPropertyChanged("ExceptionMessage"); }
		}
		public ObservableCollection<DoublePoint> Points { get { return _points; } }
		public ExpressionModel Expression
		{
			get { return Expression1; }
			set
			{
				Expression1 = value;
				OnPropertyChanged("ExpressionModel");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
		public RelayCommand CalculateCommand
		{
			get
			{
				return CalculateCommand1 ??= new RelayCommand(obj =>
				{
					_points.Clear();
					_plotModel.Series.Clear();
					ExceptionMessage = "";
					try
					{
						for (double i = Expression1.A; i <= Expression1.B; i += Expression1.K)
						{
							_calculation.SetX(i);
							_points.Add(new DoublePoint() { X = i, Y = _calculation.Calculate(Expression1.Expression) });
						}
						LineSeries lineseries = new LineSeries
						{
							ItemsSource = _points.Select(f => new DataPoint(f.X, f.Y)),
							DataFieldX = "X",
							DataFieldY = "Y",
							StrokeThickness = 2,
							MarkerSize = 1,
							LineStyle = LineStyle.Solid,
							Color = OxyColors.Black,
							MarkerType = MarkerType.None,
						};
						_plotModel.Series.Add(lineseries);
						_plotModel.InvalidatePlot(true);
						OnPropertyChanged("PlotModel");
					}
					catch (Exception e)
					{
						ExceptionMessage = e.Message;
					}
				});
			}
		}
		public RelayCommand CalculateCommand1 { get; set; }
		public ExpressionModel Expression1 { get; set; }
	}
}
