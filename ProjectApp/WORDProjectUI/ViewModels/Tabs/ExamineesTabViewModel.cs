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

		private ObservableCollection<Examinee> examinees;

		public ObservableCollection<Examinee> Examinees
		{
			get { return examinees; }
			set 
			{ 
				examinees = value;
				OnPropertyChanged();
			}
		}

		public ExamineesTabViewModel()
		{
			db = new DataBase(ConnectionStringHelper.GetConnectionString(DBType.Local));
			InitializeExaminees();
			OnPropertyChanged("Examinees");
		}

		private async void InitializeExaminees()
		{
			var data = await db.GetExaminees();
			Examinees = new ObservableCollection<Examinee>(data);
		}

	}
}
