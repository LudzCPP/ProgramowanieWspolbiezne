﻿using ViewModel;

namespace View

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

        ViewModelBase viewModel = ViewModelBase.CreateViewModelAPI();
        DataContext = viewModel;

        }
    }
}
