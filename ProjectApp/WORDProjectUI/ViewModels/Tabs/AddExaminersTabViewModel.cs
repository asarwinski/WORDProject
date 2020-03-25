using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WORDProjectUI.Utils;
using WORDProjectClassLib.Models;
using WORDProjectClassLib.DB;

namespace WORDProjectUI.ViewModels
{
    public class AddExaminersTabViewModel : ViewModel
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
				Add.RaiseCanExecuteChanged();
			}
		}


		public Command Add { get; set; }

		private bool canExecuteAdd(object obj)
		{
			if (Name != null && Surname != null && Pesel != null && BirthDate != null &&
				City != null && State != null && Zipcode != null && Country != null && Category != null)
				return true;
			else
				return false;
		}

		private void executeAdd(object obj)
		{
			var address = new Address { City = City, Country = Country, Zipcode = Zipcode, State = State };
			var examiner = new Examiner { Name = Name, Surname = Surname, Pesel = Pesel, BirthDate = (DateTime)BirthDate, Address = address };
			examiner.Permissions.Add(Category);
			db.AddExaminer(examiner);
			Name = null;
			Surname = null;
			Pesel = null;
			BirthDate = null;
			City = null;
			State = null;
			Zipcode = null;
			Country = null;
		}

		public AddExaminersTabViewModel()
		{
			db = new DataBase(ConnectionStringHelper.GetConnectionString(DBType.Internet));
			Add = new Command(executeAdd, canExecuteAdd);
		}
	}
}
