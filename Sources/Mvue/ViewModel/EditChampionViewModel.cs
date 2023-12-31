﻿using System;
using System.Collections.ObjectModel;
using ViewModel;
using ViewModel.Vm;

namespace Mvue.ViewModel
{
	public class EditChampionViewModel
	{
        public Command PickIconCommand { get; }
        public Command PickImageCommand { get; }
        public EditChampionViewModel(ChampionMgrVM manager, EditableChampionVM aditableChampion,ChampionVM championVM)
		{
			Manager = manager;
            EditableChampion = aditableChampion;
			ChampionVM = championVM;
			SaveChampionCommand = new Command(SaveChampion);
            PickIconCommand = new Command(async () => await PickIcon());
            PickImageCommand = new Command(async () => await PickImage());
            Title = aditableChampion.IsNew ? "Create" : "Update";
        }
        public ReadOnlyDictionary<string, int> Characteristics
        {
            get => Characteristics;
        }
        public string Title { get; }
		private ChampionMgrVM Manager;
		public EditableChampionVM EditableChampion { get; }
		private ChampionVM ChampionVM;
		public Command SaveChampionCommand { get; }

		private async void SaveChampion()
		{
            Manager.SaveChampion(EditableChampion, ChampionVM);
            await Shell.Current.Navigation.PopAsync();
        }
        private async Task PickIcon()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick an image",

            });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                var bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                EditableChampion.Icon = Convert.ToBase64String(bytes);
            }
        }
        private async Task PickImage()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick ",

            });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                var bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                EditableChampion.Image = Convert.ToBase64String(bytes);
            }
        }
    }
}

