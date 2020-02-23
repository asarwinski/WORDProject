using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using WORDProjectUI.Utils;

namespace WORDProjectUI.ViewModels
{
    class LoginViewModel : ViewModel
    {
		private bool _incorectLoginPassword;

		public bool IncorectLoginPassword
		{
			get { return _incorectLoginPassword; }
			set 
			{
				if (_incorectLoginPassword != value)
				{
					_incorectLoginPassword = value;
					OnPropertyChanged();
				}
			}
		}

		public LoginViewModel()
		{
			IncorectLoginPassword = false;
		}
    }
}
