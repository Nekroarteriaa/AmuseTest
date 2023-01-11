namespace DataStoring.Interface
{
    public interface IDataStoring<T>
    {
        T DoLoadStoredData(string dataSavedName);
        void DoSaveData( string dataNameToSave, T dataToSave);
    }
}