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
    public partial class EditableChampionVM : ObservableObject
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
            [ObservableProperty]
            private string _name;
            [ObservableProperty]
            private ChampionClass _classe;
            public IEnumerable<ChampionClass> ListClasses { get; }
            [ObservableProperty]
            private string icon;
            [ObservableProperty]
            private int index;       
            [ObservableProperty]
            private string image;
            [ObservableProperty]
            private string _bio;     
        public ReadOnlyDictionary<string, int> Characteristics
        {
            get => Model.Characteristics;
        }      
        public void SaveChampion()
        {
            if (!IsNew)
            {
                Model.Bio = Bio;
                Model.Icon = Icon;
                Model.Image.Base64 = Image;
                Model.Class = Classe;
            }
            else
            {            
                Model = new ChampionVM(new Champion(Name, ChampionClass.Unknown, Icon, "", Bio));
                var data = "";
            }

        }

    }
}

