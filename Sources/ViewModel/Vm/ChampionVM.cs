using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class ChampionVM : INotifyPropertyChanged
{
    public ChampionVM(Champion champion) => Model = champion;
    private Champion model;
    public Champion Model
    {
        get => model;
        set
        {
            if (value.Equals(model)) return;
            if (value == null) return;
            model = value;
            OnPropertyChanged();
        }
    }
    public ReadOnlyDictionary<string, int> Characteristics
    {
        get => Model.Characteristics;
    }
    
    public string Name
    {
        get => Model.Name;
        set
        {
            //if (model == null) return;
            //Model.Name = value;
            //OnPropertyChanged();
        }
    }

    public string Icon
    {
        get => Model.Icon;
        set
        {
            if (model == null) return;
            Model.Icon = value;
            OnPropertyChanged();
        }
    }
    public ChampionClass Class
    {
        get => Model.Class;
        set
        {
            if (model == null) return;
            Model.Class = value;
            OnPropertyChanged();
        }
    }

    public LargeImage Image
    {
        get => Model.Image;
        set
        {
            if (model == null) return;
            Model.Image = value;
            OnPropertyChanged();
        }
    }

    public string Bio
    {
        get => Model.Bio;
        set
        {
            if (model == null) return;
            Model.Bio = value;
            OnPropertyChanged();
        }
    }
    private ObservableCollection<Skill> skills;
    public HashSet<Skill> Skills
    {
        get => Model.Skills.ToHashSet();
        set
        {
            if (value.Equals(skills)) return;
            skills = new ObservableCollection<Skill>(Skills);
            OnPropertyChanged();
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
}

