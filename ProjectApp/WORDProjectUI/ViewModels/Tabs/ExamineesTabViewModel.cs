using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WORDProjectUI.Utils;
using WORDProjectClassLib.Models;
using WORDProjectClassLib.DB;
using System.Collections.ObjectModel;

namespace WORDProjectUI.ViewModels
{
    class ExamineesTabViewModel : ViewModel
    {
		private IDataAccess db;

		private ObservableCollection<Examinee> filteredExaminees;
		public ObservableCollection<Examinee> FilteredExaminees
		{
			get { return filteredExaminees; }
			set 
			{
				filteredExaminees = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<Examinee> examinees;
		public ObservableCollection<Examinee> Examinees
		{
			get { return examinees; }
			set 
			{
				examinees = value;
				OnPropertyChanged();
				OnPropertyChanged("Names");
				OnPropertyChanged("Surnames");
				OnPropertyChanged("Categories");
				OnPropertyChanged("Cities");
			}
		}

		public ObservableCollection<string> Names
		{
			get
			{
				var names = Examinees.Select(x => x.Name).Distinct();
				return new ObservableCollection<string>(names);
			}
		}
		public ObservableCollection<string> Surnames
		{
			get
			{
				var surnames = Examinees.Select(x => x.Surname).Distinct();
				return new ObservableCollection<string>(surnames);
			}
		}
		public ObservableCollection<string> Categories
		{
			get
			{
				var categories = Examinees.Select(x => x.Categories).SelectMany(x => x).Distinct();
				return new ObservableCollection<string>(categories);
			}
		}
		public ObservableCollection<string> Cities
		{
			get
			{
				var cities = Examinees.Select(x => x.Address.City).Distinct();
				return new ObservableCollection<string>(cities);
			}
		}


		//Filters
		private string name;
		public string Name
		{
			get { return name; }
			set 
			{ 
				name = value;
				OnPropertyChanged();
				System.Diagnostics.Debug.WriteLine(date);
			}
		}

		private string surname;
		public string Surname
		{
			get { return surname; }
			set 
			{ 
				surname = value;
				OnPropertyChanged();
			}
		}

		private string categorie;
		public string Categorie
		{
			get { return categorie; }
			set 
			{ 
				categorie = value;
				OnPropertyChanged();
			}
		}

		private string city;
		public string City
		{
			get { return city; }
			set 
			{ 
				city = value;
				OnPropertyChanged();
			}
		}

		private DateTime date;
		public DateTime Date
		{
			get { return date; }
			set 
			{
				date = value;
				OnPropertyChanged();
			}
		}


		public ExamineesTabViewModel()
		{
			db = new DataBase(ConnectionStringHelper.GetConnectionString(DBType.Local));
			Examinees = new ObservableCollection<Examinee>();
			InitializeExaminees();

		}

		private async void InitializeExaminees()
		{
			var data = await db.GetExaminees();
			FilteredExaminees = new ObservableCollection<Examinee>(data);
			Examinees = new ObservableCollection<Examinee>(data);
		}

	}
}
