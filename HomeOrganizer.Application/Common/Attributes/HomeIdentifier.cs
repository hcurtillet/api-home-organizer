using System.ComponentModel.DataAnnotations;

namespace HomeOrganizer.Application.Common.Attributes;
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class HomeIdentifier: Attribute
{
}