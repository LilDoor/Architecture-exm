using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Architecture.MarketPlace
{
    public abstract class Furniture
    {
        public string Name { get; set; }
        public string Style { get; set; }
        public string Material { get; set; }
        public float Price { get; set; }

        public Furniture(string name, string style, string material, float pr) { this.Name = name; this.Style = style; this.Material = material; this.Price = pr; }
    }

    public abstract class FurnitureFactory
    {
        public abstract Chair CreateChair();
        public abstract Table CreateTable();
        public abstract Sofa CreateSofa();
    }

    public class ModernWoodFactory : FurnitureFactory
    {
        public override Chair CreateChair() => new ModernWoodChair();
        public override Table CreateTable() => new ModernWoodTable();
        public override Sofa CreateSofa() => new ModernWoodSofa();
    }

    public class TraditionalMetalFactory : FurnitureFactory
    {
        public override Chair CreateChair() => new TraditionalMetalChair();
        public override Table CreateTable() => new TraditionalMetalTable();
        public override Sofa CreateSofa() => new TraditionalMetalSofa();
    }

    public class IndustrialGlassFactory : FurnitureFactory
    {
        public override Chair CreateChair() => new IndustrialGlassChair();
        public override Table CreateTable() => new IndustrialGlassTable();
        public override Sofa CreateSofa() => new IndustrialGlassSofa();
    }

    public class Chair : Furniture { public Chair(string name, string style, string material, float price) : base(name, style, material, price) { } }
    public class Table : Furniture { public Table(string name, string style, string material, float price) : base(name, style, material, price) { } }
    public class Sofa : Furniture { public Sofa(string name, string style, string material, float price) : base(name, style, material, price) { } }

    public class ModernWoodChair : Chair { public ModernWoodChair() : base("Modern Wood Chair", "Modern", "Wood", 150.0f) { } }
    public class ModernWoodTable : Table { public ModernWoodTable() : base("Modern Wood Table", "Modern", "Wood", 350.0f) { } }
    public class ModernWoodSofa : Sofa { public ModernWoodSofa() : base("Modern Wood Sofa", "Modern", "Wood", 500.0f) { } }

    public class TraditionalMetalChair : Chair {
        public TraditionalMetalChair() : base("Traditional Metal Chair", "Traditional", "Metal", 120.0f) { }
    }
    public class TraditionalMetalTable : Table { public TraditionalMetalTable() : base("Traditional Metal Table", "Traditional", "Metal", 200.0f) { } }
    public class TraditionalMetalSofa : Sofa { public TraditionalMetalSofa() : base("Traditional Metal Sofa", "Traditional", "Metal", 400.0f) { } }

    public class IndustrialGlassChair : Chair { public IndustrialGlassChair() : base("Industrial Glass Chair", "Industrial", "Glass", 130.0f) { } }
    public class IndustrialGlassTable : Table { public IndustrialGlassTable() : base("Industrial Glass Table", "Industrial", "Glass", 340.0f) { } }
    public class IndustrialGlassSofa : Sofa { public IndustrialGlassSofa() : base("Industrial Glass Sofa", "Industrial", "Glass", 600.0f) { } }

    public class FurnitureCreator
    {
        private FurnitureFactory _factory;

        public void SetFactory(FurnitureFactory factory)
        {
            _factory = factory;
        }

        public Chair CreateChair() => _factory.CreateChair();
        public Table CreateTable() => _factory.CreateTable();
        public Sofa CreateSofa() => _factory.CreateSofa();
    }
    public class Checker
    {
        public static void Main()
        {
            FurnitureCreator creator = new FurnitureCreator();
            creator.SetFactory(new ModernWoodFactory());
            Chair modernWoodChair = creator.CreateChair();
            Table modernWoodTable = creator.CreateTable();
            Sofa modernWoodSofa = creator.CreateSofa();
        }
    }
}
    
