using VisitorPattern;

List<IComponent> components = new List<IComponent>
            {
                new ConcreteComponentA(),
                new ConcreteComponentB()
            };

Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
var visitor1 = new ConcreteVisitor1();
ClientCode(components, visitor1);

Console.WriteLine();

Console.WriteLine("It allows the same client code to work with different types of visitors:");
var visitor2 = new ConcreteVisitor2();
ClientCode(components, visitor2);

static void ClientCode(List<IComponent> components, IVisitor visitor)
{
    foreach (var component in components)
    {
        component.Accept(visitor);
    }
}