using PiDigits.Code;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PiDigits.WPF
{
	public partial class MainWindow : Window
	{
		private Scoreboard _scoreboard;
		private bool _floatingPoint = true;

		public MainWindow()
		{
			InitializeComponent();

			_scoreboard = new Scoreboard();

			// Create bindings.

			var binding = new Binding("Points");
			binding.Source = _scoreboard;
			binding.StringFormat = "Points: {0}";
			PointsBlock.SetBinding(TextBlock.TextProperty, binding);

			var binding2 = new Binding("Fails");
			binding2.Source = _scoreboard;
			binding2.StringFormat = "Fails: {0}";
			FailsBlock.SetBinding(TextBlock.TextProperty, binding2);
		}

		private void DigitButton_Click(object sender, RoutedEventArgs e)
		{
			string digitString = (sender as Button).Content.ToString();
			char digit = char.Parse(digitString);

			bool isCorrect = DigitChecker.CheckDigit(digit);

			if (isCorrect)
			{
				DigitsBlock.Text += digit;
				_scoreboard.Points++;
			}
			else
			{
				char correctDigit = DigitChecker.GetCorrectDigit(_scoreboard.Points + _scoreboard.Fails);

				DigitsBlock.Text += correctDigit;

				_scoreboard.Fails++;

				if (_scoreboard.Fails == 3)
				{
					MessageBox.Show($"Game over! You scored {_scoreboard.Points} points.", "Game over!");

					foreach (var elem in MainGrid.Children)
					{
						if (elem is Button b)
						{
							b.IsEnabled = false;
						}
					}
				}
			}

			if (_floatingPoint)
			{
				DigitsBlock.Text += '.';
				_floatingPoint = false;
			}
		}

		private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			var key = e.Key;

			switch (key)
			{
				case System.Windows.Input.Key.D0:
					DigitButton0.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
					break;

				case System.Windows.Input.Key.D1:
					DigitButton1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
					break;

				case System.Windows.Input.Key.D2:
					DigitButton2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
					break;

				case System.Windows.Input.Key.D3:
					DigitButton3.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
					break;

				case System.Windows.Input.Key.D4:
					DigitButton4.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
					break;

				case System.Windows.Input.Key.D5:
					DigitButton5.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
					break;

				case System.Windows.Input.Key.D6:
					DigitButton6.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
					break;

				case System.Windows.Input.Key.D7:
					DigitButton7.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
					break;

				case System.Windows.Input.Key.D8:
					DigitButton8.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
					break;

				case System.Windows.Input.Key.D9:
					DigitButton9.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
					break;
			}
		}
	}
}
