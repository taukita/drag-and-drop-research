using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DragAndDropResearch.MicroMvvm
{
	[Serializable]
	public abstract class ObservableObject : INotifyPropertyChanged
	{
		[field: NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
		    PropertyChanged?.Invoke(this, e);
		}

	    protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}

		protected void RaisePropertyChanged<T>(Expression<Func<T>> changedProperty)
		{
			string propertyName = ((MemberExpression)changedProperty.Body).Member.Name;
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}
	}
}