using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WORDProjectClassLib.DB;
using WORDProjectClassLib.Models;
using WORDProjectUI.Utils;

namespace WORDProjectUI.ViewModels
{
    public class ExaminersTabViewModel : ViewModel
    {
		private IDataAccess db;

		private ObservableCollection<Examiner> filteredExaminers;
		public ObservableCollection<Examiner> FilteredExaminers
		{
			get { return filteredExaminers; }
			set
			{
				filteredExaminers = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<Examiner> examiners;
		public ObservableCollection<Examiner> Examiners
		{
			get { return examiners; }
			set
			{
				examiners = value;
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
				var names = Examiners.Select(x => x.Name).Distinct().ToList();
				names.Sort();
				var names_oc = new ObservableCollection<string>(names);
				names_oc.Insert(0, null);
				return names_oc;
			}
		}
		public ObservableCollection<string> Surnames
		{
			get
			{
				var surnames = Examiners.Select(x => x.Surname).Distinct();
				return new ObservableCollection<string>(surnames);
			}
		}
		public ObservableCollection<string> Categories
		{
			get
			{
				var categories = Examiners.Select(x => x.Permissions).SelectMany(x => x).Distinct();
				return new ObservableCollection<string>(categories);
			}
		}
		public ObservableCollection<string> Cities
		{
			get
			{
				var cities = Examiners.Select(x => x.Address.City).Distinct();
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

		private int birthMonth;
		public int BirthMonth
		{
			get { return birthMonth; }
			set
			{
				birthMonth = value;
				OnPropertyChanged();
			}
		}

		//Commands
		public Command Search { get; set; }
		private async void executeSearch(object obj)
		{
			DateTime? date = BirthMonth == 0 ? null : new DateTime?(new DateTime(2020, BirthMonth, 1));
			var result = await db.GetExaminers(Name, Surname, Categorie, City, date);
			FilteredExaminers = new ObservableCollection<Examiner>(result);
		}

		public Command Clear { get; set; }
		private void executeClear(object obj)
		{
			Name = null;
			Surname = null;
			Categorie = null;
			City = null;
			BirthMonth = 0;
			executeSearch(null);
		}

		public ExaminersTabViewModel()
		{
			db = new DataBase(ConnectionStringHelper.GetConnectionString(DBType.Internet));
			Examiners = new ObservableCollection<Examiner>();
			InitializeExaminers();
			Search = new Command(executeSearch);
			Clear = new Command(executeClear);
		}

		private async void InitializeExaminers()
		{
			var data = await db.GetExaminers();
			FilteredExaminers = new ObservableCollection<Examiner>(data);
			Examiners = new ObservableCollection<Examiner>(data);
		}
	}
}
