﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// The Read Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellReadPage : ContentPage
    {
        // View Model for Item
        public readonly GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for UTs
        public CellReadPage(bool UnitTest) { }

        /// <summary>
        /// Constructor called with a view model
        /// This is the primary way to open the page
        /// The viewModel is the data that should be displayed
        /// </summary>
        /// <param name="viewModel"></param>
        public CellReadPage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Update_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new ItemUpdatePage(ViewModel)));
            //await Navigation.PopAsync();
        }

        /// <summary>
        /// Calls for Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Delete_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new ItemDeletePage(ViewModel)));
            //await Navigation.PopAsync();
        }

        /// <summary>
		/// Jump to the Cell Update Page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void CellEditButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CellUpdatePage());
        }

    }
}