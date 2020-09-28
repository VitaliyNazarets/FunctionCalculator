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
		private ExpressionModel _expression;
		private RelayCommand _calculateCommand;
		private Calculation _calculation;
		private string _exceptionMessage;
		private PlotModel _plotModel;
		public ExpressionViewModel()
		{
			_calculation = new Calculation();
			_points = new ObservableCollection<DoublePoint>();
			_plotModel = new PlotModel();
			_expression = new ExpressionModel();
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
		private ObservableCollection<DoublePoint> _points { get; set; }
		public ObservableCollection<DoublePoint> Points { get { return _points; } }
		public ExpressionModel Expression
		{
			get { return _expression; }
			set
			{
				_expression = value;
				OnPropertyChanged("ExpressionModel");
			}
		}
		

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
		public RelayCommand CalculateCommand
		{
			get
			{
				return _calculateCommand ??= new RelayCommand(obj =>
				{

					_points.Clear();
					_plotModel.Series.Clear();
					ExceptionMessage = "";
					try
					{
						ICollection<DataPoint> DrawPoints = new List<DataPoint>();

						
						for (double i = _expression.A; i <= _expression.B; i += _expression.K)
						{
							_calculation.SetX(i);
							_points.Add(new DoublePoint() { X = i, Y = _calculation.Calculate(_expression.Expression) });
						}
						DrawPoints = _points.Select(f => new DataPoint(f.X, f.Y)).ToList();
						LineSeries lineseries = new LineSeries
						{
							ItemsSource = Points,
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
	}
}
