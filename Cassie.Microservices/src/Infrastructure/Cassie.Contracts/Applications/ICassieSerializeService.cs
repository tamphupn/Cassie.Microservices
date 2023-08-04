namespace Cassie.Contracts.Applications
{
	public interface ICassieSerializeService
    {
        string Serialize<T>(T obj);
        string Serialize<T>(T obj, Type type);
        T Deserialize<T>(string text);
    }
}

