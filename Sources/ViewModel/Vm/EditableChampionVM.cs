using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Immutable;
using System;
using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Windows.Input;


namespace ViewModel.Vm
{
    public class EditableChampionVM :  INotifyPropertyChanged
    {

        public ChampionVM Model { get; set; }
        public EditableChampionVM(ChampionVM vM)
        {
            IsNew = vM is null;
            Model = IsNew ? null : vM;
            _bio = IsNew ? string.Empty : Model.Bio;
            icon = IsNew ? string.Empty : Model.Icon;
            _name = IsNew ? string.Empty : Model.Name;
            image = IsNew ? string.Empty : Model.Image.Base64;
            _classe = IsNew ? ChampionClass.Unknown : Model.Class;
            ListClasses = Enum.GetValues<ChampionClass>().Where(c => c != ChampionClass.Unknown).ToArray();

        }
        public bool IsNew { get; private set; }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
        }
        private ChampionClass _classe;
        public ChampionClass Class
        {
            get => _classe;
            set
            {
                if (_classe == null) return;
                _classe = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<ChampionClass> ListClasses { get; }

        private string icon;
        public string Icon
        {
            get => icon;
            set
            {
                if (icon == value) return;
                icon = value;
                OnPropertyChanged();
            }
        }
        private int index;
        public int Index
        {
            get => index;
            set
            {
                if (index == value) return;
                index = value;
                OnPropertyChanged();
            }
        }
        private string image;
        public string Image
        {
            get => image;
            set
            {
                if (image == value) return;
                image = value;
                OnPropertyChanged();
            }
        }
        private string _bio;
        public string Bio
        {
            get => _bio;
            set
            {
                if (_bio == value) return;
                _bio = value;
                OnPropertyChanged();
            }
        }
        public ReadOnlyDictionary<string, int> Characteristics
        {
            get => Model.Characteristics;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
        public void SaveChampion()
        {
            if (!IsNew)
            {
                Model.Bio = Bio;
                Model.Icon = Icon;
                Model.Image.Base64 = Image;
                Model.Class = Class;
            }
            else
            {
                //Model.Model = new Champion(Name,ChampionClass.Unknown,Icon,"",Bio);
                Model = new ChampionVM(new Champion(Name, ChampionClass.Unknown, Icon, "", Bio));
                var data = "";
                //foreach (KeyValuePair<string,int> c in Characteristique)
                //{
                //    Model.Model.AddCharacteristics(new Tuple<string, int>(c.Key, c.Value));
                //}

            }





        }



    }
}

