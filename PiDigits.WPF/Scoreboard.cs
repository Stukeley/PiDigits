using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PiDigits.WPF
{
	public class Scoreboard : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		#endregion INotifyPropertyChanged

		private int _points;
		private int _fails;

		public int Points
		{
			get
			{
				return _points;
			}
			set
			{
				_points = value;
				OnPropertyChanged();
			}
		}

		public int Fails
		{
			get
			{
				return _fails;
			}
			set
			{
				_fails = value;
				OnPropertyChanged();
			}
		}
	}
}
