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
    public class AddExamTabViewModel : ViewModel
    {
		DataBase db;

		private string name;
		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				OnPropertyChanged();
				Add.RaiseCanExecuteChanged();
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
				Add.RaiseCanExecuteChanged();
			}
		}

		private string pesel;
		public string Pesel
		{
			get { return pesel; }
			set
			{
				pesel = value;
				OnPropertyChanged();
				Add.RaiseCanExecuteChanged();
			}
		}

		private DateTime? birthDate;
		public DateTime? BirthDate
		{
			get { return birthDate; }
			set
			{
				birthDate = value;
				OnPropertyChanged();
				Add.RaiseCanExecuteChanged();
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
				Add.RaiseCanExecuteChanged();
			}
		}

		private string state;
		public string State
		{
			get { return state; }
			set
			{
				state = value;
				OnPropertyChanged();
				Add.RaiseCanExecuteChanged();
			}
		}

		private string zipcode;
		public string Zipcode
		{
			get { return zipcode; }
			set
			{
				zipcode = value;
				OnPropertyChanged();
				Add.RaiseCanExecuteChanged();
			}
		}

		private string country;
		public string Country
		{
			get { return country; }
			set
			{
				country = value;
				OnPropertyChanged();
				Add.RaiseCanExecuteChanged();
			}
		}

		private string category;
		public string Category
		{
			get { return category; }
			set
			{
				category = value;
				OnPropertyChanged();
				OnPropertyChanged("Examiners");
				Add.RaiseCanExecuteChanged();
			}
		}

		private ObservableCollection<Examiner> examiners;
		public ObservableCollection<Examiner> Examiners
		{
			get 
			{ 
				var filtered = examiners.Where(x => x.Permissions.Contains(Category));
				return new ObservableCollection<Examiner>(filtered);
			}
			set
			{
				examiners = value;
				OnPropertyChanged();
			}
		}

		private Examiner examiner;
		public Examiner Examiner
		{
			get { return examiner; }
			set
			{
				examiner = value;
				OnPropertyChanged();
				Add.RaiseCanExecuteChanged();
			}
		}

		private DateTime? examDate;

		public DateTime? ExamDate
		{
			get { return examDate; }
			set
			{
				examDate = value;
				OnPropertyChanged();
				Add.RaiseCanExecuteChanged();
			}
		}


		public Command Add { get; set; }
		private bool canExecuteAdd(object obj)
		{
			if (Name != null && Surname != null && Pesel != null && BirthDate != null &&
				City != null && State != null && Zipcode != null && Country != null && Category != null &&
				Examiner != null && ExamDate != null)
				return true;
			else
				return false;
		}
		private void executeAdd(object obj)
		{
			Address address = new Address() { City = City, State = State, Country = Country, Zipcode = Zipcode };
			Examinee examinee = new Examinee() { Name = Name, Surname = Surname, Pesel = Pesel, BirthDate = (DateTime)BirthDate, Address = address };
			Exam exam = new Exam() { Examinee = examinee, Examiner = Examiner, Category = Category, Date = (DateTime)ExamDate };
			db.AddExam(exam);
			Name = null;
			Surname = null;
			Pesel = null;
			BirthDate = null;
			City = null;
			State = null;
			Zipcode = null;
			Country = null;
			Category = null;
			Examiner = null;
			ExamDate = null;
		}

		public AddExamTabViewModel()
		{
			Examiners = new ObservableCollection<Examiner>();
			db = new DataBase(ConnectionStringHelper.GetConnectionString(DBType.Internet));
			Add = new Command(executeAdd, canExecuteAdd);
			InitilizeExaminers();
		}

		private async void InitilizeExaminers()
		{
			var data = await db.GetExaminers();
			Examiners = new ObservableCollection<Examiner>(data);
		}
	}
}
