namespace Model;

public class Manager
{
    public Person? CurrentUser { get; private set; }
    private IDataService<Person> _personDataService;
    private IDataService<Equipment> _equipmentDataService;

    public Manager(IDataService<Person> personDataService, IDataService<Equipment> equipmentDataService)
    {
        CurrentUser = null;
        _personDataService = personDataService;
        _equipmentDataService = equipmentDataService;
    }

    public async void Login(string email, string? password)
    {
        Person? person = await _personDataService.GetByIdAsync(email);
        
        if(person != null && password != null)
            CurrentUser = person;
    }

    public void Logout()
    {
        CurrentUser = null;
    }

    public async Task<IEnumerable<Equipment>?> GetEquipments()
    {
        IEnumerable<Equipment> equipments = await _equipmentDataService.GetAllAsync();
        return equipments;
    }

    public async Task<Equipment?> GetEquipmentById(string equipmentId)
    {
        Equipment? equipment = await _equipmentDataService.GetByIdAsync(equipmentId);

        if (equipment != null)
            return equipment;

        return null;
    }

    public async Task<bool> InsertEquipment(string id, string name, string description, string smallImage, string largeImage, int nbOfStoredCopies, int nbOfReservedCopies, int nbOfFreeCopies, Person supervisor)
    {
        Equipment equipment = new Equipment(id, name, description, smallImage, largeImage, nbOfStoredCopies, nbOfReservedCopies, nbOfFreeCopies, supervisor);
        bool success = await _equipmentDataService.CreateAsync(equipment);
        return success;
    }

    public async Task<bool> UpdateEquipment(Equipment equipment)
    {
        Equipment? equipment2 = await _equipmentDataService.GetByIdAsync(equipment.Id);

        if (equipment2 != null)
        {
            equipment2.Name = equipment.Name;
            equipment2.Description = equipment.Description;
            equipment2.SmallImage = equipment.SmallImage;
            equipment2.LargeImage = equipment.LargeImage;
            equipment2.NbOfStoredCopies = equipment.NbOfStoredCopies;
            equipment2.NbOfReservedCopies = equipment.NbOfReservedCopies;
            equipment2.NbOfFreeCopies = equipment.NbOfFreeCopies;
            equipment2.Supervisor = equipment.Supervisor;
            equipment2.Copies = equipment.Copies;
        
            bool success = await _equipmentDataService.UpdateAsync(equipment);
            return success;
        }
        
        return false;
    }

    public async Task<bool> DeleteEquipment(string id)
    {
        bool success = await _equipmentDataService.DeleteAsync(id);
        return success;
    }

    public async Task<IEnumerable<Copy>> GetCopiesOfEquipment(string id)
    {
        Equipment? equipment = await _equipmentDataService.GetByIdAsync(id);
        if (equipment != null)
        {
            return equipment.Copies;
        }

        return new List<Copy>();
    }

    public async Task<bool> AddCopy(string id, string equipmentId, Condition condition, Situation situation)
    {
        Equipment? equipment = await _equipmentDataService.GetByIdAsync(equipmentId);

        if (equipment != null)
        {
            Copy copy = new Copy(id, equipment, condition, situation);
            equipment.Copies.Add(copy);

            bool success = await UpdateEquipment(equipment);
            
            return success;
        }

        return false;
    }

    public async Task<bool> UpdateCopy(string idCopy, string equipmentId, Condition condition, Situation situation)
    {
        Equipment? equipment = await GetEquipmentById(equipmentId);
        if (equipment != null)
        {
            foreach (Copy copy in equipment.Copies)
            {
                if (copy.Id == idCopy)
                {
                    copy.Condition = condition;
                    copy.Situation = situation;
                    return true;
                }
            }
        }
        return false;
    }

    public async Task<bool> DeleteCopy(string idCopy, string equipmentId)
    {
        Equipment? equipment = await GetEquipmentById(equipmentId);
        if (equipment != null)
        {
            Copy? copy = equipment.Copies.FirstOrDefault(c => c.Id == idCopy);
            if (copy != null)
                equipment.Copies.Remove(copy);
        }
        return false;
    }
}