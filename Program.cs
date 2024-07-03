using ProtoBuf;

class Program
{
    static void Main(string[] args)
    {
        // Sample person object
        var person = new Person { Id = 1, Name = "Sherif", Email = "sherif@example.com" };

        // Serialize to bytes
        byte[] serializedBytes = SerializeToBytes(person);

        // Print serialized bytes
        Console.WriteLine("Serialized Bytes:");
        foreach (var b in serializedBytes)
        {
            Console.Write($"{b:X2} "); // Print byte in hexadecimal format
        }
        Console.WriteLine();

        // Convert bytes back to JSON
        string json = ConvertBytesToJson(serializedBytes);

        // Print JSON
        Console.WriteLine($"Deserialized JSON: {json}");

        // Deserialize JSON to object
        var deserializedPerson = Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(json);

        // Print individual fields
        Console.WriteLine($"Deserialized Id: {deserializedPerson.Id}");
        Console.WriteLine($"Deserialized Name: {deserializedPerson.Name}");
        Console.WriteLine($"Deserialized Email: {deserializedPerson.Email}");
    }

    static byte[] SerializeToBytes(Person person)
    {
        // Serialize Json to bytes
        using (MemoryStream stream = new MemoryStream())
        {
            Serializer.Serialize(stream, person);
            return stream.ToArray();
        }
    }

    static string ConvertBytesToJson(byte[] bytes)
    {
        // Deserialize from bytes
        using (MemoryStream stream = new MemoryStream(bytes))
        {
            var deserializedPerson = Serializer.Deserialize<Person>(stream);
            // Convert to JSON
            return Newtonsoft.Json.JsonConvert.SerializeObject(deserializedPerson);
        }
    }
}
