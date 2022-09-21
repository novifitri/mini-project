namespace MiniProject.Model
{
    abstract class Model<T>
    {
    protected string connectionString = "Data Source =DESKTOP-4UE3BDQ;Initial Catalog=SistemAbsensi;User ID=test;Password=tes123;";
    public abstract void GetAll(); 
    public abstract void GetById(int id);
    public abstract void Insert(T type);
    public abstract void Update(T type, int id);
    public abstract void Delete(int id); 
    }
}
