using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WORDProjectUI.Utils;
using WORDProjectUI.ViewModels;
using WORDProjectClassLib.Models;
using WORDProjectClassLib.DB;

namespace WORDProjectUI.ViewModels
{
    public class ExamsHistoryTabViewModel : ViewModel
    {
		DataBase db;

		private ObservableCollection<Exam> exams;
		public ObservableCollection<Exam> Exams
		{
			get { return exams; }
			set
			{ 
				exams = value;
				OnPropertyChanged();
				OnPropertyChanged("Examiners");
				OnPropertyChanged("Examinees");
				OnPropertyChanged("Categories");
				OnPropertyChanged("Date");
				OnPropertyChanged("ResultIndex");
			}
		}

		private ObservableCollection<Exam> filteredExams;
		public ObservableCollection<Exam> FilteredExams
		{
			get { return filteredExams; }
			set 
			{ 
				filteredExams = value;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<Examiner> Examiners
		{
			get
			{
				var data = Exams.Select(x => x.Examiner).Distinct().ToList();
				data.Sort((a, b) => a.Name.CompareTo(b.Name));
				return new ObservableCollection<Examiner>(data);
			}
		}
		public ObservableCollection<Examinee> Examinees
		{
			get
			{
				var data = Exams.Select(x => x.Examinee).Distinct().ToList();
				data.Sort((a, b) => a.Name.CompareTo(b.Name));
				return new ObservableCollection<Examinee>(data);
			}
		}
		public ObservableCollection<string> Categories
		{
			get
			{
				var data = Exams.Select(x => x.Category).Distinct();
				return new ObservableCollection<string>(data);
			}
		}

		//Filters
		private Examiner examiner;
		public Examiner Examiner
		{
			get { return examiner; }
			set 
			{ 
				examiner = value;
				OnPropertyChanged();
			}
		}

		private Examinee examinee;
		public Examinee Examinee
		{
			get { return examinee; }
			set 
			{ 
				examinee = value;
				OnPropertyChanged();
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
			}
		}

		private DateTime? date;
		public DateTime? Date
		{
			get { return date; }
			set
			{ 
				date = value;
				OnPropertyChanged();
			}
		}


		private int resultIndex;
		public int ResultIndex
		{
			get { return resultIndex; }
			set
			{
				resultIndex = value;
				OnPropertyChanged();
			}
		}

		public bool? Result
		{
			get
			{
				switch (ResultIndex)
				{
					case 1:
						return true;
					case 2:
						return false;
					default:
						return null;
				}
			}
		}

		//Commands
		public Command Clear { get; set; }
		private void executeClear(object obj)
		{
			Examiner = null;
			Examinee = null;
			Category = null;
			ResultIndex = 0;
			Date = null;
			executeSearch(null);
		}

		public Command Search { get; set; }
		private async void executeSearch(object obj)
		{
			var data = await db.GetFinishedExams(Examiner, Examinee, Category, Date, Result);
			FilteredExams = new ObservableCollection<Exam>(data);
		}

		public ExamsHistoryTabViewModel()
		{
			db = new DataBase(ConnectionStringHelper.GetConnectionString(DBType.Local));
			FilteredExams = new ObservableCollection<Exam>();
			Exams = new ObservableCollection<Exam>();
			InitializeExams();
			Search = new Command(executeSearch);
			Clear = new Command(executeClear);
		}

		private async void InitializeExams()
		{
			var data = await db.GetFinishedExams();
			Exams = new ObservableCollection<Exam>(data);
			FilteredExams = new ObservableCollection<Exam>(data);
		}
	}
}
