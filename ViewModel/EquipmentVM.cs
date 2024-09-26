using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;
using MyToolKit;

namespace ViewModel;

public class EquipmentVm : ObservableObject
{
    private Equipment? _equip;

    public EquipmentVm(Equipment equip)
    {
        Equip = equip;
    }
    
    public EquipmentVm()
    {}
    
    internal Equipment? Equip
    {
        get => _equip;
        set
        {
            SetProperty(ref _equip, value, "Equipment");
        }
    }
    
    public string Id
    {
        get => _equip?.Name ?? string.Empty;
    }
    
    public string Name
    {
	    get => _equip?.Name ?? string.Empty;
		set
		{
			if(_equip != null && _equip.Name != value)
			{
				_equip.Name = value;
				//il faut faire une vérification
				OnPropertyChanged("NameEquipment");
			}
		}
    }
    
    public string Description
    {
        get => _equip?.Description ?? string.Empty;
        set
        {
            if(_equip != null && _equip.Description != value)
            {
                _equip.Description = value;
                //il faut faire une vérification
                OnPropertyChanged("DescriptionEquipment");
            }
        }
    }
    
    public string SmallImage
    {
        get => _equip?.SmallImage ?? string.Empty;
        set
        {
            if(_equip != null && _equip.SmallImage != value)
            {
                _equip.SmallImage = value;
                //il faut faire une vérification
                OnPropertyChanged("SmallImageEquipment");
            }
        }
    }
    
    public string LargeImage
    {
        get => _equip?.LargeImage ?? string.Empty;
        set
        {
            if(_equip != null && _equip.LargeImage != value)
            {
                _equip.LargeImage = value;
                //il faut faire une vérification
                OnPropertyChanged("LargeImageEquipment");
            }
        }
    }
}