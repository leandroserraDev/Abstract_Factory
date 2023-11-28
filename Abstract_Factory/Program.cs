using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Cryptography;

public interface IProductA
{
    string RetornarStringA();
}

public class ConcreteProductA1: IProductA
{
    public string RetornarStringA()
    {
        return "string 1";
    }

}

public class ConcreteProductA2 : IProductA
{
    public string RetornarStringA()
    {
        return "string 2";

    }
}

public interface IProductB
{
    string RetornarStringB();

}


public class ConcreteProductB1 : IProductB
{
    public string RetornarStringB()
    {
        return "string 3B";
    }
}

public class ConcreteProductB2 : IProductB
{
    public string RetornarStringB()
    {
        return "string 4B";
    }
}





public interface IFactory
{
    IProductA CreateProductA();
    IProductB CreateProductB();
}

public class ConcreteFactory : IFactory
{
    public IProductA CreateProductA()
    {
        return new ConcreteProductA1();
    }

    public IProductB CreateProductB()
    {
        return new ConcreteProductB1();

    }
}

public class ConcreteFactory1 : IFactory
{
    public IProductA CreateProductA()
    {
        return new ConcreteProductA2();

    }

    public IProductB CreateProductB()
    {
        return new ConcreteProductB2();
    }
}


public interface Aeronave
{
    public string RetornarTipoAeronave();
}

public class Balao : Aeronave
{
    public string RetornarTipoAeronave()
    {
        return "Essa aeronave é um balão";
    }
}

public class Dirigivel : Aeronave
{
    public string RetornarTipoAeronave()
    {
        return "Essa aeronave é um dirigível";

    }
}

public class Aviao : Aeronave
{
    public string RetornarTipoAeronave()
    {
        return "Essa aeronave é um Avião";

    }
}


public interface Automotor
{
    public string RetornarTipoAutomotor();
}

public sealed class Ciclomoto : Automotor
{
    public string RetornarTipoAutomotor()
    {
        return "Esse é um veículo cliclomoto";
    }
}

public sealed class Motoneta : Automotor
{
    public string RetornarTipoAutomotor()
    {
        return "Esse é um veículo motoneta";
    }
}

public sealed class Motocicleta : Automotor
{
    public string RetornarTipoAutomotor()
    {
        return "Esse é um veículo motocicleta";
    }
}

public interface IFactory2
{
    Aeronave CriarAeronave(int tipo);
    Automotor CriarAutomotor(int tipo);
}

public class FabricaConcreta : IFactory2
{
    public Aeronave CriarAeronave(int tipo)
    {
        switch (tipo)
        {
            case 1:
                return new Balao();
            case 2:
                return new Dirigivel();

            case 3:
                return new Aviao();

            default: return null;
         }
    }

    public Automotor CriarAutomotor(int tipo)
    {
        switch (tipo)
        {
            case 1:
                return new Ciclomoto();
            case 2:
                return new Motoneta();

            case 3:
                return new Motocicleta();

            default: return null;
        }
    }
}

class Client
{
    public void Main()
    {
        // The client code can work with any concrete factory class.
        Console.WriteLine("Client: Testing client code with the first factory type...");
        ClientMethod(new FabricaConcreta());
        Console.WriteLine();
    }

    public void ClientMethod(IFactory2 factory)
    {
        var productA = factory.CriarAutomotor(1);
        var productB = factory.CriarAeronave(1);

        Console.WriteLine(productA.RetornarTipoAutomotor());
        Console.WriteLine(productB.RetornarTipoAeronave());
    }
}

class Program
{
    static void Main(string[] args)
    {
        new Client().Main();
    }
}
