using A;

B b = new B();
b.MessageSended += B_MessageSended;
Console.WriteLine("Wait for message from B");
b.DoAny();

Console.ReadKey();

void B_MessageSended(string message)
{
    Console.WriteLine(message);
}