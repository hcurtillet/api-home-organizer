namespace HomeOrganizer.Application.Common.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class Authenticated: Attribute
{
}