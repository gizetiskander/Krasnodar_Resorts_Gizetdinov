using System;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Krasnodar_Resorts_Gizetdinov.Pages;
using System.Windows.Input;

namespace Krasnodar_Resorts_Gizetdinov.ViewPages
{
    internal class MainViewPages : PagesFoundation
    {
        private Page MainPage = new MainPage();
        private Page OrderPage = new OrderPage();
        private Page SalePage = new SalePage();
        private Page InfoPage = new InfoPage();
        private Page PersonalPage = new PersonalPage();
        private Page AdminPage = new AdminPage();
        private Page _CurPage = new MainPage();

        public Page CurPage
        {
            get => _CurPage;
            set => Set(ref _CurPage, value);
        }

        public ICommand OpenAPage
        {
            get
            {
                return new RelayCommand(() => CurPage = AdminPage);
            }
        }

        public ICommand OpenMPage
        {
            get
            {
                return new RelayCommand(() => CurPage = MainPage);
            }
        }

        public ICommand OpenOPage
        {
            get
            {
                return new RelayCommand(() => CurPage = OrderPage);
            }
        }

        public ICommand OpenSPage
        {
            get
            {
                return new RelayCommand(() => CurPage = SalePage);
            }
        }

        public ICommand OpenIPage
        {
            get
            {
                return new RelayCommand(() => CurPage = InfoPage);
            }
        }

        public ICommand OpenPPage
        {
            get
            {
                return new RelayCommand(() => CurPage = PersonalPage);
            }
        }
    }
}
